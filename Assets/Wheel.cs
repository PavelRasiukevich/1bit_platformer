using UnityEngine;

public class Wheel : MonoBehaviour
{
    public float spinningSpeed;
    private int direction = 1;
    public bool isReversed;

    private void Start()
    {
        if (isReversed)
        {
            direction = -direction;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Hero"))
        {
            //rigidbody2D.velocity = new Vector2(spinningSpeed * Time.deltaTime * direction, rigidbody2D.velocity.y);
            collision.gameObject.transform.Translate(Vector2.right * spinningSpeed * Time.deltaTime * direction);
        }

        Debug.Log("Connected");


    }
}
