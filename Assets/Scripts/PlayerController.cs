using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 15.0f;
    [SerializeField] private Transform cameraTransform;
    
    private Rigidbody _rb;
    private Vector2 _moveDirection;
    private RaycastHit _hit;
    private bool _isJumping;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        Walk(_moveDirection);
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
}
