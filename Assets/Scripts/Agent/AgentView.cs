using System;
using UnityEngine;

public class AgentView : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private GameObject _checkMark;
    
    public bool IsAgentSelected { get; private set; }

    public event Action SelectionChanged;

    private void OnMouseDown()
    {
        ChangeSelection();
    }

    public void ChangeSelection()
    {
        IsAgentSelected = IsAgentSelected == false;
        _checkMark.SetActive(IsAgentSelected);
        SelectionChanged?.Invoke();
    }
}
