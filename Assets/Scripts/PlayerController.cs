using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 15.0f;
    [SerializeField] private Transform cameraTransform;
    
    private Rigidbody _rb;
    private GameObject _body;
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
}
