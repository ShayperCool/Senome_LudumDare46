using System;
using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using Game.Cards;

namespace Ui.Game {
	public class CardsContainer : MonoBehaviour {
		public static CardsContainer Singleton { get; private set; }

		[Header("Cards")]
		public GameObject[] cardPrefabs;
		private int maxCardsInHand = 5;
		[Header("Some Service Objects")]
		public RectTransform cardsContainer;
		public RectTransform canvas;
		public RectTransform cards;
		private float _cardsContainerY;
		public List<CardBase> listCardBase = new List<CardBase>();

		private void Start() {

			_cardsContainerY = Camera.main.ViewportToScreenPoint(new Vector3(0f, cardsContainer.anchorMax.y, 0f)).y;
			InitSingleton();
			InitCards();
		}

		private void InitCards() {
			for (var i = 0; i < maxCardsInHand; i++) {
				SpawnCard();
			}
		}

		public void SpawnCard() {
			int cardIndex = Random.Range(0, cardPrefabs.Length);
			var card = cardPrefabs[cardIndex];
			var cardUi = Instantiate(card, cards).GetComponent<CardUI>();
			//Callback for spawn new card
			cardUi.OnDrop = OnDrop;
			listCardBase.Add(cardUi.card);
		}

		private void InitSingleton() {
			if (Singleton)
				Destroy(gameObject);
			else
				Singleton = this;
		}

		public bool IsInsidePanel(float y) {
			return y < _cardsContainerY;
		}

		public void OnDrop(CardBase card)
		{
			listCardBase.Remove(card);
			SpawnCard();
		}

		public CardBase GetClosestCard(Vector2 cardPosition)
		{
			float distance = Mathf.Infinity;
			int index=0;
			for(int i=0; i < listCardBase.Count; i++)
			{
				float distanceToCard = Vector2.Distance(cardPosition, listCardBase[i].gameObject.transform.position);
				if (distanceToCard < distance)
				{
					index = i;
					distance = distanceToCard;
				}
			}
			return listCardBase[index];
		}
	}
}