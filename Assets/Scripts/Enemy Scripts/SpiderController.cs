using UnityEngine;

public class SpiderController : MonoBehaviour
{
    [Header("Properties")]
    public float moveSpeed;
    public float moveTime;
    public int direction;
    public float timer;
    public float delta;
    private float triggerTimer;
    public float actionTime;

    [Header("Flags")]
    public bool isTriggered;

    private void Start()
    {
        triggerTimer = actionTime;
        timer = moveTime;
    }

    private void Update()
    {
        if (isTriggered)
        {
            triggerTimer -= Time.deltaTime;

            if (triggerTimer > 0.0f)
            {
                Move();
            }
            else
            {
                isTriggered = false;
                triggerTimer = actionTime;
            }

        }
    }

    private void Move()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            moveSpeed /= delta;
            moveTime *= delta;
            timer = moveTime;
        }

        transform.Translate(0, direction * moveSpeed * Time.deltaTime, 0);
    }
}
