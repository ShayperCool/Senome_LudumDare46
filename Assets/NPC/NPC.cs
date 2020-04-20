using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;
using Game.Models;


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


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SelectPosition();
        _currentSpeed = _idleSpeedNpc;
        VillageController.Singleton.OnEventInVillage += ChangeState;
    }

    private void FixedUpdate()
    {
        _grounded = Physics2D.OverlapCircle(_groundTransform.position,_groundRange,_whatIsGround);       
        Move();
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
