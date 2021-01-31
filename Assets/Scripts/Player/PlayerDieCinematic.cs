using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerDieCinematic : MonoBehaviour
{
    [SerializeField] private Light2D[] _flashLightsRef;
    [SerializeField] private CanvasGroup _blackImageFade;
    [SerializeField] private float _showPlayerDeadDelay;
    [SerializeField] EnviromentController _enviromentControllerRef;

    private float _multiplier = 10;

    public void DieEffect()
    {
        FlashLightFlickering();
        Fade();
        StartCoroutine(ShowDeadPlayer());
    }

    private void FlashLightFlickering()
    {
        if(_multiplier > 0)
        {
            foreach (var item in _flashLightsRef)
            {
                item.intensity = Mathf.RoundToInt(Mathf.Abs(Mathf.Sin(Time.time * _multiplier)));
                _multiplier -= Time.deltaTime;
            }
        }
        else
        {
            foreach (var item in _flashLightsRef)
            {
                item.intensity = 0;
            }
        }
    }

    private void Fade(int endAlpha = 1)
    {
        _blackImageFade.alpha = Mathf.Lerp(_blackImageFade.alpha, endAlpha, 0.003f);
    }

    IEnumerator ShowDeadPlayer()
    {
        yield return new WaitForSeconds(_showPlayerDeadDelay);
        Fade(0);
        //_enviromentControllerRef.Day();
    }
}
