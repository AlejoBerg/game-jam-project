using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerDieCinematic : MonoBehaviour
{
    [SerializeField] private GameObject[] _flashLightsEntities;
    [SerializeField] private AudioSource _flashLightAudiosource;
    [SerializeField] private GameObject _globalLight;
    [SerializeField] private GameObject _insanityHud;
    [SerializeField] private Spawner _spawnerRef;
    [SerializeField] private AudioSource _daySFX;
    [SerializeField] private GameObject _winText;
    [SerializeField] private GameObject _looseText;

    [SerializeField] private CanvasGroup _blackImageFade;
    [SerializeField] private float _showPlayerDeadDelay;
    [SerializeField] EnviromentController _enviromentControllerRef;

    [SerializeField] GameObject backToMenu;

    private float _multiplier = 10;

    public void DieEffect()
    {
        StartCoroutine(FadeOut());
        FlashLightFlickering();
    }

    private void FlashLightFlickering()
    {
        _flashLightAudiosource.Play();
        StartCoroutine(DelayTurnOfFlashlight());        
    }

    IEnumerator FadeOut()
    {
        while (_blackImageFade.alpha != 1)
        {
            print("el alpha es = " + _blackImageFade.alpha);
            _blackImageFade.alpha += 0.33f * Time.deltaTime;
            yield return new WaitForSeconds(0.001f);
        }

        StartCoroutine(ShowDeadPlayer());
    }
    
    IEnumerator FadeIn()
    {
        while (_blackImageFade.alpha != 0)
        {
            print("el alpha es = " + _blackImageFade.alpha);
            _blackImageFade.alpha -= 0.33f * Time.deltaTime;
            yield return new WaitForSeconds(0.001f);
        }

        StartCoroutine(ShowDeadPlayer());
    }

    IEnumerator ShowDeadPlayer()
    {
        yield return new WaitForSeconds(_showPlayerDeadDelay);
        StartCoroutine(FadeIn());
        _looseText.SetActive(true);
        _globalLight.SetActive(true);
        backToMenu.SetActive(true);
        this.GetComponent<SpriteRenderer>().enabled = false;
        _spawnerRef.Deactivate();
        _insanityHud.SetActive(false);
        _flashLightAudiosource.mute = true;

        _daySFX.Play();
        _enviromentControllerRef.Day();
    }

    IEnumerator DelayTurnOfFlashlight()
    {
        yield return new WaitForSeconds(1f);

        foreach (var item in _flashLightsEntities)
        {
            item.SetActive(false);
        }
    }
}
