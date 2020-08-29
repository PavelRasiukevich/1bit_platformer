using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform hero;

    public float yMin, yMax;
    public float xMin, xMax;

    void Start()
    {

    }

    private void Update()
    {

        if (hero != null)
        {
            float y = Mathf.Clamp(hero.position.y, yMin, yMax);
            float x = Mathf.Clamp(hero.position.x, xMin, xMax);

            transform.position = new Vector3(x, y, transform.position.z);
        }
    }
}

