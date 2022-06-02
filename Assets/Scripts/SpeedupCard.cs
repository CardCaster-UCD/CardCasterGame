using UnityEngine;

public class SpeedupCard : ScriptableObject, ICard
{
    private bool isActive = true;
    // Increase speed by 50% if set to 0.5f.
    private const float factor = 0.5f;
    private const float duration = 10;
    private const float cost = 15.0f;

    public void Execute(GameObject player)
    {
        var modifier = player.AddComponent<SpeedModifier>() as SpeedModifier;
        var movement = player.GetComponent<PlayerMovement>();
        modifier.Setup(movement, factor, duration);

        // Play audio
        var playerControllerScript = player.GetComponent<PlayerController>();
        var speedUpAudio = playerControllerScript.speedUp;
        var AudioSource = player.GetComponent<AudioSource>();
        AudioSource.PlayOneShot(speedUpAudio);

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
        image = Resources.Load("Sprites/Speed_UP_Card") as Texture2D;

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