using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    Player _player;
    float _maxInsanity;

    [SerializeField] Image _insanityBar;


    void Start()
    {
        _player = GetComponentInParent<Player>();
        _player.InsanityChanged += InsanityChanged;
        _maxInsanity = _player.MaxInsanity;
    }

    void Update()
    {
        
    }

    void InsanityChanged(float newInsanity)
    {
        _insanityBar.fillAmount = newInsanity / _maxInsanity;
    }
}
