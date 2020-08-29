using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class HeroController : MonoBehaviour
{
    public static HeroController instance;

    [Header("Stats")]
    public int maxHealth;
    public int currentHealth;

    [Header("Properties")]
    private int jumpsAmmount;
    public int extraJumps;

    public float velocity;
    public float jumpForce;
    public float horizontal;
    public float groundCheckRadius;

    [Header("Flags")]
    public bool isFacingRight;
    public bool isGrounded;
    public bool isHoldingKey;
    public bool isInvulnerable;
    public bool isAlive;

    [Header("UI")]
    public Image healthBarUI;
    private Image healthBar;
    public Sprite[] health;
    public Sprite deathSprite;
    private SpriteRenderer rend;

    [Header("Other")]
    private Rigidbody2D rb;
    public Animator anim;
    public Transform groundCheck;
    public LayerMask groundCheckMask;
    public GameObject deadHeroPrefab;

    [Header("Audio")]
    public AudioClip jumpClip;
    public AudioClip hurtClip;
    public AudioSource source;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        healthBar = healthBarUI.GetComponent<Image>();
        source = GetComponent<AudioSource>();
        isFacingRight = true;
        currentHealth = maxHealth;
        isAlive = true;
    }

    private void FixedUpdate()
    {
        if (isAlive)
        {
            #region Movements
            horizontal = Input.GetAxis("Horizontal");

            rb.velocity = new Vector2(horizontal * Time.deltaTime * velocity, rb.velocity.y);

            anim.SetFloat("MovementVelocity", Mathf.Abs(horizontal));
            #endregion

            #region Flip
            if (horizontal > 0 && isFacingRight == false)
            {
                Flip();
            }
            else if (horizontal < 0 && isFacingRight == true)
            {
                Flip();
            }
            #endregion
        }


    }

    private void Update()
    {
        if (currentHealth > 0)
        {
            healthBar.sprite = health[currentHealth - 1];
        }
        else
        {
            healthBar.gameObject.SetActive(false);
            rend.sprite = deathSprite;
            isAlive = false;
            Instantiate(deadHeroPrefab, transform.position, Quaternion.identity);

            Destroy(gameObject);

        }

        if (isAlive)
        {
            #region Jump

            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundCheckMask);

            if (isGrounded)
            {
                jumpsAmmount = extraJumps;
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.velocity = Vector2.up * jumpForce * Time.deltaTime;
                source.PlayOneShot(jumpClip);
            }

            else if (Input.GetKeyDown(KeyCode.Space) && jumpsAmmount > 0 && !isGrounded)
            {
                rb.velocity = Vector2.up * jumpForce * Time.deltaTime;
                source.Stop();
                source.PlayOneShot(jumpClip);
                jumpsAmmount--;
            }
            #endregion
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Enemy"))
        {
            if (isInvulnerable == false)
            {
                currentHealth--;
                isInvulnerable = true;
                anim.SetBool("isTakingDamage", true);
                source.PlayOneShot(hurtClip);
                StartCoroutine(InvulnerbilityTimer());
            }
        }

        if (collision.gameObject.CompareTag("DeathGround"))
        {
            currentHealth = 0;
        }
    }

    private IEnumerator InvulnerbilityTimer()
    {
        yield return new WaitForSeconds(1.2f);
        isInvulnerable = false;
        anim.SetBool("isTakingDamage", false);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;

        rend.flipX = !isFacingRight;
    }
}
