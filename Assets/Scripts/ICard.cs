using UnityEngine;

public interface ICard
{
    public void Execute(GameObject player);
    public bool GetIsActive();
    public Sprite GetSprite();

}