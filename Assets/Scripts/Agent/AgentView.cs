using UnityEngine;

public class AgentView : MonoBehaviour
{
    [SerializeField] private GameObject _checkMark;

    private bool _isAgentSelected;
    
    private void OnMouseDown()
    {
        _isAgentSelected = _isAgentSelected == false;
        _checkMark.SetActive(_isAgentSelected);
    }
}
