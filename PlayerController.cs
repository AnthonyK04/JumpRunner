using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 12f;
    private Rigidbody2D rb;
    private bool isGrounded = true;
    public AudioClip jumpSound;
    public AudioClip deathSound;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //checks if space bar is pressed and player is on ground
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
            audioSource.PlayOneShot(jumpSound);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //if player hits the ground, allow them to jump again
        if (col.gameObject.CompareTag("Ground"))
            isGrounded = true;
        //if player hits an obstacle, trigger game over and play deathsound
        if (col.gameObject.CompareTag("Obstacle"))
        {
            audioSource.PlayOneShot(deathSound);
            GameManager.Instance.GameOver();
        }
    }
}