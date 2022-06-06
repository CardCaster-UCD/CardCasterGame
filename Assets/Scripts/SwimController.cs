using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimController : MonoBehaviour
{
    // Reference to the animator on the player.
    [SerializeField] private Animator animator;
    // Boolean representing whether or not the player is in the water.
    private bool playerInWater = false;
    // Horizontal and vertical values used when there is no player input.
    private float horizontal;
    private float vertical;


    // Check to see if playerInWater is true.
    void Update()
    {
        if(playerInWater)
        {
            // If player in water and the Swim bool in the animator not set to true, set animator to true.
            if(animator.GetBool("Swim") == false)
            {
                animator.SetBool("Swim", true);
            }
            // Check if there is any player input.
            // If there is no player input, set horizontal and vertical "input" according to which water they are in.
            // This makes them continuously get taken by the river even if they are not using any keys.
            if((Input.GetAxisRaw("Horizontal") == 0) && (Input.GetAxisRaw("Vertical") == 0))
            {
                animator.SetFloat("Horizontal", horizontal);
                animator.SetFloat("Vertical", vertical);
            }
        }
        else
        {
            // If player is not in water, set Swim bool to false.
            if(animator.GetBool("Swim") == true)
            {
                animator.SetBool("Swim", false);
            }
        }
    }

    // Check if water entered player's trigger collider.
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Hitting any water sets playerInWater to true.
        if(collider.CompareTag("Water"))
        {
            playerInWater = true;
        }
        // Hitting specific streams adjusts the vertical and horizontal automatic movement to direction
        // of stream they are in and sets the vertical and horizontal values accordingly.
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

    // When collider exits the BoxCollider.
    // Checking here if water exits player's trigger BoxCollider.
    private void OnTriggerExit2D(Collider2D collider)
    {
        // Leaving any water sets playerInWater to false.
        if(collider.CompareTag("Water"))
        {
            playerInWater = false;
        }
        // Leaving any specific stream of water sets the horizontal and vertical default movement to 0.
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
