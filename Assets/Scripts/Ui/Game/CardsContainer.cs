using System;
using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using Game.Cards;
using Game.Cards.Merge;
using UnityEngine.UI;

namespace Ui.Game
{
	public class CardsContainer : MonoBehaviour
	{
		public static CardsContainer Singleton { get; private set; }

		[Header("Cards")]
		public GameObject[] cardPrefabs;
		private int maxCardsInHand = 5;
		public GameObject mergedCardsPrefab;
		[Header("Some Service Objects")]
		public RectTransform cardsContainer;
		public RectTransform canvas;
		public RectTransform cards;
		private float _cardsContainerY;
		public List<CardBase> listCardBase = new List<CardBase>();
		[Header("List Cards")]
		public int numberOfCards;
		public float rateTheEarth;
		public float rateTheWind;
		public float rateTheDeath;
		public float rateTheSun;
		public float rateTheRain;
		private List<CardType> _listOfCards = new List<CardType>();

		private void Awake()
		{
			RandomCards();
		}

		private void Start()
		{			
			_cardsContainerY = Camera.main.ViewportToScreenPoint(new Vector3(0f, cardsContainer.anchorMax.y, 0f)).y;
			InitSingleton();
			InitCards();
		}

		private void InitCards()
		{
			for (var i = 0; i < maxCardsInHand; i++)
			{
				SpawnCard();
			}
		}

		public void SpawnCard()
		{
			int listIndex = Random.Range(0, _listOfCards.Count);
			var cardUi = Instantiate(getCardBuyType(_listOfCards[listIndex]), cards).GetComponent<CardUI>();
			//Callback for spawn new card
			cardUi.OnDrop = OnDrop;
			listCardBase.Add(cardUi.card);
		}

		public void MergeCards(CardBase card, CardBase card2)
		{
			var mergedCardObject = Instantiate(mergedCardsPrefab, cards);
			var mergedCard = mergedCardObject.GetComponent<MergedCard>();
			AddCardToMergedCard(mergedCard, card);
			AddCardToMergedCard(mergedCard, card2);
			var mergedCardUi = mergedCardObject.GetComponent<CardUI>();
			mergedCardUi.OnDrop += OnDrop;

			listCardBase.Add(mergedCard);
		}

		private void AddCardToMergedCard(MergedCard mergedCard, CardBase card)
		{
			if (card is MergedCard mc)
			{
				foreach (var cardBase in mc.cards)
				{
					mergedCard.cards.Add(cardBase);
				}
			}
			else
			{
				mergedCard.cards.Add(card);
			}
			card.transform.SetParent(mergedCard.transform);
			card.GetComponent<Image>().raycastTarget = false;
			Destroy(card.GetComponent<CardUI>());
			listCardBase.Remove(card);
		}

		private void InitSingleton()
		{
			if (Singleton)
				Destroy(gameObject);
			else
				Singleton = this;
		}

		public bool IsInsidePanel(float y) => y < _cardsContainerY;


		public void OnDrop(CardBase card)
		{
			listCardBase.Remove(card);
			SpawnCard();
		}

		public CardBase GetClosestCard(CardBase card)
		{
			float distance = Mathf.Infinity;
			int index = 0;
			for (int i = 0; i < listCardBase.Count; i++)
			{
				if (listCardBase[i] == card)
					continue;
				float distanceToCard = Vector2.Distance(card.transform.position, listCardBase[i].gameObject.transform.position);
				if (distanceToCard < distance)
				{
					index = i;
					distance = distanceToCard;
				}
			}
			return listCardBase[index];

		}

		public void RandomCards()
		{
			int numberOfCardsDeath = (Int32)Mathf.Round(numberOfCards * rateTheDeath);
			for (int i = 0; i < numberOfCardsDeath; i++)
			{
				var cardType = CardType.Death;
				_listOfCards.Add(cardType);
			}

			float numberOfCardsEarth = Mathf.Round(numberOfCards * rateTheEarth);
			for (int i = 0; i < numberOfCardsEarth; i++)
			{
				var cardType = CardType.Earth;
				_listOfCards.Add(cardType);
			}

			float numberOfCardsRain = Mathf.Round(numberOfCards * rateTheRain);
			for (int i = 0; i < numberOfCardsRain; i++)
			{
				var cardType = CardType.Rain;
				_listOfCards.Add(cardType);
			}

			float numberOfCardsSun = Mathf.Round(numberOfCards * rateTheSun);
			for (int i = 0; i < numberOfCardsSun; i++)
			{
				var cardType = CardType.Sun;
				_listOfCards.Add(cardType);
			}

			float numberOfCardsWind = Mathf.Round(numberOfCards * rateTheWind);
			for (int i = 0; i < numberOfCardsWind; i++)
			{
				var cardType = CardType.Wind;
				_listOfCards.Add(cardType);
			}

		}

		private GameObject getCardBuyType(CardType cardType)
		{
			if (cardType == CardType.Death)
				return cardPrefabs[0];
			if (cardType == CardType.Earth)
				return cardPrefabs[1];
			if (cardType == CardType.Rain)
				return cardPrefabs[2];
			if (cardType == CardType.Sun)
				return cardPrefabs[3];
			if (cardType == CardType.Wind)
				return cardPrefabs[4];
			return null;
		}
	}

}