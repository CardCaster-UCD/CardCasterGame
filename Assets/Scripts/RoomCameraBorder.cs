using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace CameraControl
{
    public enum Direction
    {
        Top,
        Bottom,
        Left,
        Right
    }
    public class RoomCameraBorder : MonoBehaviour
    {
        [SerializeField] public Direction direction;
        private BasicCameraController cameraController;
        private Vector2 cameraSizeOffset;
        void Start()
        {
            var camera = Camera.main;
            this.cameraController = camera.GetComponent<BasicCameraController>();
            // Determine the dimensions of the camera
            var height = camera.orthographicSize;
            var width = height * camera.aspect;
            this.cameraSizeOffset = new Vector2(
                width,
                height
            );
        }

        // When the camera interacts with the world border
        // Update the camera min and max positions to the border +- the camera size offset
        void OnTriggerEnter2D(Collider2D other)
        {
            if ("MainCamera" == other.tag)
            {
                switch (this.direction)
                {
                    case Direction.Top:
                        this.cameraController.maxPosition.y = this.transform.position.y - this.cameraSizeOffset.y;
                        break;
                    case Direction.Bottom:
                        this.cameraController.minPosition.y = this.transform.position.y + this.cameraSizeOffset.y;
                        break;
                    case Direction.Left:
                        this.cameraController.minPosition.x = this.transform.position.x + this.cameraSizeOffset.x;
                        break;
                    case Direction.Right:
                        this.cameraController.maxPosition.x = this.transform.position.x - this.cameraSizeOffset.x;
                        break;
                }
            }
        }
    }
}