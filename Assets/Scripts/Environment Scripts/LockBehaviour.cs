using UnityEngine;
using UnityEngine.UI;

public class LockBehaviour : MonoBehaviour
{
    public GameObject keyUI;
    private Image image;
    public Elevator elevator;
    private Color color;
    public Door door;
    

    private void Start()
    {
        image = keyUI.GetComponent<Image>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Hero") && HeroController.instance.isHoldingKey)
        {
            image.sprite = null;
            color = image.color;
            color.a = 0;
            image.color = color;

            if (gameObject.name == "Lock_Elevator")
            {
                elevator.isOn = true;
            }
            else if (gameObject.name == "Lock_Door")
            {
                door.isMoving = true;
            }

            Destroy(gameObject);
        }

    }
}
