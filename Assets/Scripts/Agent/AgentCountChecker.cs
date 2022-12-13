using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AgentGenerator))]
public class AgentCountChecker : MonoBehaviour
{
    [SerializeField] private int _maxCountOfAgents;

    private AgentGenerator _generator;
    private Coroutine _agentCreating;

    private void Start()
    {
        _generator = GetComponent<AgentGenerator>();
        _generator.AgentCreated += TryCreateAgent;
        _generator.AgentDied += TryCreateAgent;
        TryCreateAgent();
    }

    private void TryCreateAgent()
    {
        if (IsAgentCountNotMax())
        {
            if (_agentCreating != null)
                StopCoroutine(_agentCreating);

            _agentCreating = StartCoroutine(TryCreateAgentWithDelay(_generator.MinDelay, _generator.MaxDelay));
        }
    }

    private bool IsAgentCountNotMax()
    {
        return _generator.CurrentAmountAgents < _maxCountOfAgents;
    }

    private IEnumerator TryCreateAgentWithDelay(float minDelay, float maxDelay)
    {
        float randomDelay = Random.Range(minDelay, maxDelay);
        yield return new WaitForSeconds(randomDelay);
        _generator.CreateAgent();
        yield break;
    }
}