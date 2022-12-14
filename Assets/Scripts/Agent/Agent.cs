using System;
using UnityEngine;

[RequireComponent(typeof(AgentView), typeof(CollisionDetector))]
public class Agent : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int _health;
    [SerializeField] private string _prefixName;
    
    public int Health => _health;
    public string Name { get; private set; }

    private static int _id;
    private AgentView _agentView;
    private AgentDataView _dataView;
    private CollisionDetector _collisionDetector;
    private int _startHealth;

    public event Action Died;

    private void OnEnable()
    {
        SetStartData();
    }

    private void Awake()
    {
        _startHealth = _health;
        _agentView = GetComponent<AgentView>();
        _agentView.SelectionChanged += OnSelectionAgentViewChanged;
        _collisionDetector = GetComponent<CollisionDetector>();
        _collisionDetector.AgentCollision += OnAgentCollision;
    }

    private void SetStartData()
    {
        Name = _prefixName + ++_id;
        _health = _startHealth;
    }

    private void OnDestroy()
    {
        _agentView.SelectionChanged -= OnSelectionAgentViewChanged;
        _collisionDetector.AgentCollision -= OnAgentCollision;
    }

    private void Update()
    {
        if (_dataView == null)
            return;

        if (_agentView.IsAgentSelected == false)
            return;
        
        _dataView.Render(this);
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
            Die();
            Died?.Invoke();
        }
    }

    private void Die()
    {
        if (_agentView.IsAgentSelected)
            _agentView.ChangeSelection();
        _dataView.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}