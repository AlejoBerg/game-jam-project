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
    [SerializeField] AudioSource insanityAudio2;

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

        //Debug.Log(Input.mousePosition.x / Screen.width);
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

        insanityAudio.volume = playerRef.Insanity * 0.40f;
        insanityAudio2.volume = playerRef.Insanity * 0.25f;
    }

    private void TimeEffects()
    {
        float dividedTimer = globalTimer.Timer / globalTimer.maxTime;
        postProcessPropertiesRef.whiteBalance.temperature.value = 0 - Mathf.Lerp(0, 30, globalTimer.Timer / globalTimer.maxTime);
        var emission = rain.emission;
        emission.rateOverTime = 100 + globalTimer.Timer;
        emission = backgroundRain.emission;
        emission.rateOverTime = dividedTimer * 0.25f;

        initialRainAudio.volume = Mathf.Clamp((0.25f + dividedTimer) / (playerRef.Insanity + 1), 0.25f, 0.5f);
        heavyRainAudio.volume = Mathf.Clamp(-0.25f + dividedTimer / (playerRef.Insanity + 1), 0, 0.5f);
    }

    public void Day()
    {
        fogRenderer.GetPropertyBlock(fogBlock);
        fogBlock.SetFloat("_Intensity", 0.0f);
        fogRenderer.SetPropertyBlock(fogBlock);

        rain.gameObject.SetActive(false);
        backgroundRain.gameObject.SetActive(false);
        postProcessPropertiesRef.filmGrain.intensity.value = 0;
        postProcessPropertiesRef.vignette.intensity.value = 0.3f;
        postProcessPropertiesRef.vignette.smoothness.value = 0.5f;
        postProcessPropertiesRef.whiteBalance.temperature.value = 10;

        initialRainAudio.volume = 0;
        heavyRainAudio.volume = 0;
        insanityAudio.volume = 0;
        insanityAudio2.volume = 0;

        this.gameObject.SetActive(false);
    }
}
