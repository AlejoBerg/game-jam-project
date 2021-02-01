using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tranquilizer : MonoBehaviour
{
    [SerializeField] private AudioSource _pickSFX;
    [SerializeField] private SpriteRenderer _renderer;

    float _minValue = 0.2f;
    float _maxValue = 0.1f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player)
        {
            _pickSFX.Play();
            player.Insanity -= Random.Range(_minValue, _maxValue);
            _renderer.enabled = false;
            Destroy(this.gameObject, 2f);
        }
    }
}
