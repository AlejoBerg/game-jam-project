using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    Vector3 initialPosition;

    private void Awake()
    {
        initialPosition = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.y);
        transform.position += initialPosition;
    }
}
