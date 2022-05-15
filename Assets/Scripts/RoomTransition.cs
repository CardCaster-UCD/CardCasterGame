using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomTransition : MonoBehaviour
{
    [SerializeField] private Vector2 cameraMinPosition;
    [SerializeField] private Vector2 cameraMaxPosition;

    private BasicCameraController cameraController;

    // Start is called before the first frame update
    void Start()
    {
        this.cameraController = Camera.main.GetComponent<BasicCameraController>();
    }

    // On colliding with a player object
    // Update the camera to the new limits of the room
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            this.cameraController.maxPosition = this.cameraMaxPosition;
            this.cameraController.minPosition = this.cameraMinPosition;
        }
    }
}
