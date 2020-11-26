using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Stair_Script : MonoBehaviour
{
    public Transform Parent;
    [Space(3)]
    [Header("Stair Pieces")]
    public GameObject Stairs;
    public GameObject Stone_Under;

    [Range(0, 50)] public int Amount_Stairs;
    [Range(0, 100)] public int Plateau_Rate;
    [Range(0, 4)] public int Plateau_Size;

    private void Destroy_Stairs() 
    {        
        while (Parent.childCount > 1) 
        {
            DestroyImmediate(Parent.GetChild(Parent.childCount - 1).gameObject);
        }        
    }

    private void Build_Stairs() 
    {
        int Amount_Current = Amount_Stairs - 1;
        while (Amount_Current > 0) 
        {  
            int Chance = Random.Range(0, 101);
            if (Chance > 0 && Chance < Plateau_Rate)
            {
                GameObject New_Staircase = Instantiate(Stairs, Parent.GetChild(Parent.childCount - 1).position + new Vector3(0, 1, -Plateau_Size), Parent.GetChild(Parent.childCount - 1).rotation);
                New_Staircase.transform.SetParent(Parent);
                GameObject New_Ground = Instantiate(Stone_Under, Parent.GetChild(Parent.childCount - 1).position + new Vector3(0, 0, -2f), Parent.GetChild(Parent.childCount - 1).rotation);
                New_Ground.transform.SetParent(New_Staircase.transform);
                Amount_Current -= 1;
            }
            else 
            {
                GameObject New_Staircase = Instantiate(Stairs, Parent.GetChild(Parent.childCount - 1).position + new Vector3(0, 1, -1.5f), Parent.GetChild(Parent.childCount - 1).rotation);
                New_Staircase.transform.SetParent(Parent);
                GameObject New_Ground = Instantiate(Stone_Under, Parent.GetChild(Parent.childCount - 1).position + new Vector3(0, 0, -2f), Parent.GetChild(Parent.childCount - 1).rotation);
                New_Ground.transform.SetParent(New_Staircase.transform);
                Amount_Current -= 1;
            }            
        }
    }


    public void Complete_Stair() 
    {
        Destroy_Stairs();
        Build_Stairs();
    }


}
