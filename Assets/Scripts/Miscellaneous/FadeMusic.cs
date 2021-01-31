using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeMusic : MonoBehaviour
{
    [SerializeField] private AudioSource _rainSFX;
    [SerializeField] private float _fadeDuration = 1;
    [SerializeField] private float _targetVolume = 1;
    [SerializeField] private bool _playOnAwake = false;

    private float _startVolume = 0;
    private float _currentFadeTime = 0;

    private void Awake()
    {
        if(_playOnAwake == true)
        {
            StartCoroutine(DoFade());
        }
    }

    IEnumerator DoFade()
    {
        _startVolume = _rainSFX.volume;
        _rainSFX.Play();

        while (_currentFadeTime < _fadeDuration)
        {
            _currentFadeTime += Time.deltaTime;
            _rainSFX.volume = Mathf.Lerp(_startVolume, _targetVolume, _currentFadeTime / _fadeDuration);
            yield return new WaitForSeconds(0.4f);
        }
    }
}
