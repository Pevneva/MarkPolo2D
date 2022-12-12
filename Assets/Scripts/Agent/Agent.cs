using System;
using UnityEngine;

public class Agent : MonoBehaviour
{
    [SerializeField] private int _health;

    public event Action Died;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Agent agent))
            OnAgentCollision();
    }

    private void OnAgentCollision()
    {
        DecreaseHealth();
    }

    private void DecreaseHealth()
    {
        _health--;

        if (_health <= 0)
        {
            Destroy(gameObject);
            Died?.Invoke();
        }
    }
}