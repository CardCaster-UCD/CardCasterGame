using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utilities;

public class RockController : MonoBehaviour, ITorchSubscriber
{
    private bool isTriggered = false;
    [SerializeField] float fadeInTime;
    [SerializeField] float fadeOutTime;
    [SerializeField] Collider2D compositeCollider;
    [SerializeField] List<GameObject> poofComposites;
    private List<Animator> poofAnimators = new List<Animator>();

    void Start()
    {

        poofComposites.ForEach(poof => poofAnimators.Add(poof.GetComponent<Animator>()));
        this.compositeCollider.enabled = false;       
        StartCoroutine(AnimateRock(1f, FadeOutController.TRANSPARENT));
    }

    IEnumerator AnimateRock(float time, float alpha)
    {
        // Start the poof animation
        poofAnimators.ForEach(animator => animator.SetTrigger("start"));

        yield return this.RunToComplete(
            (
                from renderer in GetComponentsInChildren<SpriteRenderer>()
                where "RockLayer" == renderer.transform.parent.name
                select FadeOutController.FadeTo(renderer, time, alpha)
            ).ToArray()
        );

        // Turn off the poof animation
        poofAnimators.ForEach(animator => animator.SetTrigger("stop"));
    }


    void ToggleRock()
    {
        // This should probbaly locked with a sync primitive 
        if (isTriggered)
        {
            // Diable the rigid body
            compositeCollider.enabled = false;
            // Start he animation
            StartCoroutine(AnimateRock(fadeOutTime, FadeOutController.TRANSPARENT));
            isTriggered = false;
        }
        else
        {

            // Enable the rigid body
            compositeCollider.enabled = true;
            StartCoroutine(AnimateRock(fadeInTime, FadeOutController.OPAQUE));
            isTriggered = true;
        }
    }

    public void OnTorchStateChanged(bool isEnflamed)
    {
        ToggleRock();
    }
}
