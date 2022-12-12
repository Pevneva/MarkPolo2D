using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private AgentGenerator _generator;
    
    private void Awake()
    {
        // _generator.StartGeneration();
    }
}
