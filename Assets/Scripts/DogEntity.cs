using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogEntity : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _speed;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        FollowPlayer();
    }

    private  void FollowPlayer()
    {
        print(_playerTransform.localPosition);

        if (Vector3.Distance(transform.position, _playerTransform.position) > 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, _playerTransform.position, _speed * Time.deltaTime);
        }
        else
        {
            _animator.enabled = !enabled;
        }
    }
    
}
