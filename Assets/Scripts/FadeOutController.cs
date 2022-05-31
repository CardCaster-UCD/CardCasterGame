using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutController : MonoBehaviour
{
    public const float TRANSPARENT = 0;
    public const float OPAQUE = 1;

    [SerializeField] public SpriteRenderer spriteRenderer;
    [SerializeField] public float fadeOutTime;
    [SerializeField] public float fadeInTime;


    // Lerp the alpha of the attached sprite renderer to the targetAlpha over the time specified
    public IEnumerator FadeTo(float time, float targetAlpha)
    {
        yield return FadeOutController.FadeTo(spriteRenderer, time, targetAlpha);
    }
    public static IEnumerator FadeTo(SpriteRenderer spriteRenderer, float time, float targetAlpha)
    {
        float alpha = spriteRenderer.material.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / time)
        {
            Color newColor = spriteRenderer.material.color;
            newColor.a = Mathf.Lerp(alpha, targetAlpha, t);
            spriteRenderer.material.color = newColor;
            yield return null;
        }
    }
    public void FadeToStart(float time, float targetAlpha)
    {
        StartCoroutine(FadeTo(time, targetAlpha));
    }
    public void FadeOutStart()
    {
        StartCoroutine(FadeTo(fadeOutTime, 0));
    }

    public void FadeInStart()
    {
        StartCoroutine(FadeTo(fadeInTime, 1));
    }
}

