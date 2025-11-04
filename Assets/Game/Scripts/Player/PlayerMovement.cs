using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 7f;
    private bool shouldJump = false;

    private Rigidbody2D rb;
    public bool isGrounded;
    [SerializeField] GroundCheck groundCheck;

    private void Awake() => rb = GetComponent<Rigidbody2D>();

    public void Move(float direction)
    {
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
    }

    public void Jump()
    {
        isGrounded = groundCheck.Check();
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
    public void Stand()
    {
        rb.velocity = new Vector2(0f,rb.velocity.y);
    }
}
