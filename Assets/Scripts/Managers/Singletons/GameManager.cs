using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            Casting,
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
                    _ = HandleCastingAsync();
                    break;

                case State.Casting:
                    break;

                case State.Setup:
                    break;

                case State.WaitingForInput:
                    break;
            }
        }

        private async Awaitable HandleCastingAsync()
        {
            bool didCastSpell = false;

            do
            {
                SetState(State.WaitingForInput);

                Card targetCard = await ChooseTargetCardAsync();

                SetState(State.Casting);

                didCastSpell = await TryCastSpellAsync(targetCard);
            }
            while (!didCastSpell);

            SetState(State.ReadyToCast);
        }

        private void SetState(State state)
        {
            Debug.Log($"{this.state} -> {state}");

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

            yield return new WaitForSeconds(.25f);

            libraryZone.Cards.First(x => x.CardName == "Doom Blade")
                .MoveToZone(handZone);

            SetState(State.ReadyToCast);
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
                if (manaManager.TrySpendMana(card.ManaCosts))
                {
                    Debug.Log("Casting spell - " + card.CardName);
                    card.MoveToZone(stackZone);
                    // TODO - Trigger the enter the battlefield event.
                    // TODO - Trigger actions
                    // TODO - Register listeners

                    await card.ExecuteCommandsAsync();

                    if (card.CardType.IsPermanent)
                    {
                        card.MoveToZone(battlefieldZone);
                    }
                    else
                    {
                        card.MoveToZone(graveyardZone);
                    }
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

        private readonly AwaitableCompletionSource<Card> targetCardCompletionSource = new();

        public async Awaitable<Card> ChooseTargetCardAsync()
        {
            // TODO - Use an input query to show valid choices for the target.
            // TODO - Show the targetting UI.

            return await targetCardCompletionSource.ResetAndReturnAwaitable();

            //Awaitable<Card> awaitable =  targetCardCompletionSource.Awaitable;
            //targetCardCompletionSource.Reset();

            //return await awaitable;

            // TODO - Validate card matches query? or do I do it in choose target instead?
        }

        public void SetAsTarget(Card card)
        {
            targetCardCompletionSource.SetResult(card);
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