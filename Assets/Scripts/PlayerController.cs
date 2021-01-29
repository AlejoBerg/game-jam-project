using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerMovement _playerMovement;
    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        _playerMovement.Move(new Vector3(horizontal,vertical));

    }
}
