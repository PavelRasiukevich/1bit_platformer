using UnityEngine;

public class FallingRock : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<FallingRockTrigger>())
        {
            Destroy(gameObject);
        }
    }
}
