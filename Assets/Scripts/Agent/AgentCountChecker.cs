using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AgentGenerator))]
public class AgentCountChecker : MonoBehaviour
{
    [SerializeField] private int _maxCountOfAgents;
    
    private AgentGenerator _generator;
    
    private void Start()
    {
        _generator = GetComponent<AgentGenerator>();
        _generator.AgentCreated += TryCreateAgent;
        _generator.AgentDied += TryCreateAgent;
        TryCreateAgent();
    }
    
    public void TryCreateAgent()
    {
        if (IsAgentCountNotMax())
        {
            StartCoroutine(TryCreateAgentWithDelay(_generator.MinDelay, _generator.MaxDelay));
        }
    }

    public bool IsAgentCountNotMax()
    {
        return _generator.CurrentAmountAgents < _maxCountOfAgents;
    }

    private IEnumerator TryCreateAgentWithDelay(float minDelay, float maxDelay)
    {
        float randomDelay = Random.Range(minDelay, maxDelay);
        yield return new WaitForSeconds(randomDelay);
        if (IsAgentCountNotMax())
            _generator.CreateAgent();
        yield break;
    }
}
