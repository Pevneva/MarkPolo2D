using System;
using UnityEngine;

public class AgentGenerator : MonoBehaviour
{
    [SerializeField] private Agent _agentTemplate;
    [SerializeField] private AgentDataView AgentDataViewTemplate;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _parentAgent;
    [SerializeField] private Transform _parentAgentDataView;
    [SerializeField] private float _minDelay;
    [SerializeField] private float _maxDelay;

    public int CurrentAmountAgents { get; private set; }
    public float MinDelay => _minDelay;
    public float MaxDelay => _maxDelay;

    public event Action AgentCreated;
    public event Action AgentDied;

    public void CreateAgent()
    {
        Agent agent = Instantiate(_agentTemplate, new Vector3(_startPosition.position.x, _startPosition.position.y, -1), Quaternion.identity, _parentAgent);
        AgentDataView agentDataView = Instantiate(AgentDataViewTemplate, agent.transform.position, Quaternion.identity, _parentAgentDataView);
        agentDataView.gameObject.SetActive(false);
        agent.Init(agentDataView);
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