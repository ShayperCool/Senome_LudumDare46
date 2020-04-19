using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    public static Vector2 currentDirection;
    private Vector3 _startPosition;
    [Range(0f, 1f)]
    public float strength = 0.5f;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    { 
        Vector3 newPosition = _startPosition;
        newPosition.x -= currentDirection.x * strength;
        transform.position = newPosition;
    }

}
