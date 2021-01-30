using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tranquilizer : MonoBehaviour
{
    float _minValue = 20;
    float _maxValue = 50;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player)
        {
            player.Insanity -= Random.Range(_minValue, _maxValue);
            Destroy(this.gameObject);
        }
    }
}