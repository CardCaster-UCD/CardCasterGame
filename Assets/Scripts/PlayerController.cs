// [Ref] https://www.youtube.com/watch?v=--N5IgSUQWI&list=PL4vbr3u7UKWp0iM1WIfRjCDTI03u43Zfu&index=3

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private AudioSource audio;
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
    private float Absortion;
    private float SwordDamage = 40.0f;
    private AudioSource cardAudioSource;
    public AudioClip fireball;
    public AudioClip fireStorm;
    public AudioClip speedUp;
    public AudioClip grunt;
    [SerializeField] private float manaRegenRate;
    private float manaRegenTimer;
    private float manaRegenBuffer = .05f;
    private bool alive = true;
    
    // Start is called before the first frame update
    void Start()
    {
        this.audio = GameObject.FindWithTag("Player").GetComponent<AudioSource>();
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
        manaRegenTimer += Time.deltaTime;
        if(manaRegenTimer >= manaRegenBuffer)
        {
            RegenMana();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("Hit");
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
        this.currentHealth -= damage * (1-this.Absortion);

        if (this.currentHealth < 0.0f)
        {
            this.currentHealth = 0.0f;
        }
        if (this.currentHealth <= 0.0f && alive)
        { 
            alive = false;
            RestartGame();
        }
        else if (this.currentHealth > 0)
        {
            // Play damage sound at half volume
            audio.PlayOneShot(grunt, 0.5f);
        }

        this.healthBarController.ChangeValue(this.currentHealth / this.Health);

    }

    private void RestartGame()
    {
        SceneManager.LoadSceneAsync("StartMenu", LoadSceneMode.Single);
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
        float oldMana = this.currentMana;
        this.currentMana -= mana;

        if (this.currentMana < 0.0f)
        {
            this.currentMana = 0.0f;
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
