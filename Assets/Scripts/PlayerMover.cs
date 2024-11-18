using System;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        Rotate();
    }

    private void Move()
    {
        var verticalInput = Input.GetAxis("Vertical");
        var movementVector = new Vector3(0f, 0f, verticalInput) * (_moveSpeed * Time.deltaTime);
        
        _rigidbody.AddForce(transform.TransformDirection(movementVector), ForceMode.Acceleration);
    }

    private void Rotate()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var rotationVector = new Vector3(0f, horizontalInput, 0f) * (_rotationSpeed * Time.deltaTime);
        
        transform.Rotate(rotationVector);
    }
}
