using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraControl
{

    public class RoomTransition : MonoBehaviour
    {
        // Max position of the camera in the new room
        [SerializeField] private Vector2 cameraMaxPosition;
        // Min position of the camera in the new room
        [SerializeField] private Vector2 cameraMinPosition;
        // The offset into the room we need to put the player 
        // so that they dont trigger the second collider
        [SerializeField] private Vector2 playerOffset;

        private BasicCameraController cameraController;

        [SerializeField] bool switchHands;
        private float buffer = 0.5f;
        private float timer;

        // Start is called before the first frame update
        void Start()
        {
            this.cameraController = Camera.main.GetComponent<BasicCameraController>();
        }

        // Update is called once per frame
        void Update()
        {
            timer += Time.deltaTime;
        }

        // On colliding with a player object
        // Update the camera to the new limits of the room
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log(playerOffset);
            if (other.tag == "Player" && timer > buffer)
            {
                timer = 0.0f;
                this.cameraController.maxPosition = this.cameraMaxPosition;
                this.cameraController.minPosition = this.cameraMinPosition;
                other.transform.position += new Vector3(
                    this.playerOffset.x,
                    this.playerOffset.y,
                    0
                );
            
                if(switchHands)
                {
                var UIdoc = GameObject.FindWithTag("UIDoc");
                
                if(UIdoc.GetComponent<HandController>().enabled)
                {
                    UIdoc.GetComponent<HandController>().enabled = false;
                    UIdoc.GetComponent<PuzzleHandController>().enabled = true;
                }
                else
                {
                    UIdoc.GetComponent<PuzzleHandController>().enabled = false;
                    UIdoc.GetComponent<HandController>().enabled = true;
                }
                }
            }
        }
    }
}