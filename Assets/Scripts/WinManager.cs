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
        print("Wof wof... aqui estoy ganaste");
        _canSpawn = false;

        _backToMenu.SetActive(true);
    }
}
