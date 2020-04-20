using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Actions {
	public class TornadoObjectController : MonoBehaviour {

		public float speed = 1f;
		public float minX = -17f;
		public float maxX = 17f;
		private float _direction = 1f;

		private Rigidbody2D _rb2d;

		private void Start() {
			_rb2d = GetComponent<Rigidbody2D>();
		}

		private void FixedUpdate() {
			if (_rb2d.position.x < minX)
				_direction = 1f;
			else if (_rb2d.position.x > maxX)
				_direction = -1f;
			
			_rb2d.MovePosition(_rb2d.position + Vector2.right * (Time.deltaTime * speed * _direction));
		}
	}
}
