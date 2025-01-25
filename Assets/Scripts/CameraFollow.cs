using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTf;
    public Transform seaTf;

    private float _offsetX;
    private float _cameraRightLimit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _offsetX = transform.position.x - playerTf.position.x;
        _cameraRightLimit = seaTf.localScale.x - GetComponent<Camera>().orthographicSize / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(playerTf.position.x + _offsetX, 0, _cameraRightLimit - 15.5f), transform.position.y, transform.position.z);
    }
}
