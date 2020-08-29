using UnityEngine;
using UnityEngine.Tilemaps;

public class FallingRock : MonoBehaviour
{
    public float fallingSpeed;
    public bool isFalling;
   

    private void Update()
    {
        if (isFalling)
        {
            transform.Translate(Vector2.up * fallingSpeed * Time.deltaTime * -1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Landing Ground"))
        {
            Destroy(gameObject);
        }
    }
}
