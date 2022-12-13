using System;
using UnityEngine;

public class AgentView : MonoBehaviour
{
    [SerializeField] private GameObject _checkMark;
    
    public bool IsAgentSelected { get; private set; }

    public event Action SelectionChanged;

    private void OnMouseDown()
    {
        IsAgentSelected = IsAgentSelected == false;
        _checkMark.SetActive(IsAgentSelected);
        SelectionChanged?.Invoke();
    }
}
