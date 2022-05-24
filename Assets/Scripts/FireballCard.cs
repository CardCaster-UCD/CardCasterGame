using UnityEngine;

public class FireballCard : ScriptableObject, ICard
{
    private bool isActive = true;
    private float speed = 5.0f;
    public void Execute(GameObject player)
    {
        var fireball = (GameObject)Resources.Load("Prefabs/Fireball", typeof(GameObject));
        
        // TODO decide out how to handle diagonal
        float xVelocity = player.GetComponent<PlayerMovement>().GetFacing().x * speed;
        float yVelocity = player.GetComponent<PlayerMovement>().GetFacing().y * speed;

        fireball.GetComponent<FireballMovement>().SetVelocity(xVelocity, yVelocity);

        Destroy(Instantiate(fireball, player.transform.position, Quaternion.identity), 15f);

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