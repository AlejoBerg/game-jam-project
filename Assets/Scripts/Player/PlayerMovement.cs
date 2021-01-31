using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D _rb;
    Vector2 _moveVelocity;

    [SerializeField] float _speed;
    [SerializeField] GameObject _objectToRotate;

    public float Speed { get => _speed; set => _speed = value; }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.velocity = _moveVelocity * Speed;

    }

    public void Move(Vector3 moveVector)
    {
        _moveVelocity = moveVector.normalized;
    }

    public void LookAt(Vector3 direction)
    {
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(direction);
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        _objectToRotate.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
