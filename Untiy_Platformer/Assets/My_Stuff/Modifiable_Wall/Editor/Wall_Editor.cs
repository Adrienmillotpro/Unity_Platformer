using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(Randomizer_Wall))]
public class Wall_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();        
        Randomizer_Wall Rando_Script = (Randomizer_Wall)target;     

        if (GUILayout.Button("Randomize Bricks")) 
        {
            Rando_Script.Randomize_Layout();
        }
         GUILayout.BeginHorizontal();

        if (GUILayout.Button("<"))
        {
            Rando_Script.Left_Pressed_Wall();
        }

        GUILayout.Button(Rando_Script.Parent.GetChild(0).name.Substring(0, 5));

        if (GUILayout.Button(">"))
            
        {
            Rando_Script.Right_Pressed_Wall();
        }


        GUILayout.EndHorizontal();
        
        //--------------------------------------------------------------

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("<"))
        {
            Rando_Script.Left_Pressed_Type_Wall();
        }

        GUILayout.Button(Rando_Script.Wall_Type);

        if (GUILayout.Button(">"))

        {
            Rando_Script.Right_Pressed_Type_Wall();
        }


        GUILayout.EndHorizontal();
    }
}
