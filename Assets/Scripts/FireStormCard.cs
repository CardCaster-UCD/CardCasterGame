using UnityEngine;

public class FireStormCard : ScriptableObject, ICard
{
    private bool isActive = true;
    private float speed = 5.0f;
    private int toatalFireBalls = 36;
    public void Execute(GameObject player)
    {
        var fireball = (GameObject)Resources.Load("Prefabs/Fireball", typeof(GameObject));
        
        for ( int i = 0; i < toatalSpikes; i++)
        {

            var radian = i * 10 * Mathf.Deg2Rad;

            var xPos = Mathf.Cos(radian);
            var yPos = Mathf.Sin(radian);

            float xVelocity = xPos * speed;
            float yVelocity = yPos * speed;

            fireball.GetComponent<FireballMovement>().SetVelocity(xVelocity, yVelocity);

            Destroy(Instantiate(fireball, player.transform.position, Quaternion.identity), 15f);

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