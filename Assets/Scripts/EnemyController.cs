using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{ 
    [SerializeField] private float damage = 30.0f;

    public float GetDamage()
    {
        return this.damage;
    }

}


