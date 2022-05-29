using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutController : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float fadeOutTime;
    [SerializeField] float fadeInTime;


    // Lerp the alpha of the attached sprite renderer to the targetAlpha over the time specified
    IEnumerator FadeTo(float time, float targetAlpha)
    {
        float alpha = this.spriteRenderer.material.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / time)
        {
            Color newColor = this.spriteRenderer.material.color;
            newColor.a = Mathf.Lerp(alpha, targetAlpha, t);
            this.spriteRenderer.material.color = newColor;
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
