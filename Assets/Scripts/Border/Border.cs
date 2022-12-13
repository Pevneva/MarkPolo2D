using UnityEngine;

public class Border : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private BorderType _type;

    public BorderType Type => _type;
}
