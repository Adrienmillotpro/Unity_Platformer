using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class PIllar_Script : MonoBehaviour
{
    public Transform Parent;    
    [Space(3)]
    [Header("Pillar Pieces")]
    public GameObject Tower_Bottom;
    public GameObject Tower_Middle;
    public GameObject Tower_Top;
    public GameObject Square_Tower_Bottom;
    public GameObject Square_Tower_Middle;
    public GameObject Square_Tower_Top;



    public bool Square;

    [Space(3)]
    [Header("Size")]
    [Range(0, 20)] public int Tower_Height;
    [Space(3)]

    [Header("Modifiers")]
    [Range(0, 100)] public int Brick1_Chance;
    [Range(0, 100)] public int Brick2_Chance;
    [Range(0, 100)] public int Brick3_Chance;
    [Range(0, 100)] public int Brick4_Chance;
    [Range(0, 100)] public int Brick5_Chance;
    [Range(0, 100)] public int Brick6_Chance;
    [Range(0, 100)] public int Empty_Chance;
    private int Size_Tower;

    private void OnValidate()
    {        
        Sort();
    }

    private void Change_Square() 
    {
        if (Square == true)
        {
            Vector3 old_pos = Parent.GetChild(0).position;
            Quaternion old_rota = Parent.GetChild(0).rotation;
            DestroyImmediate(Parent.GetChild(0).gameObject);
            GameObject New_Bottom_Tower = Instantiate(Square_Tower_Bottom, old_pos, old_rota);
            New_Bottom_Tower.transform.SetParent(Parent);
            New_Bottom_Tower.transform.SetAsFirstSibling();

            Vector3 old_pos_top = Parent.GetChild(1).position;
            Quaternion old_rota_top = Parent.GetChild(1).rotation;
            DestroyImmediate(Parent.GetChild(1).gameObject);
            GameObject New_Top_Tower = Instantiate(Square_Tower_Top, old_pos_top, old_rota_top);
            New_Top_Tower.transform.SetParent(Parent);
            New_Top_Tower.transform.SetSiblingIndex(1);
        }
        else 
        {
            Vector3 old_pos = Parent.GetChild(0).position;
            Quaternion old_rota = Parent.GetChild(0).rotation;
            DestroyImmediate(Parent.GetChild(0).gameObject);
            GameObject New_Bottom_Tower = Instantiate(Tower_Bottom, old_pos, old_rota);
            New_Bottom_Tower.transform.SetParent(Parent);
            New_Bottom_Tower.transform.SetAsFirstSibling();

            Vector3 old_pos_top = Parent.GetChild(1).position;
            Quaternion old_rota_top = Parent.GetChild(1).rotation;
            DestroyImmediate(Parent.GetChild(1).gameObject);
            GameObject New_Top_Tower = Instantiate(Tower_Top, old_pos_top, old_rota_top);
            New_Top_Tower.transform.SetParent(Parent);
            New_Top_Tower.transform.SetSiblingIndex(1);
        }
    }

    private void Sort() 
    {        
        foreach (Transform child in transform) 
        {
            if (child.name.Substring(0, 9) == "Tower_BOT") 
            {
                child.SetSiblingIndex(0);
            }
            if (child.name.Substring(0, 9) == "Tower_TOP")
            {
                child.SetSiblingIndex(1);
            }
        }
    }

    public void Randomize_Bricks() 
    {
        foreach (Transform child in Parent.transform) 
        {            
            child.gameObject.GetComponent<Pieces_Pillar>().Randomize_Total(Brick1_Chance, Brick2_Chance, Brick3_Chance, Brick4_Chance, Brick5_Chance, Brick6_Chance, Empty_Chance);
        }
    }



    public void Change_Size()
    {        
        Size_Tower = Tower_Height;
        Parent.GetChild(1).position = Parent.transform.position + new Vector3(0, Tower_Height + 1, 0);
        int new_Middles = Tower_Height;

        while (Parent.childCount > 2) 
        {
            DestroyImmediate(Parent.GetChild(2).gameObject);
        }


        for (int i = 0; i < new_Middles; i++) 
        {
            if (Square == true)
            {
                GameObject New_Middle_Square = Instantiate(Square_Tower_Middle, transform.position + new Vector3(0, i + 1, 0), Parent.GetChild(0).transform.rotation);
                New_Middle_Square.transform.SetParent(Parent);
            }
            else 
            {
                GameObject New_Middle_Circle = Instantiate(Tower_Middle, transform.position + new Vector3(0, i + 1, 0), Parent.GetChild(0).transform.rotation);
                New_Middle_Circle.transform.SetParent(Parent);
            }
            
        }
        Change_Square();

    }
}
