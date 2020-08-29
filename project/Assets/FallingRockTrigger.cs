using UnityEngine;

public class FallingRockTrigger : MonoBehaviour
{
    public FallingRock rock;
    public Transform landingGround;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<HeroController>())
        {
            rock.isFalling = true;
            rock.gameObject.AddComponent<Rigidbody2D>();
            landingGround.SetParent(null);
            gameObject.transform.SetParent(null);
            Destroy(gameObject);
            
        }

    }
}
