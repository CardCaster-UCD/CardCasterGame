using UnityEngine;

public class FireStormCard : ScriptableObject, ICard
{
    private bool isActive = true;
    private const float speed = 5.0f;
    private const int totalFireBalls = 36;
    private const float lifetime = 5.0f;
    public void Execute(GameObject player)
    {
        var fireball = (GameObject)Resources.Load("Prefabs/Fireball", typeof(GameObject));
        
        for ( int i = 0; i < totalFireBalls; i++)
        {

            var radian = i * 10 * Mathf.Deg2Rad;

            var xPos = Mathf.Cos(radian);
            var yPos = Mathf.Sin(radian);

            float xVelocity = xPos * speed;
            float yVelocity = yPos * speed;

            fireball.GetComponent<SpellMovement>().SetVelocity(xVelocity, yVelocity);

            Destroy(Instantiate(fireball, player.transform.position, Quaternion.identity), lifetime);

        }

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