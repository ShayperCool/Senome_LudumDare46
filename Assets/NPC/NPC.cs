using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;
using Game.Models;
using Random = UnityEngine.Random;


public class NPC : MonoBehaviour
{
    [SerializeField] private float _idleSpeedNpc , _dangerousSpeedNpc , _slowSpeedNpc;
    [SerializeField] private float _jumpForceNpc;
    [SerializeField] private bool _dangerous = false;
    [SerializeField] private bool _grounded;
    [SerializeField] private Transform _groundTransform;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private int Test = 0;
    [SerializeField] private int minXNpcPos;
    [SerializeField] private int maxXNpcPos;

    private Rigidbody2D rb;
    private float _groundRange = 0.4f;
    private float _currentSpeed;
    private float _currentDir = 1;
    private float _targetX;
    private bool Flip;
    private Vector3 _startPos;
    private float direction = 1f;
    private float directionY = 1f;
    [SerializeField]private float forceY = 20f;
    [SerializeField]private float forceX = 20f;
    private Action _moveAction;
    private Transform _tornadoTransform;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SelectPosition();
        _currentSpeed = _idleSpeedNpc;
        VillageController.Singleton.OnEventInVillage += ChangeState;
        _moveAction = Move;
    }

    private void FixedUpdate()
    {
        _grounded = Physics2D.OverlapCircle(_groundTransform.position,_groundRange,_whatIsGround);       
        _moveAction?.Invoke();
    }

    private void Update() 
    {
        if(_currentDir > 0f)
        {
            if(transform.position.x > _targetX)
            {
                SelectPosition();
            }
        }
        else
        {
            if(transform.position.x < _targetX)
            {
                SelectPosition();
            }
        }
    }

    private void SelectPosition()
    {
        _targetX = Random.Range(minXNpcPos, maxXNpcPos);
        if(_targetX <= 0 )
        {
            _currentDir = -1f;
            Flip = false;
        }
        else
        {
            _currentDir = 1f;
            Flip = true;
        }
    }

    private void Move()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = (Vector2.right * _currentSpeed * _currentDir).x;
        rb.velocity = velocity;
        FlipNpc();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        _startPos = transform.position;
        _moveAction = Tornado;
        rb.velocity = Vector2.zero;
        _tornadoTransform = other.transform;
    }

    private void Tornado() {
        if (transform.position.x > _tornadoTransform.position.x) {
            direction = -1f;
        }
        else if (transform.position.x < _tornadoTransform.position.x) {
            direction = 1f;
        }

        if (transform.position.y < 0f) {
            directionY = 1f;
        }        
        else if (transform.position.y > 0f) {
            directionY = 1f;
        }
        rb.AddForce(Vector2.right * direction * forceX + Vector2.up * directionY * forceY, ForceMode2D.Force);
    }
    
    private void OnTriggerExit2D(Collider2D other) {
        _moveAction = Move;
    }
    
    
    

    private void ChangeState(EventInVillage eventInVillage)
    {
        if (eventInVillage == EventInVillage.None) //Обычное состояние
        {
            OnChangeState(_idleSpeedNpc , Color.white);
        }
        else if (eventInVillage == EventInVillage.Fire) //Пожар
        {
            OnChangeState(_dangerousSpeedNpc, Color.white);
            StartCoroutine(DangerousJumps());
        }
        else if (eventInVillage == EventInVillage.Fog) //Туман
        {
            OnChangeState(_slowSpeedNpc, Color.white);
        }
        else if (eventInVillage == EventInVillage.Plague) //Чума
        {
            OnChangeState(_slowSpeedNpc, Color.green);
        }
        else if (eventInVillage == EventInVillage.Flood)
        {
            OnChangeState(0f , Color.white);
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;

        }
    }

    private void OnChangeState(float _newSpeed, Color _colorNpc)
    {
        gameObject.GetComponent<SpriteRenderer>().color = _colorNpc;
        _currentSpeed = _newSpeed;
        StopAllCoroutines();
    }

    private void JumpNpc() //  Главный метод прыжка NPC
    {
        if(_grounded)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(transform.up * _jumpForceNpc, ForceMode2D.Impulse);
        }
    } 
    private void FlipNpc() // Метод для поворота NPC
    {
        if (Flip)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (!Flip)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
    private IEnumerator DangerousJumps()
    {
        JumpNpc();
        yield return new WaitForSeconds(Random.Range(2.5f,6));
        StartCoroutine(DangerousJumps());
    }

}
