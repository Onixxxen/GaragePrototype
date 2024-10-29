using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private PhysicsMovement _movement;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 cameraForward = transform.forward;
        Vector3 moveDirection = (cameraForward * vertical + transform.right * horizontal).normalized;

        _movement.Move(moveDirection);
    }
}
