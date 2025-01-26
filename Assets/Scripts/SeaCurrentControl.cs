using UnityEngine;

public class SeaCurrentControl : MonoBehaviour
{
    public Rigidbody2D bubbleRb;
    public float speed = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (bubbleRb.gameObject.activeSelf)
        {
            bubbleRb.linearVelocity = new Vector2(speed + speed / bubbleRb.mass, bubbleRb.linearVelocity.y);
        }
    }
}
