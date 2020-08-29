using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] points;

    public float speed;
    public int index;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, points[index].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, points[index].position) < 0.01f)
        {
            if (index < points.Length - 1)
            {
                index++;
            }
            else
            {
                index = 0;
            }

        }
    }
}
