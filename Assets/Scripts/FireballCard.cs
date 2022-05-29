using UnityEngine;

public class FireballCard : ScriptableObject, ICard
{
    private bool isActive = true;
    private const float speed = 6.0f;
    private const float lifetime = 5.0f;
    public void Execute(GameObject player)
    {
        var fireball = (GameObject)Resources.Load("Prefabs/Fireball", typeof(GameObject));
        
        // TODO decide out how to handle diagonal
        float xVelocity = player.GetComponent<PlayerMovement>().GetFacing().x * speed;
        float yVelocity = player.GetComponent<PlayerMovement>().GetFacing().y * speed;

        fireball.GetComponent<SpellMovement>().SetVelocity(xVelocity, yVelocity);

        Destroy(Instantiate(fireball, player.transform.position, Quaternion.identity), lifetime);

    }
    public bool GetIsActive()
    {
        return isActive;
    }
    public Texture2D GetImage()
    {
        // TODO get a sprite for this.
        return (Texture2D)null; 
    }
}