using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D _rb;
    Vector2 _moveVelocity;

    [SerializeField] float _speed;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.velocity = _moveVelocity * _speed;
    }

    public void Move(Vector3 moveVector)
    {
        _moveVelocity = moveVector.normalized;
    }

  

}
