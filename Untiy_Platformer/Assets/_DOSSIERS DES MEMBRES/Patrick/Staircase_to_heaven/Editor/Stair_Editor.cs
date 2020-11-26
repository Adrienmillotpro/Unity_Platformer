using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(Stair_Script))]
public class Stair_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Stair_Script Script_staircase = (Stair_Script)target;

        if (GUILayout.Button("Set"))
        {
            Script_staircase.Complete_Stair();
        }
    }
}
