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

        // Play audio
        var playerControllerScript = player.GetComponent<PlayerController>();
        var fireStormAudio = playerControllerScript.fireStorm;
        var AudioSource = player.GetComponent<AudioSource>();
        AudioSource.PlayOneShot(fireStormAudio);

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
        image = Resources.Load("Sprites/FireStorm_Card") as Texture2D;

        return image; 
    }

    public void SetActive()
    {
        isActive = true;
    }
}