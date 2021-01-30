using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Camera _camera;

    [SerializeField] Transform _followObject;
    void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        if (_followObject) _camera.transform.position = _followObject.position + new Vector3(0, 0, -10);
    }
}
