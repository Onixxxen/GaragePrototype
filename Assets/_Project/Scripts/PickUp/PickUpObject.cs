using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    [SerializeField] private Collector _collector;

    private bool _isAvailable = true;

    private void OnMouseEnter()
    {
        if (!_isAvailable)
            return;

        float distance = Vector3.Distance(_collector.transform.position, transform.position);

        if (distance < 2)
            _collector.SetObject(this);
    }

    private void OnMouseExit()
    {
        if (!_isAvailable)
            return;

        _collector.DeleteObject();
    }

    public void ChangeAvailable(bool isAvailable) => _isAvailable = isAvailable;
}
