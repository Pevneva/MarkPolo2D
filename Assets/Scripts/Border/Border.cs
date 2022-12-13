using UnityEngine;

public class Border : MonoBehaviour
{
    [SerializeField] private BorderType _type;

    public BorderType Type => _type;
}
