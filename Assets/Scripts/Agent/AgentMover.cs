using UnityEngine;
using Random = UnityEngine.Random;

public class AgentMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private Vector2 _currentDirection;

    private void Start()
    {
        _currentDirection = Vector2.right;
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * _currentDirection );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");
        if (collision.gameObject.TryGetComponent(out Border border))
        {
            SetDirection(border.Type);
        }
    }

    private void SetDirection(BorderType type)
    {
        Debug.Log("SetDirection : " + type);
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
                randomX = 0;
                randomY = 0;
                break;
        }
        Debug.Log(randomX);
        Debug.Log(randomY);
        _currentDirection = new Vector2(randomX, randomY);
        Debug.Log(_currentDirection);
    }
}