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

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        _rb.velocity = new Vector2(horizontal*_speed, 0);
        if (horizontal == 0)
        {
            _rb.velocity = Vector2.zero;
        }

        //transform.position += new Vector3(_moveVelocity.x,_moveVelocity.y,0) * _speed * Time.fixedDeltaTime;

        if (Input.GetKeyUp(KeyCode.A)){ Debug.LogError("Solte A"); }
        if (Input.GetKeyUp(KeyCode.D)){ Debug.LogError("Solte D"); }
        if (Input.GetKeyUp(KeyCode.W)){ Debug.LogError("Solte W"); }
        if (Input.GetKeyUp(KeyCode.S)){ Debug.LogError("Solte S"); }
        if(_rb.velocity != Vector2.zero)
        print(_rb.velocity + " Velocity" );
        if (horizontal != 0)
            print(horizontal + " Hprozpm");

    }
    private void FixedUpdate()
    {
       // _rb.MovePosition(_rb.position + _moveVelocity * _speed * Time.fixedDeltaTime);
       // _rb.velocity = new Vector2(_moveVelocity.x * _speed, _moveVelocity.y * _speed);
    }

    public void Move(Vector3 moveVector)
    {
       // _moveVelocity = moveVector.normalized;
        //_rb.velocity = moveVector;
        //if (moveVector == Vector3.zero) _rb.velocity = Vector2.zero;

        //

    }

  

}
