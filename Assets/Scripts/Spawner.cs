using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float _insanityPercentage;

    [SerializeField] float _spawnBaseTime;
    [SerializeField] Player _player;
    [SerializeField] GameObject _ghostObject;


    [SerializeField] List<Tranquilizer> _tranquilizers;
    [SerializeField] List<GameObject> _spawnPoints;

    void Start()
    {
        _player.InsanityChanged += ChangedInsanity;
        StartCoroutine(SpawnCycle());
        SpawnTranquilizers();
    }


    IEnumerator SpawnCycle()
    {
        while (true)
        {
            float secsToSpawn = _spawnBaseTime - _spawnBaseTime * _insanityPercentage;
            yield return new WaitForSeconds(secsToSpawn);
            SpawnEnemy();
        }

    }

    void SpawnEnemy()
    {
        Debug.LogError("Spawnie");
    }

    void SpawnTranquilizers()
    {
        for (int i = 0; i < _tranquilizers.Count; i++)
        {
            int spawnIndex = Random.Range(0, _spawnPoints.Count);
            Instantiate(_tranquilizers[i], _spawnPoints[spawnIndex].transform.position,transform.rotation); 
            _spawnPoints.RemoveAt(spawnIndex);
        }
    }


    void ChangedInsanity(float newInsanity)
    {
        _insanityPercentage = _player.GetInsanityPercentage();
    }
}
