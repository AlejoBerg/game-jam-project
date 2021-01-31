using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorHandler : MonoBehaviour
{
    Animator myAnimator;
    Rigidbody2D myRigidbody;
    Player _player;

    [SerializeField] bool _menu;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
    }

    private void Update()
    {

        if (_menu || _player.Alive)
        {

            myAnimator.SetFloat("HorizontalVelocity", myRigidbody.velocity.x);
            myAnimator.SetFloat("VerticalVelocity", myRigidbody.velocity.y);

            myAnimator.SetFloat("MousePosX", Input.mousePosition.x / Screen.width - 0.5f);
            myAnimator.SetFloat("MousePosY", Input.mousePosition.y / Screen.height - 0.5f);
        }

        if (_menu)
        {
            if (myRigidbody.velocity.x == 0 && myRigidbody.velocity.y == 0) 
            {
                myAnimator.SetBool("isIdle", true);
            }
            else
            {
                myAnimator.SetBool("isIdle", false);
            }
        }
        else myAnimator.SetBool("isIdle", _player.Idle);
    }
}
