using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Actions {
	public class EarthQuakeShake : MonoBehaviour {
		
		public static EarthQuakeShake Singleton { get; set; }
		public float force = 1f;
		private Vector3 _startPosition;
		public bool shake = false;
		
		private void Start() {
			InitSingleton();
			_startPosition = transform.position;
		}

		private void InitSingleton() {
			if (Singleton)
				Destroy(gameObject);
			else
				Singleton = this;
		}

		public void UnShake() {
			shake = false;
			transform.position = _startPosition;
		}

		private void Update() {
			if (shake) {
				transform.position = _startPosition + new Vector3(Random.Range(-1, 1), Random.Range(-1, 1)) * (Random.Range(-1f, 1f) * force);
			}
		}
	}
}