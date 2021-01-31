using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorHandler : MonoBehaviour
{
    Animator myAnimator;
    Rigidbody2D myRigidbody;
    Player _player;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
    }

    private void Update()
    {

        if (_player.Alive)
        {

            myAnimator.SetFloat("HorizontalVelocity", myRigidbody.velocity.x);
            myAnimator.SetFloat("VerticalVelocity", myRigidbody.velocity.y);

            myAnimator.SetFloat("MousePosX", Input.mousePosition.x / Screen.width - 0.5f);
            myAnimator.SetFloat("MousePosY", Input.mousePosition.y / Screen.height - 0.5f);
        }

        myAnimator.SetBool("isIdle", _player.Idle);
    }
}
