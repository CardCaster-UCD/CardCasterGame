using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
public class BasicCameraController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Transform target;
    [SerializeField] float smoothing;

    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.position != target.position)
        {
            var newPos = Vector3.Lerp(
                transform.position.ToVector2(),
                target.position.ToVector2(),
                smoothing
            );
            transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
        }
    }
}
