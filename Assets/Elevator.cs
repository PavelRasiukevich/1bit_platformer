using System;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public bool isOn;
    public float speed;

    private void Update()
    {
        if (isOn)
        {
            Lift();
        }
    }

    private void Lift()
    {
        if (transform.position.y < 3.42f)
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        else
        {
            isOn = false;
        }

    }

}
