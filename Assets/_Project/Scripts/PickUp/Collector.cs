using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private Transform _transferPosition;
    [SerializeField] private PlayerUI _playerUI;

    private bool _isCanPickUp;
    private bool _isPickUp;

    private PickUpObject _pickUpObject;

    public PlayerUI PlayerUI => _playerUI;
    public PickUpObject PickUpObject => _pickUpObject;

    private void Update()
    {
        if (_isCanPickUp)
            if (Input.GetKeyDown(KeyCode.E))
                PickUp();
    }

    public void SetObject(PickUpObject pickUpObject)
    {
        if (_isPickUp)
            return;

        _playerUI.PickUpButtonText.gameObject.SetActive(true);

        _pickUpObject = pickUpObject;
        _isCanPickUp = true;
    }

    public void DeleteObject()
    {
        if (_isPickUp)
            return;

        _playerUI.PickUpButtonText.gameObject.SetActive(false);

        _pickUpObject = null;
        _isCanPickUp = false;
    }

    public void LetGo()
    {
        _isPickUp = false;
        _pickUpObject = null;
    }

    private void PickUp()
    {
        _pickUpObject.transform.parent = gameObject.transform;
        _pickUpObject.transform.position = _transferPosition.position;

        _isCanPickUp = false;
        _isPickUp = true;

        _playerUI.PickUpButtonText.gameObject.SetActive(false);
    }
}
