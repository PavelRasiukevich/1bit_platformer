using UnityEngine;


public class FirstAidKit : MonoBehaviour
{
    public Transform[] waypoints;

    public int index;
    public float speed;

    private void Awake()
    {
        index = 0;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[index].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, waypoints[index].position) < 0.01f)
        {
            if (index < waypoints.Length - 1)
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            HeroController heroController = collision.gameObject.GetComponent<HeroController>();

            if (heroController.currentHealth < 3)
            {
                SoundManager.instance.PlayAidKitSound();
                heroController.currentHealth++;
                Destroy(gameObject);
            }
        }
    }

}
