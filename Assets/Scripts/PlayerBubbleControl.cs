using UnityEngine;

public class PlayerBubbleControl : MonoBehaviour
{
    public GameObject bubble;
    public BubbleControl bubbleBc;
    public Rigidbody2D rb;

    public GameControl gameControl; // Reference to your GameControl script
    public AudioClip collisionSound; // Assign an audio clip in the Inspector.

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameControl = FindAnyObjectByType<GameControl>(); // Cache GameControl reference
    }

    // Update is called once per frame
    void Update()
    {
        if (bubbleBc.enabled)
        {
            float vertical = Input.GetAxis("Vertical");

            if (Mathf.Abs(vertical) >= 0.0001f)
            {
                bubbleBc.airAmount += vertical / 30f;
            }
        }
    }

    void LateUpdate()
    {
        if (bubble.activeSelf)
        {
            transform.position = new Vector3(bubble.transform.position.x, bubble.transform.position.y, transform.position.z);
        }
        else
        {
            rb.simulated = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameControl.GameOver();
            if (collisionSound)
            {
                AudioSource.PlayClipAtPoint(collisionSound, transform.position, 1.0f);
            }
        }
        if (collision.gameObject.CompareTag("Dimsum"))
        {
            gameControl.GameOver();
            if (collisionSound)
            {
                AudioSource.PlayClipAtPoint(collisionSound, transform.position, 1.0f);
            }
        }
    }
}
