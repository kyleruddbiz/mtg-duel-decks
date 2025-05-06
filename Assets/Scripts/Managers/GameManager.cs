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

        [SerializeField] private Card cardPrefab;
        [SerializeField] private DeckData deckData;

        [Header("Runtime Sets")]
        [SerializeField] private ZoneRuntimeSet deckZoneRuntimeSet;
        [SerializeField] private ZoneRuntimeSet graveyardZoneRuntimeSet;
        [SerializeField] private ZoneRuntimeSet exileZoneRuntimeSet;
        [SerializeField] private ZoneRuntimeSet battlefieldZoneRuntimeSet;
        [SerializeField] private ZoneRuntimeSet handZoneRuntimeSet;

        private State state = State.ReadyToDeal;

        private void Start()
        {
            InitializeDeck();
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

            yield return new WaitForSeconds(1f);

            deckZoneRuntimeSet.Cards[0].MoveToZone(handZoneRuntimeSet);

            yield return new WaitForSeconds(1f);

            deckZoneRuntimeSet.Cards[0].MoveToZone(handZoneRuntimeSet);

            yield return new WaitForSeconds(1f);

            deckZoneRuntimeSet.Cards[0].MoveToZone(handZoneRuntimeSet);

            yield return new WaitForSeconds(1f);

            state = State.ReadyToGame;
        }

        private void InitializeDeck()
        {
            var cards = new List<Card>();

            foreach (CardSet cardSet in deckData.CardSets)
            {
                for (int i = 0; i < cardSet.Count; i++)
                {
                    Card card = Instantiate(cardPrefab);
                    card.Initialize(cardSet.CardData, imageIndex: i);

                    int insertIndex = Random.Range(0, cards.Count);
                    cards.Insert(insertIndex, card);
                }
            }

            foreach (Card card in cards)
            {
                deckZoneRuntimeSet.AddCard(card);
            }
        }
    }
}