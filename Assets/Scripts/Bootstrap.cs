using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private AgentCountChecker _agentCountChecker;
    [SerializeField] private NumbersAndNamesDisplayer _numbersAndNamesDisplayer;
    
    private void Awake()
    {
        _agentCountChecker.StartAgentsGeneration();
        _numbersAndNamesDisplayer.InitNumbersNames();
    }
}
