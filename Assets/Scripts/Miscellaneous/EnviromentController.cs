using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentController : MonoBehaviour
{
    [SerializeField] SpriteRenderer fogRenderer;
    private MaterialPropertyBlock fogBlock;
    [SerializeField] Player playerRef;
    [SerializeField] GlobalTimer globalTimer;
    [SerializeField] ParticleSystem rain;
    [SerializeField] ParticleSystem backgroundRain;

    [SerializeField] PostProcessProperties postProcessPropertiesRef;

    [SerializeField] AudioSource initialRainAudio;
    [SerializeField] AudioSource heavyRainAudio;
    [SerializeField] AudioSource insanityAudio;
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
        InsanityEffects();
        TimeEffects();
    }

    private void InsanityEffects()
    {
        postProcessPropertiesRef.filmGrain.intensity.value = playerRef.Insanity + 0.1f;
        postProcessPropertiesRef.vignette.intensity.value = 0.4f + (playerRef.Insanity * 0.6f);
        postProcessPropertiesRef.vignette.smoothness.value = 0.6f + (playerRef.Insanity * 0.4f);
        fogRenderer.GetPropertyBlock(fogBlock);
        //fogBlock.SetFloat("_NoiseScale", 50 + playerRef.Insanity * 450);
        fogBlock.SetFloat("_Intensity", 0.2f + playerRef.Insanity * 0.8f);
        fogRenderer.SetPropertyBlock(fogBlock);

    }
    private void TimeEffects()
    {
        postProcessPropertiesRef.whiteBalance.temperature.value = 0 - Mathf.Lerp(0,30,globalTimer.Timer/globalTimer.maxTime);
        var emission = rain.emission;
        emission.rateOverTime = 100 + (globalTimer.Timer / 2);
        emission = backgroundRain.emission;
        emission.rateOverTime = globalTimer.Timer * 0.25f;
    }
}
