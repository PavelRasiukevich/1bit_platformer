using System.Collections;
using UnityEngine;

public class HeroSoul : MonoBehaviour
{
    public float speed;
    public int direction = 1;
    private float timer;

    private void Start()
    {
        timer = 0.5f;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer > 0)
        {
            transform.Translate(speed * Time.deltaTime * direction, Time.deltaTime * speed, 0);
        }
        else
        {
            direction = -direction;
            timer = 0.5f;
        }


        StartCoroutine(Terminate());
    }

    private IEnumerator Terminate()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }
}
