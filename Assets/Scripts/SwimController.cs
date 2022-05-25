using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private bool playerInWater;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInWater)
        {   
            if(animator.GetBool("Swim") == false)
            {
                animator.SetBool("Swim", true);
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
        if(collider.CompareTag("Player"))
        {
            playerInWater = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            playerInWater = false;
        }
    }
}
