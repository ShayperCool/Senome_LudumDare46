using System;
using UnityEngine;

namespace Ui.Game {
	public class CardsContainer : MonoBehaviour {
		
		public RectTransform cardsContainer;
		public static CardsContainer Singleton { get; private set; }
		private float _cardsContainerY;

		private void Start() {
			_cardsContainerY = Camera.main.ViewportToScreenPoint(new Vector3(0f, cardsContainer.anchorMax.y, 0f)).y;
			InitSingleton();
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