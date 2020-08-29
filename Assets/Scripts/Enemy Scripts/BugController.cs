using UnityEngine;

public class BugController : MonoBehaviour
{
    [Header("Properties")]
    public float moveSpeed;
    public float moveTime;
    public int direction;
    private float timer;

    [Header("Animation")]
    public Animator animator;

    [Header("Flags")]
    public bool isAlive;

    private void Start()
    {
        timer = moveTime;
        //direction = 1;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (isAlive)
        {
            if (timer < 0)
            {
                direction = -direction;
                timer = moveTime;
            }

            transform.Translate(direction * moveSpeed * Time.deltaTime, 0, 0);
        }

    }
    //TEST
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.CompareTag("Hero"))
        {
            Debug.Log("DETECTED");
            animator.SetBool("isDead", true);
            isAlive = false;
        }*/
    }

}

