using UnityEngine;

public class MouseInput : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;

    private float horizontal;
    private float vertical;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        horizontal += Input.GetAxis("Mouse X");
        vertical += Input.GetAxis("Mouse Y");

        vertical = Mathf.Clamp(vertical, -90, 90);

        _playerCamera.transform.rotation = Quaternion.Euler(-vertical, horizontal, 0f);
        gameObject.transform.rotation = Quaternion.Euler(0f, horizontal, 0f);
    }
}
