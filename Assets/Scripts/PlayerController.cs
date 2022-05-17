// [Ref] https://www.youtube.com/watch?v=--N5IgSUQWI&list=PL4vbr3u7UKWp0iM1WIfRjCDTI03u43Zfu&index=3

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rigidBody;
    private Vector2 change;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject healthBar; // instance of the healthbar in the scene
    private HealthBarController healthBarController;
    private float currentCapacity = 0.0f;
    private float capacity = 100.0f;


    // Start is called before the first frame update
    void Start()
    {
        this.rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector2.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        this.UpdateAnimator();
    }

    void OnTriggerEnter(Collider other)
    {
        if ("projectile" == other.tag)
        {
            TakeDamage();
        }
    }

    void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + change * speed * Time.fixedDeltaTime);
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
    
    void TakeDamage()
    {
        this.healthBarController.ChangeValue(this.currentCapacity / this.capacity)
    }
        

}
