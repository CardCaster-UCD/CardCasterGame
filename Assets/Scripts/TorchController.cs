using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
public class TorchController : MonoBehaviour
{
    [SerializeField] float fadeoutTime;
    [SerializeField] float fadeinTime;
    [SerializeField] FadeOutController torchFadeOut;
    [SerializeField] List<GameObject> boulders;
    private SpriteRenderer fireRenderer;
    private DefaultDictionary<string, bool> destroyableObjects = new DefaultDictionary<string, bool>
    {
        {"Fire", true},
        {"Wind", true},
        {"Sword", false},
    };

    private HashSet<Action<bool>> subscribers = new HashSet<Action<bool>>();
    [SerializeField] private bool enflamedOnStart;
    private bool isEnflamed;
    void Start()
    {
        Action torchSetup = () =>
        {
            var childRenderers = from child in GetComponentsInChildren<SpriteRenderer>()
                                 where "fire" == child.gameObject.name
                                 select child;
            childRenderers.ToList().ForEach(child =>
            {
                fireRenderer = child;

                // Set the initial alpha to 0
                var preservedColor = fireRenderer.material.color;
                preservedColor.a = 0;
                fireRenderer.material.color = preservedColor;
            });
            torchFadeOut.spriteRenderer = fireRenderer;
            torchFadeOut.fadeOutTime = fadeoutTime;
            torchFadeOut.fadeInTime = fadeinTime;
        };

        Action subscribersSetUp = () =>
        {
            if (null == this.boulders) throw new NullReferenceException("Torch exists without linked objects to affect");

            boulders.ForEach(boulder =>
            {
                var controller = boulder.GetComponent<RockController>();
                this.Subscribe(controller.OnTorchStateChanged);
            });
        };

        torchSetup();
        subscribersSetUp();
        this.isEnflamed = enflamedOnStart;
        if (enflamedOnStart)
        {
            torchFadeOut.FadeInStart();
            Notify();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        switch (other.gameObject.tag)
        {
            case "Wind":
            case "Sword":
                if (this.isEnflamed)
                {
                    torchFadeOut.FadeOutStart();
                    this.isEnflamed = false;
                    Notify();
                }
                break;
            case "Fire":
                if (!this.isEnflamed)
                {
                    torchFadeOut.FadeInStart();
                    this.isEnflamed = true;
                    Notify();
                }
                break;
        }
        if (destroyableObjects[other.gameObject.tag])
        {
            Destroy(other.gameObject);
        }
    }

    public void Subscribe(Action<bool> action)
    {
        subscribers.Add(action);
    }

    public void Unsubscribe(Action<bool> action)
    {
        subscribers.Remove(action);
    }

    private void Notify()
    {
        foreach (var subscriber in subscribers)
        {
            subscriber(isEnflamed);
        }
    }
}

