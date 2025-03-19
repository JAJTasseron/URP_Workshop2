using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 15.0f;
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private Transform cameraTransform;
    
    private Rigidbody _rb;
    private Vector2 _moveDirection;
    private Collider _collider;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        foreach(Transform child in transform)
        {
            if(child.name == "Body")
            {
                _collider = child.GetComponent<Collider>();
            }
        }
        
    }
    
    void FixedUpdate()
    {
        Walk(_moveDirection);
    }

    void Update()
    {
        Jump();
        Turn();
    }

    public void OnMove(InputValue value)
    {
        _moveDirection = value.Get<Vector2>();
    }

    private void Walk(Vector2 direction)
    {
        Vector3 movement = cameraTransform.forward * direction.y + cameraTransform.right * direction.x;
        _rb.AddForce(movement.normalized * movementSpeed);
    }

    private void Turn()
    {
        transform.rotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
    }
    
    private void Jump()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && IsGrounded())
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, _collider. bounds.extents.y + 0.1f);
    }
}
