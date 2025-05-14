using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
    /// <summary>
    /// TODO - This thing is gonna be a hacky mess for a bit while I figure out the architecture needs.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        private enum State
        {
            Setup,
            WaitingForInput,
            ReadyToCast,
            CastingSpell,
            Error,
        }

        public static GameManager Instance { get; private set; }

        [SerializeField] private Card cardPrefab;

        [SerializeField] private Player player1;
        [SerializeReference] private ManaManager manaManager;

        [Header("Runtime Sets")]
        [SerializeField] private ZoneRuntimeSet libraryZone;
        [SerializeField] private ZoneRuntimeSet graveyardZone;
        [SerializeField] private ZoneRuntimeSet exileZone;
        [SerializeField] private ZoneRuntimeSet battlefieldZone;
        [SerializeField] private ZoneRuntimeSet handZone;
        [SerializeField] private ZoneRuntimeSet stackZone;

        private State state = State.Setup;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
                return;
            }
        }

        private void Start()
        {
            InitializeDeck(player1);

            StartCoroutine(Setup());
        }

        private void Update()
        {
            switch (state)
            {
                case State.ReadyToCast:
                    StartAsync(HandleCastingAsync, nameof(HandleCastingAsync));
                    break;

                case State.CastingSpell:
                    break;

                case State.Setup:
                    break;

                case State.WaitingForInput:
                    break;

                case State.Error:
                    break;
            }
        }

        private async void StartAsync(System.Func<Awaitable> function, string functionName)
        {
            try
            {
                await function();
            }
            catch (System.Exception ex)
            {
                Debug.LogWarning($"Unhandled exception in {functionName}.");
                Debug.LogException(ex);

                SetState(State.Error);
            }
        }

        private async Awaitable HandleCastingAsync()
        {
            bool didCastSpell = false;

            do
            {
                SetState(State.WaitingForInput);

                Card targetCard = await ChooseTargetCardAsync(cardQuery: null);

                SetState(State.CastingSpell);

                didCastSpell = await TryCastSpellAsync(targetCard);
            }
            while (!didCastSpell);

            SetState(State.ReadyToCast);
        }

        private void SetState(State state)
        {
            string message = $"{this.state} -> {state}";

            if (state == State.Error)
            {
                Debug.LogError(message);
            }
            else
            {
                Debug.Log(message);
            }

            this.state = state;
        }

        private IEnumerator Setup()
        {
            SetState(State.Setup);

            yield return new WaitForSeconds(.25f);

            libraryZone.Cards.First(x => x.CardName == "Goblin Electromancer")
                .MoveToZone(battlefieldZone);

            yield return new WaitForSeconds(.25f);

            libraryZone.Cards.First(x => x.CardName == "Dogged Detective")
                .MoveToZone(battlefieldZone);

            int maxCards = System.Math.Min(libraryZone.Cards.Count, 5);

            for (int i = 0; i < maxCards; i++)
            {
                yield return new WaitForSeconds(.25f);
                Move();
            }

            yield return new WaitForSeconds(.5f);

            SetState(State.ReadyToCast);

            void Move()
            {
                Card card = libraryZone.Cards[0];

                Debug.Log($"Moving {card} to hand zone");

                card.MoveToZone(handZone);
            }
        }

        private void InitializeDeck(Player controllingPlayer)
        {
            var cards = new List<Card>();

            foreach (CardSet cardSet in controllingPlayer.DeckData.CardSets)
            {
                for (int i = 0; i < cardSet.Count; i++)
                {
                    Card card = Instantiate(cardPrefab);
                    card.Initialize(controllingPlayer, cardSet.CardData, imageIndex: i);

                    if (cards.Count == 0)
                    {
                        cards.Add(card);
                    }
                    else
                    {
                        int insertIndex = Random.Range(0, cards.Count);
                        cards.Insert(insertIndex, card);
                    }
                }
            }

            foreach (Card card in cards)
            {
                libraryZone.AddCard(card);
            }
        }

        // TODO - Just for testing.
        // This approach would be insta-spaghetti.
        public async Awaitable<bool> TryCastSpellAsync(Card card)
        {
            // TODO - Check if card has decisions that need to be made (mode, targetting, etc.)

            if (card.CurrentZone == handZone)
            {
                if (manaManager.TrySpendMana(card.ManaCost))
                {
                    Debug.Log("Casting spell - " + card.CardName);
                    card.MoveToZone(stackZone);
                    // TODO - Trigger the enter the battlefield event.
                    // TODO - Trigger actions
                    // TODO - Register listeners

                    await card.ExecuteSpellAbilityAsync();

                    if (card.IsPermanent)
                    {
                        card.MoveToZone(battlefieldZone);
                    }
                    else
                    {
                        card.MoveToZone(graveyardZone);
                    }

                    return true;
                }
                else
                {
                    Debug.Log($"Not enough mana to cast {card}.");
                }
            }
            else
            {
                Debug.Log($"Card is not in hand - {card.CardName}");
            }

            return false;
        }

        private readonly AwaitableCompletionSource<Card> targetSelectionCompletionSource = new();
        private MtgColors? currentQuery;

        public async Awaitable<Card> ChooseTargetCardAsync(MtgColors? cardQuery)
        {
            Debug.Log($"Choosing target card - {(cardQuery?.ToString() ?? "No Query")}");

            currentQuery = cardQuery;

            return await targetSelectionCompletionSource.AwaitAndReset();
        }

        public bool TrySetAsTarget(Card card)
        {
            if (!currentQuery.HasValue || currentQuery.Value.HasFlag(card.Colors))
            {
                Debug.Log($"Setting target card - {card.CardName}");

                targetSelectionCompletionSource.SetResult(card);

                return true;
            }

            Debug.Log($"Can't set target card. Card does not match query - {card.CardName} - {currentQuery}");

            return false;
        }

        public void ReturnToHand(Card card)
        {
            card.MoveToZone(handZone);
        }

        public void DestroyCard(Card card)
        {
            card.MoveToZone(graveyardZone);

            // TODO - Trigger the destroy event.
        }
    }
}