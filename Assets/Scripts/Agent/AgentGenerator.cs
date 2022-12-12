using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AgentGenerator : MonoBehaviour
{
    [SerializeField] private Agent _agentTemplate;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _parent;
    [SerializeField] private float _minDelay;
    [SerializeField] private float _maxDelay;

    public int CurrentAmountAgents { get; private set; }
    public float MinDelay => _minDelay; 
    public float MaxDelay => _maxDelay; 

    public event Action AgentCreated;
    
    public void CreateAgent()
    {
        Agent agent = Instantiate(_agentTemplate, _startPosition.position, Quaternion.identity, _parent);
        CurrentAmountAgents++;
        AgentCreated?.Invoke();
    }
    
}
