using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private List<(Agent, AgentDataView)> _pool = new List<(Agent, AgentDataView)>();

    public void InitializeAgent(Agent agentPrefab, AgentDataView agentDataViewPrefab, Transform agentParent, Transform agentDataViewParent, int _size)
    {
        for (int i = 0; i < _size; i++)
        {
            Agent agent = Instantiate(agentPrefab, agentParent);
            agent.gameObject.SetActive(false);
            AgentDataView agentDataView = Instantiate(agentDataViewPrefab, agentDataViewParent);
            agentDataView.gameObject.SetActive(false);
            agent.Init(agentDataView);
            _pool.Add((agent, agentDataView));
        }
    }
    
    public bool TryGetAgentAndAgentDataView(out Agent agent, out AgentDataView agentDataView)
    {
        (Agent, AgentDataView) pair = _pool.FirstOrDefault(t => t.Item1.gameObject.activeSelf == false);
        agent = pair.Item1;
        agentDataView = pair.Item2;        
        return pair != (null, null);
    }
}
