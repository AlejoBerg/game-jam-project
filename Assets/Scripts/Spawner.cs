using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float _insanityPercentage;

    [SerializeField] float _spawnBaseTime;
    [SerializeField] float _spawnDistance;
    [SerializeField] Player _player;
    [SerializeField] GameObject _ghostObject;


    [SerializeField] List<Tranquilizer> _tranquilizers;
    [SerializeField] List<GameObject> _spawnPoints;


    List<Ghost> _ghosts;

    void Start()
    {
        _player.InsanityChanged += ChangedInsanity;
        StartCoroutine(SpawnCycle());
        SpawnTranquilizers();
        _ghosts = new List<Ghost>();
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

        if (_ghosts.Count > 40) return;
        Vector3 pos = GetSpawnPoint();

        while (true)
        {
            if (Vector3.Distance(_player.transform.position, pos) < 2) pos = GetSpawnPoint();
            else break;
        }

        Ghost ghost = Instantiate(_ghostObject, _player.transform.position + pos,transform.rotation).GetComponent<Ghost>();
        ghost.Player = _player;
        _ghosts.Add(ghost);
        ghost.Die += GhostDied;


    }

    Vector3 GetSpawnPoint()
    {
        float rX = Random.Range(-1f, 1f);
        float rY = Random.Range(-1f, 1f);

        Vector3 pos = new Vector3(rX, rY,0) * _spawnDistance;
        return pos;
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

    void GhostDied(Ghost deadGhost)
    {
        _ghosts.Remove(deadGhost);
    }

    void DestroyAllGhost()
    {

        foreach (var ghost in _ghosts.ToArray())
        {
            Destroy(ghost.gameObject);
        }

    }

    public void Deactivate()
    {
        DestroyAllGhost();
        gameObject.SetActive(false);
    }
}
