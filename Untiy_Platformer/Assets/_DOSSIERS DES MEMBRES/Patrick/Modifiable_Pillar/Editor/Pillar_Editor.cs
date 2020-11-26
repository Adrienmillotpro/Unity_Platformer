using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(PIllar_Script))]
public class Pillar_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        PIllar_Script Script_Pillar = (PIllar_Script)target;

        if (GUILayout.Button("Set"))
        {
            Script_Pillar.Change_Size();
        }

        if (GUILayout.Button("Randomize"))
        {
            Script_Pillar.Randomize_Bricks();
        }
    }

}
