using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Scenario))]
public class ScenarioEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Scenario scenario = (Scenario)target;
        if (GUILayout.Button("Force Complete !"))
        {
            scenario.ForceComplete();
        }
    }
}
