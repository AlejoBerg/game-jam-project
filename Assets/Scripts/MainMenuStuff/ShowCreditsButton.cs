using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCreditsButton : MonoBehaviour
{
    [SerializeField] private GameObject[] _creditsStuffToShow;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ActiveCreditsComponents();
    }

    private void ActiveCreditsComponents()
    {
        foreach (var item in _creditsStuffToShow)
        {
            item.SetActive(true);
        }
    }
}
