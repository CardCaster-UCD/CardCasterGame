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
        if (this.health <= 0.0f)
        {
            //TODO: play death sound effect
            GameObject.Destroy(this.gameObject);
        }

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
        if ("Sword" == other.tag)
        {
            var sword_ctrl = player.GetComponent<SwordController>();
            var damage = sword_ctrl.GetDamage();
            TakeDamage(damage);
        }

        if ("Fire" == other.tag)
        {
            var fire_damage = other.GetComponent<SpellAttr>().GetDamage();
            TakeDamage(damage);
            other.GetComponent<SpellAttr>()._destroy();
        }

        if ("Player" == other.tag && damageTimer > damageBuffer)
        {
            damageTimer = 0.0f;
            float enemyDamage = GetDamage();
            other.GetComponent<PlayerController>().TakeDamage(enemyDamage);
        }
        
    }

    void TakeDamage(float damage)
    {
        Debug.Log("Taking damage");
        health -= damage;
        Debug.Log("cur enemy health: " + health.ToString());
    }

}


