using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Game.Cards;
using Game;
using Game.Cards.Merge;
using Ui.Game;

public class CardUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	//Card rotation effect params
	private static readonly float _angle = 15f;
	private static readonly float _rotationToZeroSpeed = 2f;
	private static readonly float _rotationToOneSpeed = 0.3f;


	public CardBase card;
	public Action<CardBase> OnDrop { get; set; }
	
	private Vector2 _currentRotation = Vector2.zero;
	private RectTransform _rectTransform;
	private Vector2 _standardAnchorMin;
	private Vector2 _standardAnchorMax;
	private PointerEventData _pointer;


	public void OnPointerDown(PointerEventData eventData)
	{
		_pointer = eventData;
		_rectTransform.SetParent(CardsContainer.Singleton.canvas);
		var anchor = Vector2.one * 0.5f;
		_rectTransform.anchorMax = anchor;
		_rectTransform.anchorMin = anchor;
	}

	public void OnPointerUp(PointerEventData eventData) {

		float positionCard = _rectTransform.localPosition.y + 300f;
		if (CardsContainer.Singleton.IsInsidePanel(positionCard))
		{
			_rectTransform.SetParent(CardsContainer.Singleton.cards);
			transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
			var closestCard = CardsContainer.Singleton.GetClosestCard(card);
			MergedCardsController.CanMerge(closestCard.ToString() + card);
		}
		else
		{
			VillageController.Singleton?.ProcessEventOrCard(card);
			OnDrop?.Invoke(card);
			Destroy(gameObject);
		}
		_pointer = null;

	}

	private void Start()
	{
		_rectTransform = transform as RectTransform;
	}

	private void Update()
	{


		if (_pointer == null) return;

		if (_pointer.delta != Vector2.zero) {
			_currentRotation.x += _pointer.delta.x * Time.deltaTime * _rotationToOneSpeed;
			_currentRotation.x = Mathf.Clamp(_currentRotation.x, -1f, 1f);

			_currentRotation.y += _pointer.delta.y * Time.deltaTime * _rotationToOneSpeed;
			_currentRotation.y = Mathf.Clamp(_currentRotation.y, -1f, 1f);
		}
		else {
			if (_currentRotation.x != 0f) {
				float sign = (_currentRotation.x < 0f) ? -1f : 1f;
				_currentRotation.x -= Time.deltaTime * _rotationToZeroSpeed * sign;
				float afterSign = (_currentRotation.x < 0f) ? -1f : 1f;

				if (sign != afterSign)
					_currentRotation.x = 0f;
			}
			if (_currentRotation.y != 0f) {
				float sign = _currentRotation.y < 0f ? -1f : 1f;
				_currentRotation.y -= Time.deltaTime * _rotationToZeroSpeed * sign;
				float afterSign = _currentRotation.y < 0f ? -1f : 1f;
				if (sign != afterSign)
					_currentRotation.y = 0f;
			}

		}



		transform.localRotation = Quaternion.Euler(new Vector3(_angle * _currentRotation.y, _angle * _currentRotation.x, 0f));

		RectTransformUtility.ScreenPointToLocalPointInRectangle(CardsContainer.Singleton.canvas, _pointer.position, Camera.main,
					out var localPoint);
		_rectTransform.anchoredPosition = localPoint;
	}

}
