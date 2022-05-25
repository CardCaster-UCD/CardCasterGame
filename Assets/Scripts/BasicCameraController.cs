using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace CameraControl
{
    public class BasicCameraController : MonoBehaviour
    {
        // Start is called before the first frame update

        [SerializeField] Transform target;
        [SerializeField] float smoothing;

        [SerializeField] public Vector2 maxPosition;
        [SerializeField] public Vector2 minPosition;

        void Start()
        {
            transform.position = new Vector3(
                Mathf.Clamp(target.position.x, minPosition.x, maxPosition.x),
                Mathf.Clamp(target.position.y, minPosition.y, maxPosition.y),
                transform.position.z
            );
        }

        void LateUpdate()
        {
            if (transform.position.ToVector2() != target.position.ToVector2())
            {
                var newPos = Vector3.Lerp(
                    transform.position.ToVector2(),
                    target.position.ToVector2(),
                    smoothing
                );
                newPos.x = Mathf.Clamp(newPos.x, minPosition.x, maxPosition.x);
                newPos.y = Mathf.Clamp(newPos.y, minPosition.y, maxPosition.y);
                transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
            }
        }
    }
}