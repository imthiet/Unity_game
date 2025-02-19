using UnityEngine;

public class New_script : MonoBehaviour
{
    [SerializeField]

    private float jumpForce = 16f;
    private Rigidbody2D rb;
    private bool isGrounded;

    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private float groundCheckRadius = 0.2f;

    [SerializeField]
    private LayerMask groundLayer;


    private Animator anima;
    [SerializeField]
    private BoxCollider2D normalCollider;

    [SerializeField]
    private CapsuleCollider2D duckCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();

        normalCollider.enabled = true;
        duckCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = CheckIfGrounded();
        HandleJump();
        HandleDuck();
        HandleSoundEffect();
    }


    private bool CheckIfGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = Vector2.up * jumpForce;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.linearVelocity = Vector2.up * jumpForce;
        }
    }

    private void HandleDuck()

    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            normalCollider.enabled = false;
            duckCollider.enabled = true;

            anima.SetBool("isDuck", true);
        }

        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            normalCollider.enabled = true;
            duckCollider.enabled = false;

            anima.SetBool("isDuck", false);

        }
    }

    private void HandleSoundEffect()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            audio_manager.instance.PlayJumpClip();
        }

        if (isGrounded && !audio_manager.instance.HasPlayAudio())
        {
            audio_manager.instance.PlayTabClip();
            audio_manager.instance.setHasPlayAudio(true);
            ;
        }

        else if (isGrounded)
        {
            audio_manager.instance.setHasPlayAudio(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            audio_manager.instance.PlayhurtClip();
        }
    }



}
