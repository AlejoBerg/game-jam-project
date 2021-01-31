using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalTimer : MonoBehaviour
{
    float timer;
    public float maxTime;

    public float Timer { get => timer; set => timer = value; }

    void Update()
    {
        Timer += Time.deltaTime;
    }
}
