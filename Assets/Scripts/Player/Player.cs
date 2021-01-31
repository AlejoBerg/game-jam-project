using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    PlayerMovement _movement;
    float _insanity;
    float _lastDogCall;
    bool _alive = true;
    
    [SerializeField] float _baseSpeed;
    [SerializeField] float _maxInsanity;
    [SerializeField] float _insanityIncreaseRatio;
    [SerializeField] float _dogCallCooldown;

    public delegate void OnInsanityChanged(float insanity);
    public event OnInsanityChanged InsanityChanged;

    public delegate void OnDogCalled();
    public event OnDogCalled CalledDog;

    public float Insanity { get { return _insanity; } set
        { 
            _insanity = value;
            if (_insanity > _maxInsanity) { _insanity = _maxInsanity; _alive = false; }
            if (_insanity < 0) _insanity = 0;
            InsanityChanged(_insanity); 
        } 
    }

    public float MaxInsanity { get => _maxInsanity; set => _maxInsanity = value; }

    void Start()
    {
        _movement = GetComponent<PlayerMovement>();
        _movement.Speed = _baseSpeed;
    }

    private void Update()
    {
        IncreaseInsanity();
    }

    void IncreaseInsanity()
    {
        if(Insanity < MaxInsanity)
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
        Insanity += damage;
    }

    public void Move(Vector3 direction)
    {
        _movement.Move(direction);
    }

    public void Rotate(Vector3 mousePos)
    {
        _movement.LookAt(mousePos);
    }

    public void CallDog()
    {
        if(Time.time > _lastDogCall + _dogCallCooldown && _alive)
        {
            //play sound
            CalledDog();
        }

    }
}
