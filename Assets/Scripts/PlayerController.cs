using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Adjust the speed of the player character

    private Animator animator;
    private Rigidbody2D rb;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized;
        rb.velocity = movement * moveSpeed;

        // Set the animator bools based on the movement direction
        animator.SetBool("runLeft", moveHorizontal < 0);
        animator.SetBool("runRight", moveHorizontal > 0);
        animator.SetBool("runDown", moveVertical < 0);
        animator.SetBool("runUp", moveVertical > 0);

        // Set the idle animation if there's no movement
        if (movement == Vector2.zero)
        {
            animator.SetBool("runLeft", false);
            animator.SetBool("runRight", false);
            animator.SetBool("runDown", false);
            animator.SetBool("runUp", false);
        }
    }
}
