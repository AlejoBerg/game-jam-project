using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    PlayerMovement _movement;
    AudioSource _source;
    float _insanity;
    float _lastDogCall;
    bool _alive = true;

    [SerializeField] float _baseSpeed;
    [SerializeField] float _maxInsanity;
    [SerializeField] float _insanityIncreaseRatio;
    [SerializeField] float _dogCallCooldown;
    [SerializeField] PlayerDieCinematic _playerDieRef;
    [SerializeField] List<AudioClip> _dogCalls;

    public delegate void OnInsanityChanged(float insanity);
    public event OnInsanityChanged InsanityChanged;

    public delegate void OnDogCalled();
    public event OnDogCalled CalledDog;

    public float Insanity
    {
        get { return _insanity; }
        set
        {
            _insanity = value;
            if (_insanity > _maxInsanity) { _insanity = _maxInsanity; _alive = false; Die(); }
            if (_insanity < 0) _insanity = 0;
            InsanityChanged(_insanity);
        }
    }

    public float MaxInsanity { get => _maxInsanity; set => _maxInsanity = value; }

    void Start()
    {
        _movement = GetComponent<PlayerMovement>();
        _movement.Speed = _baseSpeed;
        _source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        IncreaseInsanity();
    }

    void IncreaseInsanity()
    {
        if (Insanity < MaxInsanity)
        {
            Insanity += _insanityIncreaseRatio * Time.deltaTime;
        }
        else
        {
            Insanity = MaxInsanity;
        }
    }

    public float GetInsanityPercentage()
    {
        return Insanity / MaxInsanity;
    }

    public void GetDamage(float damage)
    {
        if (!_alive) return;

        if (Insanity < _maxInsanity) { Insanity += damage; }
        else { _alive = false; }
    }

    public void Move(Vector3 direction)
    {
        if(_alive)
            _movement.Move(direction);
    }

    public void Rotate(Vector3 mousePos)
    {
        if (_alive)
            _movement.LookAt(mousePos);
    }

    public void CallDog()
    {
        if (Time.time > _lastDogCall + _dogCallCooldown && _alive)
        {
            //play sound
            CalledDog();
        }

    }

    private void Die()
    {
        _movement.Speed = 0;
        _playerDieRef.DieEffect();
    }
}
