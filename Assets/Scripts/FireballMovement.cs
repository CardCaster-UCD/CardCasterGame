using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMovement : MonoBehaviour
{
    [SerializeField] private Vector2 velocity;

    public void SetVelocity(float x, float y)
    {
        this.velocity = new Vector2(x, y);
    }
    
    // Update is called once per frame
    void LateUpdate()
    {
        float currentX = this.transform.position.x;
        float currentY = this.transform.position.y;
        float currentZ = this.transform.position.z;

        float xChange = velocity.x * Time.deltaTime;
        float yChange = velocity.y * Time.deltaTime;

        this.transform.position = new Vector3(currentX + xChange, currentY + yChange, currentZ);
    }
}
