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
            ReadyToDeal,
            Dealing,
            ReadyToGame,
            Gaming
        }

        public static GameManager Instance { get; private set; }

        [SerializeField] private Card cardPrefab;

        [SerializeField] private Player player1;
        [SerializeReference] private ManaManager manaManager;

        [Header("Runtime Sets")]
        [SerializeField] private ZoneRuntimeSet deckZoneRuntimeSet;
        [SerializeField] private ZoneRuntimeSet graveyardZoneRuntimeSet;
        [SerializeField] private ZoneRuntimeSet exileZoneRuntimeSet;
        [SerializeField] private ZoneRuntimeSet battlefieldZoneRuntimeSet;
        [SerializeField] private ZoneRuntimeSet handZoneRuntimeSet;

        private State state = State.ReadyToDeal;

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
        }

        private void Update()
        {
            switch (state)
            {
                case State.ReadyToDeal:
                    StartCoroutine(Setup());
                    break;

                case State.ReadyToGame:
                    //StartCoroutine(DoGameThings());

                    state = State.Gaming;
                    break;

                case State.Dealing:
                case State.Gaming:

                    break;
            }
        }

        private IEnumerator Setup()
        {
            state = State.Dealing;

            yield return new WaitForSeconds(.25f);

            deckZoneRuntimeSet.Cards.First(x => x.CardName == "Goblin Electromancer")
                .MoveToZone(battlefieldZoneRuntimeSet);

            yield return new WaitForSeconds(.25f);

            deckZoneRuntimeSet.Cards.First(x => x.CardName == "Dogged Detective")
                .MoveToZone(battlefieldZoneRuntimeSet);

            yield return new WaitForSeconds(.25f);

            deckZoneRuntimeSet.Cards.First(x => x.CardName == "Doom Blade")
                .MoveToZone(handZoneRuntimeSet);

            state = State.ReadyToGame;
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
                deckZoneRuntimeSet.AddCard(card);
            }
        }

        // TODO - Just for testing.
        // This approach would be insta-spaghetti.
        public void CastSpell(Card card)
        {
            if (card.CurrentZone == handZoneRuntimeSet)
            {
                if (manaManager.TrySpendMana(card.ManaCosts))
                {
                    card.MoveToZone(battlefieldZoneRuntimeSet);
                    // trigger the enter the battlefield event.
                }
                else
                {
                    Debug.Log($"Not enough mana to cast {card}.");
                }
            }
        }

        public void ReturnToHand(Card card)
        {
            card.MoveToZone(handZoneRuntimeSet);
        }
    }
}