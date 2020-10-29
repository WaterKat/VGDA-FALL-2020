using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInFadeOut : MonoBehaviour
{
    [SerializeField]
    private Color solidColor = Color.black;
    [SerializeField]
    private Color openedColor = Color.clear;
    
    private float deltaColor = 0f;

    [SerializeField]
    private float fadeTime = 1f;

    [SerializeField]
    private Image image;

    private Coroutine coroutine;

    public void StartFadeIn()
    {
        if (coroutine != null)
            StopCoroutine(coroutine);
        coroutine = StartCoroutine(FadeIn());
    }

    public void StartFadeOut()
    {
        if (coroutine != null)
            StopCoroutine(coroutine);
        coroutine = StartCoroutine(FadeOut());
    }

    IEnumerator FadeIn()
    {
        float timeElapsed = 0f;
        
        while (timeElapsed < fadeTime)
        {
            timeElapsed += Time.deltaTime;

            deltaColor += (Time.deltaTime / fadeTime);
            image.color = Color.Lerp(solidColor, openedColor, deltaColor);

            yield return null;
        }

        deltaColor = 1;
        image.color = Color.Lerp(solidColor, openedColor, deltaColor);
    }

    IEnumerator FadeOut()
    {
        float timeElapsed = 0f;

        while (timeElapsed < fadeTime)
        {
            timeElapsed += Time.deltaTime;

            deltaColor -= (Time.deltaTime / fadeTime);
            image.color = Color.Lerp(solidColor, openedColor, deltaColor);

            yield return null;
        }

        deltaColor = 0;
        image.color = Color.Lerp(solidColor, openedColor, deltaColor);
    }
}
