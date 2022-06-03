// [Ref] https://www.youtube.com/watch?v=--N5IgSUQWI&list=PL4vbr3u7UKWp0iM1WIfRjCDTI03u43Zfu&index=3

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    [SerializeField] private Animator animator;
    public GameObject healthBar; // instance of the healthbar in the scene
    public GameObject manaBar;
    private HealthBarController healthBarController;
    private HealthBarController manaBarController;
    private float currentHealth = 0.0f;
    private float currentMana = 0.0f;
    private float Health = 100.0f; // max capacity of the health bar
    private float Mana = 100.0f;
    private float Absortion = 1.0f;
    private float SwordDamage = 40.0f;
    private AudioSource cardAudioSource;
    public AudioClip fireball;
    public AudioClip fireStorm;
    public AudioClip speedUp;
    [SerializeField] private float manaRegenRate;
    private float manaRegenTimer;
    private float manaRegenBuffer = .05f;
    
    // Start is called before the first frame update
    void Start()
    {
        
        this.currentHealth = this.Health;
        this.currentMana = this.Mana;
        this.rigidBody = GetComponent<Rigidbody2D>();
    }

    public void init_bars(AsyncOperation Obj)
    {
        this.healthBar = GameObject.FindWithTag("HealthBar");
        this.manaBar = GameObject.FindWithTag("ManaBar");
        this.healthBarController = healthBar.GetComponent<HealthBarController>();
        this.manaBarController = manaBar.GetComponent<HealthBarController>();
        this.healthBarController.initFromPlayer(1);
        this.manaBarController.initFromPlayer(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            this.Heal(40.0f);
        }

        manaRegenTimer += Time.deltaTime;
        if(manaRegenTimer >= manaRegenBuffer)
        {
            RegenMana();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {

        //Debug.Log("Hit");
        if ("Enemy" == other.tag)
        {
            float enemyDamage = other.GetComponent<EnemyController>().GetDamage();
            this.TakeDamage(enemyDamage);
        }
    }
 
    public void Heal(float health)
    {
        
        this.currentHealth += health;
        this.currentHealth = Mathf.Clamp(this.currentHealth, 0.0f, 100.0f);
        this.healthBarController.ChangeValue(this.currentHealth / this.Health);
    }

    void TakeDamage(float damage)
    {
        // this.healthBarController.ChangeValue(this.currentHealth / this.Health);
        float oldHealth = this.currentHealth;
        this.currentHealth -= damage * (1-this.Absortion);

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

    private void RegenMana()
    {
        if(this.currentMana < Mana)
        {
            this.currentMana += manaRegenRate * manaRegenTimer;
            this.currentMana = Mathf.Clamp(this.currentMana, 0.0f, 100.0f);
            this.manaBarController.ChangeValue(this.currentMana / this.Mana);
        }
        manaRegenTimer = 0.0f;
    }

    public void SpendMana(float mana)
    {
        Debug.Log("here!!!");
        float oldMana = this.currentMana;
        this.currentMana -= mana;

        if (this.currentMana < 0.0f)
        {
            this.currentMana = 0.0f;
        }
        if (this.currentMana <= 0.0f && oldMana > 0)
        {
            // TODO: out of mana sound
        }
        else if (this.currentMana > 0)
        {
            // TODO: mana spent sound
        }

        this.manaBarController.ChangeValue(this.currentMana / this.Mana);
    }

    public float GetCurMana()
    {
        return currentMana;
    }


    public float IncreaseAttack(float factor)
    {
        var increase = factor * this.SwordDamage;
        this.SwordDamage += increase;
        return increase;
    }

    public void DecreaseAttack(float increase)
    {

        this.SwordDamage -= increase;

    }

    public void IncreaseAbsortion(float factor)
    {

        this.Absortion += factor;

    }

    public void DecreaseAbsortion(float factor)
    {
        this.Absortion -= factor;
    }

    public float GetSwordDamage()
    {
        return this.SwordDamage;
    }
}
