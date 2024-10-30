using System.Collections.Generic;
using UnityEngine;

public class Warehouse : MonoBehaviour
{
    [SerializeField] private List<Transform> _placementPositions;

    private Collector _collector;
    private PlayerUI _playerUI;

    private PickUpObject _pickUpObject;

    private int _objectsValue;
    private bool _isCanThrow;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Collector collector))
            TryAllowThrow(collector);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Collector collector))
            DisallowThrow();
    }

    private void Update()
    {
        if (_isCanThrow)
            if (Input.GetKeyDown(KeyCode.E))
                Throw();
    }

    private void TryAllowThrow(Collector collector)
    {
        _collector ??= collector;
        _playerUI ??= _collector.PlayerUI;   

        if (_collector.PickUpObject != null)
        {
            if (_objectsValue + 1 > _placementPositions.Count)
            {
                _playerUI.FullTruckText.gameObject.SetActive(true);
                return;
            }

            AllowThrow(_collector.PickUpObject);
        }
    }

    private void AllowThrow(PickUpObject pickUpObject)
    {
        _pickUpObject = pickUpObject;
        _isCanThrow = true;

        _playerUI.ThrowButtonText.gameObject.SetActive(true);
    }

    private void DisallowThrow()
    {
        _pickUpObject = null;
        _isCanThrow = false;

        _playerUI.ThrowButtonText.gameObject.SetActive(false);
        _playerUI.FullTruckText.gameObject.SetActive(false);
    }

    private void Throw()
    {       
        _pickUpObject.transform.parent = _placementPositions[_objectsValue];
        _pickUpObject.transform.position = _placementPositions[_objectsValue].position;

        _objectsValue++;

        _pickUpObject.ChangeAvailable(false);

        DisallowThrow();
        _collector.LetGo();
    }
}
