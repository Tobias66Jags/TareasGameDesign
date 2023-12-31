using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed =5f;


    private Rigidbody2D _rb2d;
    private Animator _animator;

    Vector2 _movement;

    bool isLocalPlayer = true;

    private void Start()
    {
     _rb2d = GetComponent<Rigidbody2D>();
     _animator = GetComponent<Animator>();
    }

    private void Update()
    {

        if (!isLocalPlayer)
        {
            return;
        }

        if (GameManager.Instance.isPlay) 
        {
            _movement.x = Input.GetAxisRaw("Horizontal");
            _movement.y = Input.GetAxisRaw("Vertical");

            _animator.SetFloat("Horizontal", _movement.x);
            _animator.SetFloat("Vertical", _movement.y);
            _animator.SetFloat("Speed", _movement.sqrMagnitude);
        }
    }

    private void FixedUpdate()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        _rb2d.MovePosition(_rb2d.position+ _movement.normalized * _moveSpeed*Time.fixedDeltaTime);
    }
}
