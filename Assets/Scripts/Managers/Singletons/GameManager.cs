using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VoidScribe.MtgDuelDecks
{
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
        [SerializeField] private ManaManager manaManager;

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
                    StartCoroutine(MoveTheCards());
                    break;

                case State.ReadyToGame:
                    Debug.Log("Doing a thing");
                    state = State.Gaming;
                    break;

                case State.Dealing:
                case State.Gaming:
                    break;
            }
        }

        private IEnumerator MoveTheCards()
        {
            state = State.Dealing;

            int maxCards = System.Math.Min(deckZoneRuntimeSet.Cards.Count, 5);

            for (int i = 0; i < maxCards; i++)
            {
                yield return new WaitForSeconds(.5f);
                Move();
            }

            yield return new WaitForSeconds(1f);

            state = State.ReadyToGame;

            void Move()
            {
                Card card = deckZoneRuntimeSet.Cards[0];

                Debug.Log($"Moving {card} to hand zone");

                card.MoveToZone(handZoneRuntimeSet);
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
                deckZoneRuntimeSet.AddCard(card);
            }
        }
    }
}