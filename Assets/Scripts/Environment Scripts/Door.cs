using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public Animator animator;
    public bool isMoving;
    public float liftSpeed;
    public bool isInteractable;

    private void Update()
    {
        if (isMoving)
        {
            if (transform.position.y < 5.085f)
            {
                transform.Translate(0, liftSpeed * Time.deltaTime, 0);
            }
            else
            {
                isInteractable = true;
                isMoving = false;
                animator.SetBool("isLockOpend", true);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<HeroController>() && isInteractable)
        {
            SceneManager.LoadScene(2);
        }
    }
}
