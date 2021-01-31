using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideMenuStuff : MonoBehaviour
{
    [SerializeField] private GameObject[] _creditsStuffToHide;
    [SerializeField] private GameObject[] _creditsStuffToShow;
    [SerializeField] private float _maxTime;
    private float _currentTime;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(_currentTime >= _maxTime)
        {
            print("pasaron " + _currentTime + " segundos");
            _currentTime = 0;
            HideCreditsComponents();
            ShowCreditsComponents();
        }
        else
        {
            _currentTime += Time.deltaTime;
        }
    }

    private void HideCreditsComponents()
    {
        foreach (var item in _creditsStuffToHide)
        {
            item.SetActive(false);
        }
    }

    private void ShowCreditsComponents()
    {
        foreach (var item in _creditsStuffToShow)
        {
            item.SetActive(true);
        }
    }
}
