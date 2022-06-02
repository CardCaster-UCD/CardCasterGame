using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private bool playerInWater = false;

    private float horizontal;
    private float vertical;


    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if(playerInWater)
        {
            if(animator.GetBool("Swim") == false)
            {
                animator.SetBool("Swim", true);
            }
            if((Input.GetAxisRaw("Horizontal") == 0) && (Input.GetAxisRaw("Vertical") == 0))
            {
                Debug.Log("enter the if statement");
                //Vector2 velocity = this.gameObject.GetComponent<Rigidbody2D>().velocity;
                //Debug.Log(velocity);
                animator.SetFloat("Horizontal", horizontal);
                animator.SetFloat("Vertical", vertical);
            }
        }
        else
        {
            if(animator.GetBool("Swim") == true)
            {
                animator.SetBool("Swim", false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Water"))
        {
            playerInWater = true;
        }
        if(collider.CompareTag("WaterPushUp"))
        {
            vertical = 1.0f;
        }
        else if(collider.CompareTag("WaterPushDown"))
        {
            vertical = -1.0f;
        }
        else if(collider.CompareTag("WaterPushLeft"))
        {
            horizontal = -1.0f;
        }
        else if(collider.CompareTag("WaterPushRight"))
        {
            horizontal = 1.0f;
        }
    }

    // When collider exits the BoxCollider
    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.CompareTag("Water"))
        {
            playerInWater = false;
        }
        if(collider.CompareTag("WaterPushUp"))
        {
            vertical = 0.0f;
        }
        else if(collider.CompareTag("WaterPushDown"))
        {
            vertical = 0.0f;
        }
        else if(collider.CompareTag("WaterPushLeft"))
        {
            horizontal = 0.0f;
        }
        else if(collider.CompareTag("WaterPushRight"))
        {
            horizontal = 0.0f;
        }
    }
}
