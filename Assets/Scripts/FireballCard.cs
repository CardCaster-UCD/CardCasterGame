using UnityEngine;

public class FireballCard : ScriptableObject, ICard
{
    private bool isActive = true;
    private const float speed = 6.0f;
    private const float lifetime = 5.0f;
    private const float cost = 15.0f;
    public void Execute(GameObject player)
    {
        var fireball = (GameObject)Resources.Load("Prefabs/Fireball", typeof(GameObject));
        
        // TODO decide out how to handle diagonal
        float xVelocity = player.GetComponent<PlayerMovement>().GetFacing().x * speed;
        float yVelocity = player.GetComponent<PlayerMovement>().GetFacing().y * speed;

        fireball.GetComponent<SpellMovement>().SetVelocity(xVelocity, yVelocity);

        Destroy(Instantiate(fireball, player.transform.position, Quaternion.identity), lifetime);

        // Switch out card.
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
        image = Resources.Load("Sprites/Fireball_Card") as Texture2D;

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