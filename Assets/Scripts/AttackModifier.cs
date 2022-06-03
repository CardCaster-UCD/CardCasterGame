using UnityEngine;


public class AttackModifier : MonoBehaviour
{

    private float factor;
    private float duration;
    private float timer;
    private float increase;
    private PlayerController player_ctrl;

    void Update()
    {
        timer += Time.deltaTime;

        if (duration < timer)
        {
            player_ctrl.DecreaseAttack(increase);
            Destroy(this);
        }
    }

    public void Setup(PlayerController player_ctrl_arg, float factor, float duration)
    {
        this.player_ctrl = player_ctrl_arg;
        this.factor = factor;
        this.duration = duration;
        increase = player_ctrl.IncreaseAttack(this.factor);
        timer = 0.0f;
    }
    
}

