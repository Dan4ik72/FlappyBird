using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMovement : MonoBehaviour
{
    [SerializeField] private float _tapForce;

    private readonly float _maxRotationZ = 35;
    private readonly float _minRotationZ = -60;

    private Vector3 _startPosition;

    private float _rotationSpeed = 1;

    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _startPosition = transform.position;
    }

    private void Start()
    {
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);        

        ResetBird();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.rotation = _maxRotation;

            Jump();
        }
        
        transform.rotation = Quaternion.Slerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void ResetBird()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
        _rigidbody.velocity = Vector2.zero;
        transform.position = _startPosition;
    }

    private void Jump()
    {
        _rigidbody.velocity = Vector2.zero;

        _rigidbody.AddForce(new Vector2(0, _tapForce), ForceMode2D.Force);
    }
}
