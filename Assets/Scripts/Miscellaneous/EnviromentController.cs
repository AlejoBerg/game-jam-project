using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentController : MonoBehaviour
{
    [SerializeField] SpriteRenderer fogRenderer;
    private MaterialPropertyBlock fogBlock;
    private void Start()
    {
        fogBlock = new MaterialPropertyBlock();
        fogRenderer.GetPropertyBlock(fogBlock);
        //fogBlock.SetFloat("_Speed", 99);
        fogRenderer.SetPropertyBlock(fogBlock);
        //fogRenderer.material.SetFloat("Speed", 99);
    }

    
}
