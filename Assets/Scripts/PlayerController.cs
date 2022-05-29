// [Ref] https://www.youtube.com/watch?v=--N5IgSUQWI&list=PL4vbr3u7UKWp0iM1WIfRjCDTI03u43Zfu&index=3

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rigidBody;
    public Vector2 change;
    public bool moving;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject healthBar; // instance of the healthbar in the scene
    [SerializeField] private GameObject manaBar;
    private HealthBarController healthBarController;
    private HealthBarController manaBarController;
    private float currentHealth = 0.0f;
    private float Health = 100.0f; // max capacity of the health bar


    // Start is called before the first frame update
    void Start()
    {
        healthBarController = healthBar.GetComponent<HealthBarController>();
        manaBarController = manaBar.GetComponent<HealthBarController>();
        this.healthBarController.initFromPlayer(1);
        this.manaBarController.initFromPlayer(1);
        this.currentHealth = this.Health;
        this.rigidBody = GetComponent<Rigidbody2D>();
        if (this.rigidBody == null)
            Debug.LogError("no rigid body!");
    }

    // Update is called once per frame
    void Update()
    {
        
        change = Vector2.zero;
        
        change.x = Input.GetAxisRaw("Horizontal");

        /*Diagonal movement limiter
        if (change.x == 0)
        {
            change.y = Input.GetAxisRaw("Vertical");
        }
        */
        change.y = Input.GetAxisRaw("Vertical");
        
        // Don't update animator if no movement has occured.
        // This allows us to stay in the previous idle state.
        if(change != Vector2.zero)
        {
            UpdateAnimator();
        }
        else
        {
            // Tell the animator that we are not moving.
            // Can't just call UpdateAnimator() because that changes
            // Horizontal and vertical
            animator.SetFloat("Speed", change.sqrMagnitude);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            this.Heal(40.0f);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if ("Enemy" == other.tag)
        {
            float enemyDamage = other.GetComponent<EnemyController>().GetDamage();
            this.TakeDamage(enemyDamage);
        }
    }

    void FixedUpdate()
    {
        
        this.rigidBody.MovePosition(rigidBody.position + change * speed * Time.fixedDeltaTime);
    }

    void UpdateAnimator()
    {
        animator.SetFloat("Horizontal", change.x);
        animator.SetFloat("Vertical", change.y);
        animator.SetFloat("Speed", change.sqrMagnitude);
    }
    void MoveCharacter()
    {
        this.rigidBody.MovePosition(
            rigidBody.position + (change * speed * Time.deltaTime).normalized
        );
    }
    
    void Heal(float health)
    {
        
        this.currentHealth += health;
        this.currentHealth = Mathf.Clamp(this.currentHealth, 0.0f, 100.0f);
        this.healthBarController.ChangeValue(this.currentHealth / this.Health);
    }

    void TakeDamage(float damage)
    {
        // this.healthBarController.ChangeValue(this.currentHealth / this.Health);
        float oldHealth = this.currentHealth;
        this.currentHealth -= damage;

        if (this.currentHealth < 0.0f)
        {
            this.currentHealth = 0.0f;
        }
        if (this.currentHealth <= 0.0f && oldHealth > 0)
        { 
            // TODO: die sound effect or action
        }
        else if (this.currentHealth > 0)
        {
            // TODO: damage taken sound
        }

        this.healthBarController.ChangeValue(this.currentHealth / this.Health);

    }
        

}
