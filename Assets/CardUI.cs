using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Game.Cards;
using Game;
public class CardUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public CardBase card;
	public RectTransform container;

	private RectTransform _parent;
	private RectTransform _rectTransform;
	private Vector2 _standardAnchoredPosition;
	private Vector2 _standardAnchorMin;
	private Vector2 _standardAnchorMax;
	private PointerEventData _pointer;
	
	public void OnPointerDown(PointerEventData eventData)
	{
		_pointer = eventData;
		_rectTransform.SetParent(container);
		var anchor = Vector2.one * 0.5f;
		_rectTransform.anchorMax = anchor;
		_rectTransform.anchorMin = anchor;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		_pointer = null;
		VillageController.Singleton?.ProcessAction(card);
		Destroy(gameObject);
	}

	private void Start()
	{
		_rectTransform = transform as RectTransform;
	}

	private void Update()
	{
		if (_pointer == null) return;
		
		if (_pointer.delta.x < 0)
		{
			Vector3 rotation = transform.localEulerAngles;
			rotation.y = 45;
			transform.localEulerAngles = rotation;
		}
		if (_pointer.delta.x > 0)
		{
			Vector3 rotation = transform.localEulerAngles;
			rotation.y = -45;
			transform.localEulerAngles = rotation;
		}
		else
		{
			Vector3 rotation = transform.localEulerAngles;
			rotation.y = 0;
			transform.localEulerAngles = rotation;
		}

		if (_pointer.delta.y < 0)
		{
			Vector3 rotation = transform.localEulerAngles;
			rotation.x = 45;
			transform.localEulerAngles = rotation;
		}
		if (_pointer.delta.y > 0)
		{
			Vector3 rotation = transform.localEulerAngles;
			rotation.x = 45;
			transform.localEulerAngles = rotation;
		}
		else
		{
			Vector3 rotation = transform.localEulerAngles;
			rotation.x = 0;
			transform.localEulerAngles = rotation;
		}


		RectTransformUtility.ScreenPointToLocalPointInRectangle(container, _pointer.position, Camera.main,
					out var localPoint);
		_rectTransform.anchoredPosition = localPoint;
	}
}