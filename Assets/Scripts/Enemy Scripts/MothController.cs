using System;
using System.Linq;
using UnityEngine;

public class MothController : MonoBehaviour
{
    public Transform[] waypoints;

    public float speed;
    private int index;
    public bool isReversed;

    private void Start()
    {
        index = 0;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[index].position, speed * Time.deltaTime);

        if (isReversed)
        {
            if (Vector2.Distance(transform.position, waypoints[index].position) < 0.01f)
            {
                if (index < waypoints.Length - 1)
                {
                    index++;
                }
                else
                {
                    Array.Reverse(waypoints);
                    index = 0;
                }

            }
        }


        if (!isReversed)
        {
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
    }
}
