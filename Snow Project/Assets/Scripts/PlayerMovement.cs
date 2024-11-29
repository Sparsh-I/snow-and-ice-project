using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Jump")]
    [SerializeField] private float fixedXPosition;
    [SerializeField] private float jumpForce;
    
    [Header("Rotation")]
    private Quaternion originalRotation;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float returnSpeed;

    [Header("GroundChecks")]
    [SerializeField] private bool isGrounded;
    [SerializeField] private Transform groundCheck; // Assign a small empty GameObject below the player
    [SerializeField] private float groundCheckRadius = 0.5f;
    [SerializeField] private LayerMask groundLayer; // Assign "Ground" layer to ground objects
    
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(fixedXPosition, transform.position.y, transform.position.z);
        isGrounded = IsGrounded();

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Rotate(0f, 0f, Time.deltaTime * rotationSpeed * 100f);
            rb.velocity = new Vector2(0, rb.velocity.y + jumpForce);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, Time.deltaTime * returnSpeed);
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            GameManager.Instance.GameOver();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
    
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
}
