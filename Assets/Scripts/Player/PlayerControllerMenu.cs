using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerMenu : MonoBehaviour
{
    PlayerMenu _player;

    int _horizontalMovement;
    int _verticalMovement;

    void Start()
    {
        _player = GetComponent<PlayerMenu>();
    }

    void Update()
    {
        Movement();
        Rotation();
    }

    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.A)) _horizontalMovement = -1;
        if (Input.GetKeyDown(KeyCode.D)) _horizontalMovement = 1;
        if (Input.GetKeyDown(KeyCode.S)) _verticalMovement = -1;
        if (Input.GetKeyDown(KeyCode.W)) _verticalMovement = 1;

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) _horizontalMovement = 0;
        if (!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W)) _verticalMovement = 0;

        _player.Move(new Vector3(_horizontalMovement, _verticalMovement));
    }

    void Rotation()
    {
        _player.Rotate(Input.mousePosition);
    }
}
