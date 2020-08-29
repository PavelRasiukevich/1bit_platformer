using UnityEngine;

public class Char_2Test : MonoBehaviour
{
    public Transform destination;
    public float maxDistance;

    public Rigidbody2D rigidbody2d;
    public bool isGrounded;
    private int jumpsAmmount;
    public int extraJumps;
    public float jumpForce;
    public float distanceBetweenCharacters;


    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundCheckMask;

    private void Update()
    {
        if (destination != null)
        {
            if (Vector2.Distance(transform.position, destination.position) >= distanceBetweenCharacters)
                transform.position = Vector2.MoveTowards(transform.position, destination.position, maxDistance * Time.deltaTime);

            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundCheckMask);

            if (isGrounded)
            {
                jumpsAmmount = extraJumps;
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rigidbody2d.velocity = Vector2.up * jumpForce * Time.deltaTime;

            }

            else if (Input.GetKeyDown(KeyCode.Space) && jumpsAmmount > 0 && !isGrounded)
            {
                rigidbody2d.velocity = Vector2.up * jumpForce * Time.deltaTime;

                jumpsAmmount--;
            }

        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            destination = collision.gameObject.GetComponent<Transform>();
        }
    }


}
