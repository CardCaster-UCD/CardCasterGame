// [Ref] https://youtu.be/p6Klz_NZpEQ

using UnityEngine;

public class SwordController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float reswingDelay;
    private float reswingTimer;
    private GameObject player;
    private float damage;
    
    void Start()
    {
        // Ensure no delay for first swing.
        player = GameObject.FindWithTag("Player");
        damage = player.GetComponent<PlayerController>().GetSwordDamage();
        reswingTimer = reswingDelay;
        
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

    public float GetDamage()
    {
        return this.damage;
    }
}
