using UnityEngine;

public interface ICard
{
    public void Execute(GameObject gameObject);
    public bool GetIsActive();
    public Sprite GetSprite();

}