using UnityEngine;

public class PlayerBubbleControl : MonoBehaviour
{
    public GameObject bubble;
    public BubbleControl bubbleBc;
    public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (bubbleBc != null)
        {
            float vertical = Input.GetAxis("Vertical");

            if (Mathf.Abs(vertical) >= 0.0001f)
            {
                bubbleBc.airAmount += vertical / 16f;
            }
        }
    }

    void LateUpdate()
    {
        if (bubble != null)
        {
            transform.position = new Vector3(bubble.transform.position.x, bubble.transform.position.y, transform.position.z);
        }
        else
        {
            rb.simulated = true;
        }
    }
}
