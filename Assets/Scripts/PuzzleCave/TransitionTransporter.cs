using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionTransporter : MonoBehaviour
{
    [SerializeField] public GameObject target;
    void OnTriggerEnter2D(Collider2D other)
    {
        if ("Player" == other.tag)
        {
            DoTransitionAnimation();
            other.transform.position = new Vector3(
                target.transform.position.x,
                target.transform.position.y,
                other.transform.position.z
            );
        }
    }

    void DoTransitionAnimation()
    {
        Debug.Log("Transition animation not implemented yet ");
    }
}
