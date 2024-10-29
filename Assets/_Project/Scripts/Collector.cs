using DG.Tweening;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private Transform _transferPosition;

    private bool _isCanPickUp;
    private bool _isPickUp;

    private PickUpObject _pickUpObject;

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

        _pickUpObject = pickUpObject;
        _isCanPickUp = true;
    }

    public void DeleteObject()
    {
        if (_isPickUp)
            return;

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
        _pickUpObject.transform.DOJump(_transferPosition.position, 1, 1, 0.1f);

        _isCanPickUp = false;
        _isPickUp = true;
    }
}
