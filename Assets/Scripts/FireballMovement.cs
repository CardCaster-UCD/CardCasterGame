using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMovement : MonoBehaviour
{
    Vector2 velocity;

    public void SetVelocity(float x, float y)
    {
        velocity = new Vector2(x, y);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector2(0.0f, 0.0f);
    }
    
    // Update is called once per frame
    void LateUpdate()
    {
        float currentX = this.transform.position.x;
        float currentY = this.transform.position.y;

        float xChange = velocity.x * Time.deltaTime;
        float yChange = velocity.y * Time.deltaTime;

        this.transform.position = new Vector2(currentX + xChange, currentY + yChange);
    }
}
