using System;
using UnityEngine;
using UnityEngine.UI;

class HealthBarController : MonoBehaviour
{
    [SerializeField] private float value;
    [SerializeField] private AnimationCurve valueTransitionCurve;
    [SerializeField] GameObject surfaceObject;
    private float transitionStartTime = 0f;
    private float valueTransitionTime = 0.75f;
    private float ratioAtStart = 0.0f;
    private float currentRatio = 0.0f;
    private RectTransform valueSurface;

    // Function takes new ratio.
    // The main idea of the function is that the transition surface catches up to the value surface
    public void initFromPlayer(float initHealth)
    {
        this.currentRatio = initHealth;
        this.value = initHealth;
        this.ratioAtStart = initHealth;
        this.valueSurface = surfaceObject.GetComponent<RectTransform>();
     
    }

    public void ChangeValue(float targetRatio)
    {
        targetRatio = Mathf.Clamp(targetRatio, 0.0f, 1.0f);
        this.transitionStartTime = Time.time;
        this.ratioAtStart = this.currentRatio;
        this.value = targetRatio;

    }

    void Update()
    {
        // if transition time has not been met yet
        if ((Time.time - this.transitionStartTime) < this.valueTransitionTime)
        {
            if (this.value > this.ratioAtStart)
            {
                //bar fills
                //transition bar is behind and longer than value bar
                //value bar grows to match transition ba
                var growRange = this.value - this.ratioAtStart;
                var ratioOfTimeDone = (Time.time - this.transitionStartTime + 0.00001f) / this.valueTransitionTime;
                var ratioOfTransition = growRange * this.valueTransitionCurve.Evaluate(ratioOfTimeDone);
                this.SetLocalScaleX(this.ratioAtStart + ratioOfTransition);
                this.currentRatio = this.ratioAtStart + ratioOfTransition;
            }
            else if (this.value < this.ratioAtStart)
            {
                //bar empties
                //transition bar is behind and longer than value bar
                //transition bar shrinks to match value bar 
                //this.ValueSurface.transform.localScale = 0.01f;
                var growRange = this.ratioAtStart - this.value;
                var ratioOfTimeDone = ((Time.time - this.transitionStartTime) / this.valueTransitionTime);
                var ratioOfTransition = growRange * this.valueTransitionCurve.Evaluate(ratioOfTimeDone);
                this.SetLocalScaleX(this.ratioAtStart - ratioOfTransition);
                this.currentRatio = this.ratioAtStart - ratioOfTransition;
            }
        
        }
    }

    private void SetLocalScaleX(float value)
    {
        
        var localScale = valueSurface.transform.localScale;
        localScale.x = value;
        valueSurface.transform.localScale = localScale;
    }


}


