// [Ref] https://youtu.be/p6Klz_NZpEQ

using UnityEngine;

public class SwordController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Swing");
        }
    }
}
