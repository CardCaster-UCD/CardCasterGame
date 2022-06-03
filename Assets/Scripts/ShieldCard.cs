using UnityEngine;


class ShieldCard : ScriptableObject, ICard
{

    private bool isActive = true;
    private const float absortion = 0.3f;
    private const float lifetime = 5.0f;
    private const float cost = 15.0f;
    public void Execute(GameObject player)
    {
        GameObject shield = (GameObject)  Resources.Load("Prefabs/Shield", typeof(GameObject));

        PlayerController player_ctrl = player.GetComponent<PlayerController>();
        HealthModifier modifier = player.AddComponent<HealthModifier>();
        modifier.Setup(player_ctrl, absortion, lifetime);

        // get shield transform
        GameObject shield_ins = Instantiate(shield, player.transform.position, Quaternion.identity);
        // make shield child of player. This will keep shield attached to the player
        shield_ins.transform.parent = player.transform;

        // setup shield position
        var shield_trans = shield_ins.transform;
        var new_pos = shield_trans.position;
        new_pos.x += 0.3f;
        new_pos.y -= 0.3f;
        shield_ins.transform.position = new_pos;

        // destroy after lifetime
        Destroy(shield_ins, lifetime);

        isActive = false;
    }
    public bool GetIsActive()
    {
        return isActive;
    }
    public Texture2D GetImage()
    {
        // Size here doesn't matter
        // https://docs.unity3d.com/530/Documentation/ScriptReference/Texture2D.LoadImage.html
        Texture2D image = new Texture2D(2, 2);
        image = Resources.Load("Sprites/Shield_Card") as Texture2D;

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
