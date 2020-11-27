using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Wall_Script))]
public class Wall_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Wall_Script Wall_Script_Ref = (Wall_Script)target;

        if (GUILayout.Button("Randomize Bricks"))
        {
            Wall_Script_Ref.Randomize_The_Bricks();
        }
        if (GUILayout.Button("Set_Wall"))
        {
            Wall_Script_Ref.Set_Wall();
        }

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("<"))
        {            
            Wall_Script_Ref.Left_Pressed_Wall();            
        }

        GUILayout.Button(Wall_Script_Ref.Parent.GetChild(0).name.Substring(0, 6));

        if (GUILayout.Button(">"))
        {            
            Wall_Script_Ref.Right_Pressed_Wall();           
        }

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("<"))
        {
            Wall_Script_Ref.Left_Pressed_Type_Wall();
        }

        GUILayout.Button(Wall_Script_Ref.Wall_Type);

        if (GUILayout.Button(">"))
        {
            Wall_Script_Ref.Right_Pressed_Type_Wall();
        }

        GUILayout.EndHorizontal();


        if (GUILayout.Button("Show all"))
        {
            Wall_Script_Ref.showall();
        }
        
    }
}
