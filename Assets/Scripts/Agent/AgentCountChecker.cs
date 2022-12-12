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
        _generator.AgentCreated += OnAgentCreated;
        TryCreateAgent();
    }

    private void OnAgentCreated()
    {
        TryCreateAgent();
    }

    private void TryCreateAgent()
    {
        if (IsAgentCountNotMax())
        {
            StartCoroutine(CreateAgentWithDelayInRange(_generator.MinDelay, _generator.MaxDelay));
        }
    }

    public bool IsAgentCountNotMax()
    {
        return _generator.CurrentAmountAgents < _maxCountOfAgents;
    }

    private IEnumerator CreateAgentWithDelayInRange(float minDelay, float maxDelay)
    {
        float randomDelay = Random.Range(minDelay, maxDelay);
        yield return new WaitForSeconds(randomDelay);
        _generator.CreateAgent();
        yield break;
    }
}
