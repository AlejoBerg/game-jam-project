using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerMovement _playerMovement;

    int _horizontalMovement;
    int _verticalMovement;

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
        if (Input.GetKeyDown(KeyCode.A)) _horizontalMovement = -1;  
        if (Input.GetKeyDown(KeyCode.D)) _horizontalMovement = 1;  
        if (Input.GetKeyDown(KeyCode.S)) _verticalMovement = -1;  
        if (Input.GetKeyDown(KeyCode.W)) _verticalMovement = 1;

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) _horizontalMovement = 0;
        if (!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W)) _verticalMovement = 0;


        _playerMovement.Move(new Vector3(_horizontalMovement, _verticalMovement));

    }
}
