using UnityEngine;

public class SpeedModifier : MonoBehaviour
{
    private float factor;
    private float duration;
    private float timer;
    private float increase;
    private PlayerMovement movement;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(duration < timer)
        {
            // Set speed back to original and destroy modifier.
            movement.DecreaseSpeed(increase);
            Destroy(this);
        }
    }
    public void Setup(PlayerMovement movement, float factor, float duration)
    {
        this.movement = movement;
        this.factor = factor;
        this.duration = duration;
        increase = movement.IncreaseSpeed(this.factor);
        timer = 0.0f;
    }
}