using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _moveForce;
    [SerializeField] float _jumpForce;
    [SerializeField] float _maxSpeed;
    [SerializeField] Vector3 _startPosition;
    [SerializeField] ParticleSystem _collectBurst;
    [SerializeField] TrailRenderer _trail;

    public int CoinsCollected { get; private set; }

    private bool _freezed;
    private bool _isJumpPressed;
    private bool _isOnGround;
    private string _horizontalName = "Horizontal";
    private string _verticalName = "Vertical";
    private KeyCode _jumpKeyCode = KeyCode.Space;
    private Rigidbody _rigidBody;
    private float _moveInputX;
    private float _moveInputZ;
    private float _deadZone = 0.05f;

    public void Initialize()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
        CoinsCollected = 0;
        _isJumpPressed = false;
        _rigidBody = GetComponent<Rigidbody>();
        _isOnGround = true;
        _rigidBody.constraints = RigidbodyConstraints.None;
        _trail.enabled = true;
        _freezed = false;
    }

    public void AddCoin()
    {
        CoinsCollected += 1;
    }

    public void Freeze()
    {
        _freezed = true;
        _rigidBody.constraints = RigidbodyConstraints.FreezeAll;
        _collectBurst.Clear();
        _trail.enabled = false;
    }

    private void Update()
    {
        if (_freezed == false)
        {
            if (_isOnGround)
                InputHandle();
        }
    }

    private void InputHandle()
    {
        if (Input.GetKeyDown(_jumpKeyCode))
            _isJumpPressed = true;

        _moveInputX = Input.GetAxisRaw(_horizontalName);
        _moveInputZ = Input.GetAxisRaw(_verticalName);
    }

    private void FixedUpdate()
    {
        if (_isJumpPressed)
        {
            _rigidBody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isJumpPressed = false;
            _isOnGround = false;
        }

        if (MathF.Abs(_moveInputX) > _deadZone || Mathf.Abs(_moveInputZ) > _deadZone)
            _rigidBody.AddForce(new Vector3(_moveInputX * _moveForce * Time.deltaTime, 0, _moveInputZ * _moveForce * Time.deltaTime), ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Floor floor = collision.collider.GetComponentInParent<Floor>();
        if (floor != null)
        {
            ContactPoint contact = collision.contacts[0];
            if (contact.normal == Vector3.up)
                _isOnGround = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Coin>())
        {
            AddCoin();
            _collectBurst.Play();
        }
    }
}
