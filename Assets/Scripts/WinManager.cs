using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{

    bool _canSpawn;

    [SerializeField] Player _player;

    [SerializeField] List<AudioClip> _dogBarks;
    [SerializeField] AudioSource _source;
    void Start()
    {
        _player.CalledDog += DogCalled;

        Invoke("EnableDogSpawn", 10);
    }

    void DogCalled()
    {
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
    }
}
