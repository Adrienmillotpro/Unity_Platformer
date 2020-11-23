using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Randomizer : MonoBehaviour
{
    //public float Random;
    public GameObject Parent;
    public GameObject Tile_1;
    public GameObject Tile_2;
    public GameObject Tile_3;
    //public Terrain Terrain_Plane;
    
    [Range(0, 100)] public int Big_Tile_Percentage;
    [Range(0, 100)] public int Small_Tile_Percentage;
    [Range(0, 100)] public int Broken_Tile_Percentage;
    [Range(0, 100)] public int Empty_Percentage;

    public void Randomize_Layout() 
    {        
        foreach (Transform child in transform) 
        {
            if (child.name.Substring(0, 4) == "ruin") 
            {
                Change_Tile(child.gameObject, child);
            }                        
        }
            
        
    }


    private void Change_Tile(GameObject Tile, Transform T_Tile) 
    {

        Tile_1.transform.localScale = new Vector3();
        int Rand_Value = Random.Range(0, 101);        
        if (Determine_Chance("Big")[0] < Rand_Value && Rand_Value <= Determine_Chance("Big")[1])
        {            
            GameObject new_tile = Instantiate(Tile_1, T_Tile.position, transform.localRotation) as GameObject;
            new_tile.transform.SetParent(Parent.transform);
            new_tile.transform.localScale = new Vector3(1, 1, 1);
            int Rand_Value2 = Random.Range(1, 4);
            if (Rand_Value2 == 1)
            {
                new_tile.transform.Rotate(Random.Range(-5, 5), Random.Range(-2, 2), Random.Range(-5, 5));
            }
            else if (Rand_Value2 == 2)
            {
                new_tile.transform.Rotate(Random.Range(-5, 5), Random.Range(178, 182), Random.Range(-5, 5));
            }
            DestroyImmediate(Tile.gameObject);

        }
        else if (Determine_Chance("Small")[0] < Rand_Value && Rand_Value <= Determine_Chance("Small")[1])
        {
            GameObject new_tile = Instantiate(Tile_2, T_Tile.position, T_Tile.rotation);
            new_tile.transform.SetParent(Parent.transform);            
            new_tile.transform.localScale = new Vector3(1, 1, 1);
            int Rand_Value2 = Random.Range(1, 4);
            if (Rand_Value2 == 1)
            {
                new_tile.transform.Rotate(Random.Range(-5, 5), Random.Range(-2, 2), Random.Range(-5, 5));
            }
            else if (Rand_Value2 == 2)
            {
                new_tile.transform.Rotate(Random.Range(-5, 5), Random.Range(178, 182), Random.Range(-5, 5));
            }
            DestroyImmediate(Tile.gameObject);
        }
        else if (Determine_Chance("Broken")[0] < Rand_Value && Rand_Value <= Determine_Chance("Broken")[1])
        {
            GameObject new_tile = Instantiate(Tile_3, T_Tile.position, T_Tile.rotation);
            new_tile.transform.SetParent(Parent.transform);
            new_tile.transform.localScale = new Vector3(1, 1, 1);
            new_tile.transform.Rotate(0, Random.Range(-180, 180), Random.Range(-5, 5));
            DestroyImmediate(Tile.gameObject);
        }
        else if (Determine_Chance("Empty")[0] < Rand_Value && Rand_Value <= Determine_Chance("Empty")[1])
        {
            Tile.SetActive(false);
        }

    }
    private int[] Determine_Chance(string Tile_Type) 
    {
        int[] Chances = new int[2];
        if (Tile_Type == "Big")
        {
            Chances[0] = 0;
            Chances[1] = Big_Tile_Percentage;
        }
        else if (Tile_Type == "Small")
        {
            Chances[0] = Big_Tile_Percentage;
            Chances[1] = Big_Tile_Percentage + Small_Tile_Percentage;
        }
        else if (Tile_Type == "Broken") 
        {
            Chances[0] = Big_Tile_Percentage + Small_Tile_Percentage;
            Chances[1] = Big_Tile_Percentage + Small_Tile_Percentage + Broken_Tile_Percentage;
        }
        else if (Tile_Type == "Empty") 
        {
            Chances[0] = Big_Tile_Percentage + Small_Tile_Percentage + Broken_Tile_Percentage;
            Chances[1] = Big_Tile_Percentage + Small_Tile_Percentage + Broken_Tile_Percentage + Empty_Percentage;
        }
        return Chances;
    } 
}
