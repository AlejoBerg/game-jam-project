using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float _insanityPercentage;

    [SerializeField] float _spawnBaseTime;
    [SerializeField] Player _player;
    [SerializeField] GameObject _ghostObject;


    void Start()
    {
        _player.InsanityChanged += ChangedInsanity;
        StartCoroutine(SpawnCycle());
    }


    IEnumerator SpawnCycle()
    {
        while (true)
        {
            float secsToSpawn = _spawnBaseTime - _spawnBaseTime * _insanityPercentage;
            yield return new WaitForSeconds(secsToSpawn);
            Spawn();
        }

    }

    void Spawn()
    {
        Debug.LogError("Spawnie");
    }

    void ChangedInsanity(float newInsanity)
    {
        _insanityPercentage = _player.GetInsanityPercentage();
    }
}
