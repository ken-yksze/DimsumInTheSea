using UnityEngine;

public class BubbleControl : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;

    public delegate void OnAirAmountChanged(float airAmount);
    public static event OnAirAmountChanged AirAmountChanged;

    private static readonly float _maxAirAmount = 4f;
    private static readonly float _minAirAmount = 1f;
    private static readonly float _meanAirAmount = (_maxAirAmount + _minAirAmount) / 2f;

    private static readonly float _vibrateAmplitude = 0.01f;
    private static readonly float _vibrateCycleSecs = 0.5f;
    private float _vibrateSinCurveAngle = 0f;
    private float _vibrateAngularIncrement;
    private Vector3 _vibrateDirection;
    private bool _isVibrating = false;

    private float _airAmount;
    public float airAmount
    {
        get { return _airAmount; }
        set
        {
            _airAmount = Mathf.Clamp(value, _minAirAmount, _maxAirAmount);
            AirAmountChanged?.Invoke(_airAmount);
        }
    }

    public delegate void OnSizeChanged(float size);
    public static event OnSizeChanged SizeChanged;

    private float _size;
    public float size
    {
        get { return _size; }
        set
        {
            _size = value;
            SizeChanged?.Invoke(_size);
        }
    }

    void AdjustSize(float airAmount)
    {
        size = Mathf.Sqrt(airAmount);
    }

    void AdjustGravity(float airAmount)
    {
        rb.gravityScale = -(airAmount - _meanAirAmount) / 8f;
    }

    void AdjustScale(float size)
    {
        transform.localScale = new Vector2(size, size);
    }

    void Awake()
    {
        AirAmountChanged += AdjustSize;
        AirAmountChanged += AdjustGravity;
        SizeChanged += AdjustScale;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        airAmount = _meanAirAmount;
        _vibrateAngularIncrement = 2 * Mathf.PI * Time.fixedDeltaTime / _vibrateCycleSecs;
        _vibrateDirection = transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(rb.linearVelocity.y) < 0.01f)
        {
            _isVibrating = true;
        }
        else
        {
            _isVibrating = false;
            _vibrateSinCurveAngle = 0f;
        }
    }

    void FixedUpdate()
    {
        if (_isVibrating)
        {
            _vibrateSinCurveAngle += _vibrateAngularIncrement;

            if (_vibrateSinCurveAngle > 2 * Mathf.PI)
            {
                _vibrateSinCurveAngle -= 2 * Mathf.PI;
                _vibrateDirection = Vector3.Scale(_vibrateDirection, new Vector3(1, -1, 1));
            }

            transform.position += _vibrateDirection * Mathf.Sin(_vibrateSinCurveAngle) * _vibrateAmplitude;
        }
    }

    void OnDisabled()
    {

    }

    void OnDestroy()
    {

    }
}
