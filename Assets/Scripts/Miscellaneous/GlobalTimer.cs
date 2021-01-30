using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalTime : MonoBehaviour
{
    float timer;

    void Update()
    {
        timer += Time.deltaTime;
    }
}
