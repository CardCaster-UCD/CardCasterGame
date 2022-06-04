using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleInstructions : MonoBehaviour
{
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private Text dialogText;
    private string dialog;
    private bool playerInRange;
    // Start is called before the first frame update
    void Start()
    {
        dialog = "Go for a swim, and allow the river streams to guide you to your destination. It could be good, bad, or both! Be sure to use the rocks as support as the current is very strong! You may find it helpful to practice with this torch here on the side. Each torch controls a set of rocks. Good luck!";
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange)
        {
            if(dialogBox.activeInHierarchy == false)
            {
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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
