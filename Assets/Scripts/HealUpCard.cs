using UnityEngine;
class HealUpCard : ScriptableObject, ICard
{
    private bool isActive = true;
    private const float Health = 20.0f;
    private float duration = 0.75f; // from the healthBarController
    private const float cost = 15.0f;
    public void Execute(GameObject player)
    {
        var healing = (GameObject)Resources.Load("Prefabs/Healing", typeof(GameObject));
        PlayerController player_ctrl = player.GetComponent<PlayerController>();
        player_ctrl.Heal(Health);
        var _healing = Instantiate(healing, player.transform.position, Quaternion.identity);
        _healing.transform.parent = player.transform;
        Destroy(_healing, duration);

        isActive = false;

    }

    public bool GetIsActive()
    {
        return isActive;
    }

    public Texture2D GetImage()
    {
        Texture2D image = new Texture2D(2, 2);
        image = Resources.Load("Sprites/HealingCard") as Texture2D;

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

