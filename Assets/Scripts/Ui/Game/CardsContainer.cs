using System;
using UnityEngine;
using Random = UnityEngine.Random;

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
			cardUi.OnDrop = SpawnCard;
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
		
	}
}