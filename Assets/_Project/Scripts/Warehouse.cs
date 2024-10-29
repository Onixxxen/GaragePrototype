using System.Collections.Generic;
using UnityEngine;

public class Warehouse : MonoBehaviour
{
    [SerializeField] private List<Transform> _placementPositions;

    private Collector _collector;
    private PickUpObject _pickUpObject;

    private int _objectsValue;
    private bool _isCanThrow;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Collector collector))
        {
            if (_objectsValue + 1 > _placementPositions.Count)
            {
                Debug.Log($"Пикап заполнен");
                return;
            }

            _collector ??= collector;

            Debug.Log(_collector.PickUpObject);

            if (_collector.PickUpObject != null)
                AllowThrow(_collector.PickUpObject);
        }
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

    private void AllowThrow(PickUpObject pickUpObject)
    {
        _pickUpObject = pickUpObject;
        _isCanThrow = true;

        Debug.Log(_isCanThrow);
    }

    private void DisallowThrow()
    {
        _pickUpObject = null;
        _isCanThrow = false;
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
