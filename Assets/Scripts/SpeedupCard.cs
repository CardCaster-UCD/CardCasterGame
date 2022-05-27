using UnityEngine;

public class SpeedupCard : ScriptableObject, ICard
{
    private bool isActive = true;
    // Increase speed by 50% if set to 0.5f.
    private const float factor = 0.5f;
    private const float duration = 10;
    public void Execute(GameObject player)
    {
        var modifier = player.AddComponent<SpeedModifier>() as SpeedModifier;
        var movement = player.GetComponent<PlayerMovement>();
        modifier.Setup(movement, factor, duration);
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