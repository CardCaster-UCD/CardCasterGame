using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{ 
    [SerializeField] private float damage = 10.0f;
    //[SerializeField] private VectorValue initialPosition;
    [SerializeField] private float health = 100.0f;
    [SerializeField] private Animator animator;
    private Vector2 cur_pos;
    private Vector2 change;
    private GameObject player;
    private Rigidbody2D rigidBody;
    private float damageTimer;
    private float damageBuffer = 0.5f;
    private float selfDamageTimer;
    private float selfDamageBuffer = 0.5f;
    private GameObject whirlwind;

    private void Start()
    {
        this.rigidBody = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        //this.transform.position = this.initialPosition.value;
        this.cur_pos = this.transform.position;
    }

    private void Update()
    {
        damageTimer += Time.deltaTime;
        selfDamageTimer += Time.deltaTime;

        if (this.health <= 0.0f)
        {
            //TODO: play death sound effect
            GameObject.Destroy(this.gameObject);
        }

        if(!whirlwind)
        {
            Vector2 old_pos = cur_pos;
            cur_pos = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
            change = old_pos - cur_pos;

            if (change != Vector2.zero)
            {
                animator.SetBool("wakeup", true);
                UpdateAnimator(change);

            }
            else
            {
                animator.SetBool("wakeup", false);
            }
        }
        else if(whirlwind)
        {
            this.transform.position = whirlwind.transform.position;
        }

    }


    void UpdateAnimator(Vector2 change)
    {
        animator.SetBool("wakeup", true);
        animator.SetFloat("moveX", change.x);
        animator.SetFloat("moveY", change.y);
    }

    public float GetDamage()
    {
        return this.damage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if ("Sword" == other.tag && selfDamageTimer > selfDamageBuffer)
        {
            var sword_ctrl = player.GetComponent<SwordController>();
            var sword_damage = sword_ctrl.GetDamage();
            
            TakeDamage(sword_damage);
        }

        if ("Fire" == other.tag && selfDamageTimer > selfDamageBuffer)
        {
            var fire_damage = other.GetComponent<SpellAttr>().GetDamage();
            TakeDamage(fire_damage);
            other.GetComponent<SpellAttr>()._destroy();
        }

        if ("Player" == other.tag && damageTimer > damageBuffer)
        {
            damageTimer = 0.0f;
            float enemyDamage = GetDamage();
            other.GetComponent<PlayerController>().TakeDamage(enemyDamage);
        }

        if ("Wind" == other.tag)
        {
            whirlwind = other.gameObject;
        }
        
    }

    void TakeDamage(float damage)
    {
        selfDamageTimer = 0.0f;
        //Debug.Log("Taking damage");
        health -= damage;
        //Debug.Log("cur enemy health: " + health.ToString());
    }

}


