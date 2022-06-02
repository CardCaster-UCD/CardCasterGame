using UnityEngine;


public class SpellAttr : MonoBehaviour
{

    [SerializeField] private float damage;

    public float GetDamage()
    {
        return damage;
    }

    public void _destroy()
    {
        Destroy(this.gameObject);
    }
}

