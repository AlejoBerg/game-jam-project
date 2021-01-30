using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentController : MonoBehaviour
{
    [SerializeField] SpriteRenderer fogRenderer;
    private MaterialPropertyBlock fogBlock;
    [SerializeField] Player playerRef;

    [SerializeField] PostProcessProperties postProcessPropertiesRef;
    private void Start()
    {
        fogBlock = new MaterialPropertyBlock();
        fogRenderer.GetPropertyBlock(fogBlock);
        //fogBlock.SetFloat("_Speed", 99);
        fogRenderer.SetPropertyBlock(fogBlock);
        //fogRenderer.material.SetFloat("Speed", 99);
    }

    private void Update()
    {
        postProcessPropertiesRef.filmGrain.intensity.value = (playerRef.Insanity / 100) + 0.1f;
    }
}
