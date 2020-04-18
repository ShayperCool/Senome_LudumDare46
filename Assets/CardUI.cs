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
	public RectTransform panelCards;

	[Header("Rotate settings")] 
	public float angle = -30f;
	public float rotationToZeroSpeed = 0f;
	public float rotationToOneSpeed = 0f;
	private float _currentState = 0f;
	private float panelY;
	private Vector2 _currentRotation = Vector2.zero;
	
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

		float positionCard = transform.position.y;
		float positionPanel = panelCards.localPosition.y + 300f; 
		Debug.Log(positionCard +"- Pos Card");
		Debug.Log(positionPanel + "- Pos Panel");

		if (positionCard < panelY)
		{
			_rectTransform.SetParent(panelCards);
		}
		else
		{
			VillageController.Singleton?.ProcessAction(card);
			Destroy(gameObject);
		}
		_pointer = null;

	}

	private void Start()
	{
		_rectTransform = transform as RectTransform;

		panelY = Camera.main.ScreenToWorldPoint((Vector3)panelCards.localPosition).y * 2;
	}

	private void Update()
	{
		

		if (_pointer == null) return;

		if (_pointer.delta != Vector2.zero) {
			_currentRotation.x += _pointer.delta.x * Time.deltaTime * rotationToOneSpeed;
			_currentRotation.x = Mathf.Clamp(_currentRotation.x, -1f, 1f);

			_currentRotation.y += _pointer.delta.y * Time.deltaTime * rotationToOneSpeed;
			_currentRotation.y = Mathf.Clamp(_currentRotation.y, -1f, 1f);
		}
		else {
			
			if (_currentRotation.x != 0f) {
				float sign = (_currentRotation.x < 0f) ? -1f : 1f;
				_currentRotation.x -= Time.deltaTime * rotationToZeroSpeed * sign;
				float afterSign = (_currentRotation.x < 0f) ? -1f : 1f;

				if (sign != afterSign)
					_currentRotation.x = 0f;

			}

			if (_currentRotation.y != 0f) {
				float sign = _currentRotation.y < 0f ? -1f : 1f;
				_currentRotation.y -= Time.deltaTime * rotationToZeroSpeed * sign;
				float afterSign = _currentRotation.y < 0f ? -1f : 1f;
				if (sign != afterSign)
					_currentRotation.y = 0f;
			}
			
		}


		
		transform.localRotation = Quaternion.Euler(new Vector3(angle * _currentRotation.y, angle * _currentRotation.x, 0f));

		RectTransformUtility.ScreenPointToLocalPointInRectangle(container, _pointer.position, Camera.main,
					out var localPoint);
		_rectTransform.anchoredPosition = localPoint;
	}

	private void RotationProcess() {
		Vector2 newRotation;
	}
	
}