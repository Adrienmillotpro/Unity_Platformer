using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(Randomizer))]
public class Floor_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Randomizer Rando_Script = (Randomizer)target;

        if (GUILayout.Button("Randomize")) 
        {            
            Rando_Script.Randomize_Layout();            
        }
        /*
        if (GUILayout.Button("New Terrain"))
        {

            Rando_Script.Terrain_Plane.terrainData = new TerrainData();
            Debug.Log("new terrain");
        }
        */
    }
}
