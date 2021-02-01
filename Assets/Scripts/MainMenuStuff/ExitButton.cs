using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    [SerializeField] private float _maxTime = 1;
    private float _currentTime;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_currentTime >= _maxTime)
        {
            print("pasaron " + _currentTime + " segundos");
            _currentTime = 0;
            Application.Quit();
        }
        else
        {
            _currentTime += Time.deltaTime;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _currentTime = 0;
    }
}
