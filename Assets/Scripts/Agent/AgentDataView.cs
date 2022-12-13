using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AgentDataView : MonoBehaviour
{
    [SerializeField] private float _offsetY;
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
