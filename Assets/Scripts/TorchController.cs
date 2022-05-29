using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
public class TorchController : MonoBehaviour
{
    [SerializeField] float fadeoutTime;
    [SerializeField] float fadeinTime;
    [SerializeField] FadeOutController torchFadeOut;
    private SpriteRenderer fireRenderer;
    private DefaultDictionary<string, bool> destroyableObjects = new DefaultDictionary<string, bool>
    {
        {"Fire", true},
        {"Wind", true},
        {"Sword", false},
    };

    private List<Action> subscribers = new List<Action>();
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
        torchFadeOut.spriteRenderer = fireRenderer;
        torchFadeOut.fadeOutTime = fadeoutTime;
        torchFadeOut.fadeInTime = fadeinTime;
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        switch (other.gameObject.tag)
        {
            case "Wind":
            case "Sword":
                torchFadeOut.FadeOutStart();
                break;
            case "Fire":
                torchFadeOut.FadeInStart();
                break;
        }
        if (destroyableObjects[other.gameObject.tag])
        {
            Destroy(other.gameObject);
        }
    }

    public void Subscribe(Action action)
    {
        subscribers.Add(action);
    }

    public void Unsubscribe(Action action)
    {
        subscribers.Remove(action);
    }

    private void Notify()
    {
        this.subscribers.ForEach(action => action());
    }
}

