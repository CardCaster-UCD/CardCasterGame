using UnityEngine;

public class FireballCard : MonoBehaviour, ICard
{
    private bool isActive = true;
    public void Execute(GameObject player)
    {
        var fireball = (GameObject)Resources.Load("Prefabs/Fireball", typeof(GameObject));
        Instantiate(fireball, player.transform);
        
        // TODO change this to fire in direction player is facing.
        fireball.GetComponent<FireballMovement>().SetVelocity(0.0f, -1.0f);

    }
    public bool GetIsActive()
    {
        return isActive;
    }
    public Sprite GetSprite()
    {
        // TODO get a sprite for this.
        return (Sprite)null; 
    }
}