using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessProperties : MonoBehaviour
{
    private Volume _volume;
    public Vignette vignette;
    public ChannelMixer channelMixer;
    public ColorAdjustments colorAdjustments;
    public ColorCurves colorCurves;
    public WhiteBalance whiteBalance;
    public ShadowsMidtonesHighlights shadowsMidtonesHighlights;
    public FilmGrain filmGrain;
    //los publics de otto

    //ahi vengo voy al super o literalmente no ceno, dejo a otto specteando los publics.
    void Start()
    {
        _volume = GetComponent<Volume>();
        _volume.profile.TryGet(out vignette);
        _volume.profile.TryGet(out channelMixer);
        _volume.profile.TryGet(out colorAdjustments);
        _volume.profile.TryGet(out colorCurves);
        _volume.profile.TryGet(out whiteBalance);
        _volume.profile.TryGet(out shadowsMidtonesHighlights);
        _volume.profile.TryGet(out filmGrain);
    }

    private void Update()
    {
        //_vignette.smoothness.value += Time.deltaTime * 0.1f;
    }
}
