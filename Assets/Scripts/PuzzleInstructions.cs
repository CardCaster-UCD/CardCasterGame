using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleInstructions : MonoBehaviour
{
    // Reference to the dialogBox gameObject.
    [SerializeField] private GameObject dialogBox;
    // Reference to the Text gameObject that is a child of the dialogBox.
    [SerializeField] private Text dialogText;
    // String representing actual dialog string.
    private string dialog;
    // Boolean representing whether player is in range of the sign, ie in the sign's collider.
    private bool playerInRange;


    // Set the dialog text when game starts.
    void Start()
    {
        dialog = "Don't be afraid to swim. Let the river stream guide you.\nTorches control the rocks. Set them on fire, or turn them off.\nThe rocks will rearrange to support you from the river streams.";
    }

    // Check if player is still in range on update to know whether or not to activate the dialogBox.
    void Update()
    {
        if(playerInRange)
        {
            if(dialogBox.activeInHierarchy == false)
            {
                // If activating, set dialog box's text to the dialog string set in start.
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
        else
        {
            if(dialogBox.activeInHierarchy == true)
            {
                dialogBox.SetActive(false);
            }
        }
    }

    // Check if player enters the sign's trigger collider.
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    // Check if player exits the sign's trigger collider.
    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
