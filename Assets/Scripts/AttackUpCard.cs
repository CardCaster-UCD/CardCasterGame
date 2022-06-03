using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUpCard : ScriptableObject, ICard
{
    private bool isActive = true;
    private const float factor = 0.35f;
    private const float duration = 5.0f;
    private const float cost = 20;

    // Start is called before the first frame update
    public void Execute(GameObject player)
    {
        var powerup = (GameObject)Resources.Load("Prefabs/power_up", typeof(GameObject));
        AttackModifier modifier = player.AddComponent<AttackModifier>();
        PlayerController player_ctrl = player.GetComponent<PlayerController>();
        modifier.Setup(player_ctrl, factor, duration);
        var _powerup = Instantiate(powerup, player.transform.position, Quaternion.identity);
        _powerup.transform.parent = player.transform;
        Destroy(_powerup, duration);

        isActive = false;
    }

    public bool GetIsActive()
    {
        return isActive;
    }

    public Texture2D GetImage()
    {
        Texture2D image = new Texture2D(2, 2);
        image = Resources.Load("Sprites/Attack_UP_Card") as Texture2D;

        return image;
    }

    public float GetCost()
    {
        return cost;
    }    
    public void SetActive()
    {
        isActive = true;
    }

}
