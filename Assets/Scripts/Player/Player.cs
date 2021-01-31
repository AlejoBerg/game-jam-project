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
    bool _idle = true;

    [SerializeField] float _baseSpeed;
    [SerializeField] float _maxInsanity;
    [SerializeField] float _insanityIncreaseRatio;
    [SerializeField] float _dogCallCooldown;
    [SerializeField] PlayerDieCinematic _playerDieRef;
    [SerializeField] List<AudioClip> _dogCalls;
    [SerializeField] bool _menu;


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
            if (_insanity > _maxInsanity) { _insanity = _maxInsanity; Alive = false; Die(); }
            if (_insanity < 0) _insanity = 0;
            InsanityChanged(_insanity);
        }
    }

    public float MaxInsanity { get => _maxInsanity; set => _maxInsanity = value; }
    public bool Idle { get => _idle; set => _idle = value; }
    public bool Alive { get => _alive; set => _alive = value; }

    void Start()
    {
        _movement = GetComponent<PlayerMovement>();
        _movement.Speed = _baseSpeed;
        _source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(!_menu)
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
        if (!Alive) return;

        if (Insanity < _maxInsanity) { Insanity += damage; }
        else { Alive = false; }
    }

    public void Move(Vector3 direction)
    {

        if (direction == Vector3.zero)
        {
            Idle = true;
        }
        else
        {
            Idle = false;
        }

        if (Alive)
            _movement.Move(direction);
    }

    public void Rotate(Vector3 mousePos)
    {
        if (Alive)
            _movement.LookAt(mousePos);
    }

    public void CallDog()
    {
        if (Time.time > _lastDogCall + _dogCallCooldown && Alive)
        {
            _source.PlayOneShot(_dogCalls[0]);
            CalledDog();
            _lastDogCall = Time.time;
        }

    }

    private void Die()
    {
        _movement.Speed = 0;
        _playerDieRef.DieEffect();
    }

    public void Win()
    {
        _movement.Speed = 0;
        _insanityIncreaseRatio = 0;
    }
}
