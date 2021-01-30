using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerMovement _movement;
    float _insanity;
    
    
    [SerializeField] float _baseSpeed;
    [SerializeField] float _maxInsanity;
    [SerializeField] float insanityIncreaseRatio;

    public delegate void OnInsanityChanged(float insanity);
    public event OnInsanityChanged InsanityChanged;

    public float Insanity { get { return _insanity; } set
        { 
            _insanity = value;
            if (_insanity > _maxInsanity) _insanity = _maxInsanity;
            if (_insanity < 0) _insanity = 0;
            InsanityChanged(_insanity); 
        } }

    public float MaxInsanity { get => _maxInsanity; set => _maxInsanity = value; }

    void Start()
    {
        StartCoroutine(IncreaseInsanity());
        _movement = GetComponent<PlayerMovement>();
        _movement.Speed = _baseSpeed;
    }


    IEnumerator IncreaseInsanity()
    {
        while(Insanity < MaxInsanity)
        {
            Insanity += insanityIncreaseRatio;
            yield return new WaitForSeconds(1);
        }
    }

    public float GetInsanityPercentage()
    {
        return Insanity / MaxInsanity;
    }
}
