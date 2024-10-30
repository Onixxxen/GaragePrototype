using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [field: SerializeField] public TMP_Text PickUpButtonText { get; private set; }
    [field: SerializeField] public TMP_Text ThrowButtonText { get; private set; }
    [field: SerializeField] public TMP_Text FullTruckText { get; private set; }
}
