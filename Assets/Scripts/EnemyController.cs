using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{ 
    [SerializeField] private float damage = 30.0f;
    [SerializeField] private VectorValue initialPosition;
    private Rigidbody2D rigidBody;

    private void Start()
    {
        this.rigidBody = GetComponent<Rigidbody2D>();

        this.transform.position = this.initialPosition.value;
    }

    public float GetDamage()
    {
        return this.damage;
    }

}


