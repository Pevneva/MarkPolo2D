using TMPro;
using UnityEngine;

public class AgentDataView : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _offsetY;
    [Header("Setup")]
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _health;

    public void Render(Agent agent)
    { 
        _name.text = agent.Name;
        _health.text = agent.Health.ToString();
        SetPosition(agent, _offsetY);
    }

    private void SetPosition(Agent participant, float offsetY)
    {
        Vector2 position = participant.transform.position;
        Vector2 positionOnScreen = Camera.main.WorldToScreenPoint(position);
        positionOnScreen.y += offsetY;
        transform.position = positionOnScreen;
    }
}
