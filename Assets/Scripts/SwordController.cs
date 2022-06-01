// [Ref] https://youtu.be/p6Klz_NZpEQ

using UnityEngine;

public class SwordController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float reswingDelay;
    private float reswingTimer;
    private GameObject player;
    
    void start()
    {
        // Ensure no delay for first swing.
        reswingTimer = reswingDelay;
        player = GameObject.FindWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        reswingTimer += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Space) && reswingTimer > reswingDelay && !animator.GetBool("Swim"))
        {
            animator.SetTrigger("Swing");
            reswingTimer = 0.0f;
        }
    }
}
