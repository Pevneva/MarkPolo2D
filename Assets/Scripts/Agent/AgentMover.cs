using UnityEngine;
using Random = UnityEngine.Random;

public class AgentMover : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _speed;

    private Vector2 _currentDirection;

    private void Start()
    {
        _currentDirection = GetRandomDirection(BorderType.NULL);
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * _currentDirection);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Border border))
        {
            _currentDirection = GetRandomDirection(border.Type);
        }
    }

    private Vector2 GetRandomDirection(BorderType type)
    {
        float randomX;
        float randomY;

        switch (type)
        {
            case BorderType.RIGHT:
                randomX = Random.Range(-0.999f, 0.001f);
                randomY = Random.Range(-0.999f, 0.999f);
                break;
            case BorderType.BOTTOM:
                randomX = Random.Range(-0.999f, 0.999f);
                randomY = Random.Range(0.001f, 0.999f);
                break;
            case BorderType.LEFT:
                randomX = Random.Range(0.001f, 0.999f);
                randomY = Random.Range(-0.999f, 0.999f);
                break;
            case BorderType.TOP:
                randomX = Random.Range(-0.999f, 0.999f);
                randomY = Random.Range(-0.999f, 0.001f);
                break;
            default:
                randomX = Random.Range(-0.999f, 0.999f);
                randomY = Random.Range(-0.999f, 0.999f);
                break;
        }

        return new Vector2(randomX, randomY);
    }
}