using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
public class TorchController : MonoBehaviour
{
    [SerializeField] float fadeoutTime;
    [SerializeField] float fadeinTime;
    private SpriteRenderer fireRenderer;
    private DefaultDictionary<string, bool> destroyableObjects = new DefaultDictionary<string, bool>
    {
        {"Fire", true},
        {"Wind", true},
        {"Sword", false},
    };
    void Start()
    {
        foreach (var child in GetComponentsInChildren<SpriteRenderer>())
        {
            if (child.gameObject.name == "fire")
            {
                fireRenderer = child;

                // Set the initial alpha to 0
                var preservedColor = fireRenderer.material.color;
                preservedColor.a = 0;
                fireRenderer.material.color = preservedColor;
            }
        }
    }

    IEnumerator FadeTo(float time, float targetAlpha)
    {
        float alpha = fireRenderer.material.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / time)
        {
            Color newColor = fireRenderer.material.color;
            newColor.a = Mathf.Lerp(alpha, targetAlpha, t);
            fireRenderer.material.color = newColor;
            yield return null;
        }
    }


    void FadeOutStart()
    {
        StartCoroutine(FadeTo(fadeoutTime, 0));
    }

    void FadeInStart()
    {
        StartCoroutine(FadeTo(fadeinTime, 1));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        switch (other.gameObject.tag)
        {
            case "Wind":
            case "Sword":
                this.FadeOutStart();
                break;
            case "Fire":
                this.FadeInStart();
                break;
        }
        if (destroyableObjects[other.gameObject.tag])
        {
            // Destroy(other.gameObject);
        } 
    }
}

