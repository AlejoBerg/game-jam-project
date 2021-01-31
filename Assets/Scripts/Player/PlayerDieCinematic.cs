using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerDieCinematic : MonoBehaviour
{
    [SerializeField] private GameObject[] _flashLightsEntities;
    [SerializeField] private AudioSource _flashLightAudiosource;

    [SerializeField] private CanvasGroup _blackImageFade;
    [SerializeField] private float _showPlayerDeadDelay;
    [SerializeField] EnviromentController _enviromentControllerRef;

    [SerializeField] GameObject backToMenu;

    private float _multiplier = 10;

    public void DieEffect()
    {
        FlashLightFlickering();
        Fade();
        StartCoroutine(ShowDeadPlayer());
    }

    private void FlashLightFlickering()
    {
        _flashLightAudiosource.Play();
        StartCoroutine(DelayTurnOfFlashlight());        
    }

    private void Fade(int endAlpha = 1)
    {
        _blackImageFade.alpha = Mathf.Lerp(_blackImageFade.alpha, endAlpha, 0.003f);
    }

    IEnumerator ShowDeadPlayer()
    {
        yield return new WaitForSeconds(_showPlayerDeadDelay);
        Fade(0);
        backToMenu.SetActive(true);
        //_enviromentControllerRef.Day();
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
