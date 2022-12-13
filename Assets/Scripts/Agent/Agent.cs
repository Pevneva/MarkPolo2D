using System;
using UnityEngine;

[RequireComponent(typeof(AgentView))]
public class Agent : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private string _prefixName;
    
    public int Health => _health;
    public string Name { get; private set; }

    private static int _id;
    private AgentView _agentView;
    private AgentDataView _dataView;

    public event Action Died;

    private void Start()
    {
        Name = _prefixName + ++_id;
        _agentView = GetComponent<AgentView>();
        _agentView.SelectionChanged += OnSelectionAgentViewChanged;
    }

    private void Update()
    {
        if (_dataView == null)
            return;

        if (_agentView.IsAgentSelected == false)
            return;
        
        _dataView.Render(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Agent agent))
            OnAgentCollision();
    }

    public void Init(AgentDataView dataView)
    {
        _dataView = dataView;
    }

    private void OnSelectionAgentViewChanged()
    {
        _dataView.gameObject.SetActive(_dataView.gameObject.activeSelf == false);
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
            Destroy(_dataView.gameObject);
            Destroy(gameObject);
            Died?.Invoke();
        }
    }
}