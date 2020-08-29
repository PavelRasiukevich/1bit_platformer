using UnityEngine;

public class LiftUpPlatform : MonoBehaviour
{
    public Transform platform;
    public float speed;
    private bool isTrigerred;

    private void Update()
    {
        if (isTrigerred)
        {
            platform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            isTrigerred = true;
        }
    }
}
