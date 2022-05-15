// [Ref] https://www.youtube.com/watch?v=--N5IgSUQWI&list=PL4vbr3u7UKWp0iM1WIfRjCDTI03u43Zfu&index=3

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rigidBody;
    private Vector2 change;
    [SerializeField] private Animator animator;
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

        /*Diagonal movement limiter
        if (change.x == 0)
        {
            change.y = Input.GetAxisRaw("Vertical");
        }
        */
        change.y = Input.GetAxisRaw("Vertical");

        this.UpdateAnimator();
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
}
