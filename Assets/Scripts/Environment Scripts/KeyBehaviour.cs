using UnityEngine;
using UnityEngine.UI;

public class KeyBehaviour : MonoBehaviour
{
    public GameObject keyUI;
    private Image image;
    public Sprite sprite;

    private void Start()
    {
        image = keyUI.GetComponent<Image>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Hero"))
        {

            Destroy(gameObject);
            SoundManager.instance.PlayKeyPickUpSound();
            image.sprite = sprite;
            image.color = gameObject.GetComponent<SpriteRenderer>().color;
            HeroController.instance.isHoldingKey = true;

        }
    }
}
