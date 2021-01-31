using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenu : MonoBehaviour
{
    PlayerMovement _movement;
    [SerializeField] float _baseSpeed;

    void Start()
    {
        _movement = GetComponent<PlayerMovement>();
        _movement.Speed = _baseSpeed;
    }

    public void Move(Vector3 direction)
    {
        _movement.Move(direction);
    }

    public void Rotate(Vector3 mousePos)
    {
        _movement.LookAt(mousePos);
    }
}
