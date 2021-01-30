using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public CameraFollow cameraFollowRef;
    public Transform playerTransform;

    private void Start()
    {
        cameraFollowRef.Setup(() => playerTransform.position);
    }
}
