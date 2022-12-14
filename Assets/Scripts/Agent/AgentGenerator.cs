using System;
using UnityEngine;

[RequireComponent(typeof(ObjectPool), typeof(AgentCountChecker))]
public class AgentGenerator : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _minDelay;
    [SerializeField] private float _maxDelay;
    [Header("Setup")]
    [SerializeField] private Agent _agentTemplate;
    [SerializeField] private AgentDataView _agentDataViewTemplate;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _parentAgent;
    [SerializeField] private Transform _parentAgentDataView;

    public int CurrentAmountAgents { get; private set; }
    public float MinDelay => _minDelay;
    public float MaxDelay => _maxDelay;

    private ObjectPool _objectPool;
    private AgentCountChecker _agentCountChecker;

    public event Action AgentCreated;
    public event Action AgentDied;

    private void Start()
    {
        _agentCountChecker = GetComponent<AgentCountChecker>();
        _objectPool = GetComponent<ObjectPool>();
        _objectPool.InitializeAgent(_agentTemplate, _agentDataViewTemplate, _parentAgent, _parentAgentDataView, _agentCountChecker.MaxCountOfAgents);
    }

    public void CreateAgent()
    {
        _objectPool.TryGetAgentAndAgentDataView(out Agent agent, out AgentDataView agentDataView);
        agent.transform.localPosition = _startPosition.localPosition;
        agent.gameObject.SetActive(true);
        agentDataView.gameObject.SetActive(false);
        CurrentAmountAgents++;
        agent.Died += OnAgentDied;
        AgentCreated?.Invoke();
    }

    private void OnAgentDied()
    {
        CurrentAmountAgents--;
        AgentDied?.Invoke();       
    }
}