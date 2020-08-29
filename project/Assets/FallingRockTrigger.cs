using System.Security.Cryptography;
using UnityEngine;

public class FallingRockTrigger : MonoBehaviour
{

    public Transform rock;
    public float fallingSpeed;
    private bool isFalling;
    public float destroyTime;

    private void Update()
    {
        if (isFalling)
        {
            rock.transform.Translate(0, fallingSpeed * Time.deltaTime * -1, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<HeroController>())
        {
            isFalling = true;
            Destroy(rock.gameObject, destroyTime);
        }

    }
}
