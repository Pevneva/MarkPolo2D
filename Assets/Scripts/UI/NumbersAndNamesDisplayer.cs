using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumbersAndNamesDisplayer : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private TMP_Text _allNumbersText;
    [SerializeField] private Button _showButton;
    
    [Header("Settings")]
    [SerializeField] private string _nameIfDevidedByThree = "Marko";
    [SerializeField] private string _nameIfDevidedByFive = "Polo";
    
    private void Start()
    {
        ClearField();
        _showButton.onClick.AddListener(OnShowButton);
    }

    private void ClearField()
    {
        _allNumbersText.text = String.Empty;
    }

    private void OnShowButton()
    {
        ClearField();
        GenerateNumbersAndNames();
    }

    private void GenerateNumbersAndNames()
    {
        for (int i = 1; i <= 100; i++)
            _allNumbersText.text += TryGetName(i) + "; ";
    }

    private string TryGetName(int value)
    {
        if (value % 3 == 0 && value % 5 == 0) return _nameIfDevidedByFive + _nameIfDevidedByThree;
        if (value % 3 == 0) return _nameIfDevidedByThree;
        if (value % 5 == 0) return _nameIfDevidedByFive;
        return value.ToString();
    }
}