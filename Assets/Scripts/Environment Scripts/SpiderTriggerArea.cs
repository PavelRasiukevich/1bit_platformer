using System.Collections;
using UnityEngine;

public class SpiderTriggerArea : MonoBehaviour
{
    public SpiderController spider;
    public bool isInteractable;

    private float refreshSpeed;
    private float refreshMoveTime;

    private void Start()
    {
        refreshSpeed = spider.moveSpeed;
        refreshMoveTime = spider.moveTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            if (!isInteractable)
            {
                spider.isTriggered = true;
                isInteractable = !isInteractable;
                StartCoroutine(Timer());
            }
        }
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(5.0f);
        spider.moveSpeed = refreshSpeed;
        spider.moveTime = refreshMoveTime;
        spider.timer = spider.moveTime;
        isInteractable = !isInteractable;
    }
}
