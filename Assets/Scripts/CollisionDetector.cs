using System;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public event Action AgentCollision;
    public event Action<BorderType> BorderCollision;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Agent agent))
            AgentCollision?.Invoke();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Border border))
            BorderCollision?.Invoke(border.Type);
    }
}
