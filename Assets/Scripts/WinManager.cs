using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{

    bool _canSpawn;

    [SerializeField] float _timeToWin;
    [SerializeField] Player _player;
    [SerializeField] GameObject _backToMenu;
    [SerializeField] List<AudioClip> _dogBarks;
    [SerializeField] AudioSource _source;
    [SerializeField] EnviromentController _enviromentControllerRef;
    [SerializeField] private GameObject _winText;

    [SerializeField] GameObject _dogRef;

    [SerializeField] Spawner _spawner;

    void Start()
    {
        _player.CalledDog += DogCalled;

        Invoke("EnableDogSpawn", _timeToWin);
    }

    void DogCalled()
    {
        _source.PlayOneShot(_dogBarks[Random.Range(0, _dogBarks.Count)]);
        if (_canSpawn)
        {
            SpawnDog();
        }
    }

    void EnableDogSpawn()
    {
        _canSpawn = true;
    }

    void SpawnDog()
    {
        Vector2 newPos = _player.transform.position - _player.transform.up + new Vector3(-2, -2, 0);
        _dogRef.transform.position = newPos;
        _dogRef.SetActive(true);

        _canSpawn = false;
        _backToMenu.SetActive(true);

        _spawner.Deactivate();
        _player.Win();
        _winText.SetActive(true);
        _enviromentControllerRef.Day();
    }

}
