using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGameButton : MonoBehaviour
{
    [SerializeField] private float _maxTime = 1;
    private float _currentTime;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_currentTime >= _maxTime)
        {
            _currentTime = 0;
            SceneManager.LoadScene(1);
        }
        else
        {
            _currentTime += Time.deltaTime;
        }
    }
}
