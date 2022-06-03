using UnityEngine;

class HealthModifier : MonoBehaviour
{

    private float factor;
    private float duration;
    private float timer;
    private PlayerController player_ctrl;

    void update()
    {
        timer += Time.deltaTime;

        if (duration < timer)
        {
            player_ctrl.DecreaseAbsortion(this.factor);
            Destroy(this);
        } 
    }

    public void Setup(PlayerController player_ctrl_arg, float factor, float duration)
    {
        this.player_ctrl = player_ctrl_arg;
        this.factor = factor;
        this.duration = duration;
        player_ctrl.IncreaseAbsortion(this.factor);
        timer = 0.0f;
    }


}

