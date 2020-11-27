using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Wall_Script : MonoBehaviour
{
    public Transform Parent;
    public Transform Bricks_Parent;
    [Space(3)]


    [Header("Bricks")]
    public GameObject Brick_1;
    public GameObject Brick_2;
    public GameObject Brick_3;
    
    [Space(3)]

    [Header("Walls")]
    public GameObject Wall_Type1;
    public GameObject Wall_Type2;
    public GameObject Wall_Type3;
    public GameObject Top_Piece;
    public GameObject Bottom_Piece;
    
    [Space(3)]

    [Header("Modifiers")]
    [Range(0, 100)] public int Brick1_Chance;
    [Range(0, 100)] public int Brick2_Chance;
    [Range(0, 100)] public int Brick3_Chance;
    [Range(0, 100)] public int Empty_Chance;
    public float Max_Rotation = 2;
    public float Min_Rotation = -2;
    public float Max_OffsetZ = 0;
    public float Min_OffsetZ = -0.15f;

    public string Wall_Type = "Left Stop";

    public bool Add_Bottom_Wall = false;
    public bool Add_Top_Wall = false;


    public void Randomize_The_Bricks() 
    {
        Randomize_Bricks();        
        Hide_special_Bricks();
        Remove_Cover_Ups();

    }


    public void Set_Wall() 
    {
        if (Add_Bottom_Wall == true)
        {
            Parent.GetChild(2).gameObject.SetActive(true);
            foreach (Transform child in Bricks_Parent.transform)
            {
                if (child.GetComponent<Brick_Info>().Bottom_Wall == true)
                {
                    child.gameObject.SetActive(true);
                }

            }
        }
        else
        {
            Parent.GetChild(2).gameObject.SetActive(false);
            foreach (Transform child in Bricks_Parent.transform)
            {
                if (child.GetComponent<Brick_Info>().Bottom_Wall == true)
                {
                    child.gameObject.SetActive(false);
                }

            }
        }
        if (Add_Top_Wall == true)
        {
            Parent.GetChild(1).gameObject.SetActive(true);
            foreach (Transform child in Bricks_Parent.transform)
            {
                if (child.GetComponent<Brick_Info>().Top_Wall == true)
                {
                    child.gameObject.SetActive(true);
                }
            }
        }
        else
        {
            Parent.GetChild(1).gameObject.SetActive(false);
            foreach (Transform child in Bricks_Parent.transform)
            {
                if (child.GetComponent<Brick_Info>().Top_Wall == true) 
                {
                    child.gameObject.SetActive(false);
                }
                
            }
        }
    }

    // Change the different walls

    public void Left_Pressed_Wall()
    { 
        if (Parent.GetChild(0).name.Substring(0, 6) == "Wall_1")
        {
            Change_Too_Wall_3();
        }
        else if (Parent.GetChild(0).name.Substring(0, 6) == "Wall_2")
        {
            Change_Too_Wall_1();
        }
        else if (Parent.GetChild(0).name.Substring(0, 6) == "Wall_3")
        {
            Change_Too_Wall_2();
        }
    }
    public void Right_Pressed_Wall()
    {
        if (Parent.GetChild(0).name.Substring(0, 6) == "Wall_1")
        {
            Change_Too_Wall_2();
        }
        else if (Parent.GetChild(0).name.Substring(0, 6) == "Wall_2")
        {
            Change_Too_Wall_3();
        }
        else if (Parent.GetChild(0).name.Substring(0, 6) == "Wall_3")
        {
            Change_Too_Wall_1();
        }
    }

    private void Change_Too_Wall_1() 
    {        
        GameObject New_Wall = Instantiate(Wall_Type1, transform.position, transform.localRotation) as GameObject;
        New_Wall.transform.SetParent(transform);
        New_Wall.transform.SetSiblingIndex(1);
        New_Wall.transform.localPosition = new Vector3(0, -2, 0);
        New_Wall.transform.localRotation = Quaternion.Euler(-90, 0, 0);
        DestroyImmediate(Parent.GetChild(0).gameObject);

        /*
        foreach (Transform child in transform)
        {
            if (child.name.Substring(0, 5) == "Brick")
            {
                child.gameObject.SetActive(true);
            }
        }
        */
    }
    private void Change_Too_Wall_2()
    {
        GameObject New_Wall = Instantiate(Wall_Type2, transform.position, transform.localRotation) as GameObject;
        New_Wall.transform.SetParent(transform);
        New_Wall.transform.SetSiblingIndex(1);
        New_Wall.transform.localPosition = new Vector3(0, -2, 0);
        New_Wall.transform.localRotation = Quaternion.Euler(-90, 0, 0);
        DestroyImmediate(Parent.GetChild(0).gameObject);

        /*
        foreach (Transform child in transform)
        {
            if (child.name.Substring(0, 5) == "Brick")
            {
                child.gameObject.SetActive(true);
            }
        }
        */
    }
    private void Change_Too_Wall_3()
    {
        GameObject New_Wall = Instantiate(Wall_Type3, transform.position, transform.localRotation) as GameObject;
        New_Wall.transform.SetParent(transform);
        New_Wall.transform.SetSiblingIndex(1);
        New_Wall.transform.localPosition = new Vector3(0, -2, 0);
        New_Wall.transform.localRotation = Quaternion.Euler(-90, 0, 0);
        DestroyImmediate(Parent.GetChild(0).gameObject);

        /*
        foreach (Transform child in transform)
        {
            if (child.name.Substring(0, 5) == "Brick")
            {
                child.gameObject.SetActive(true);
            }
        }
        */
    }

    // Change the wall type (continual etc)

    public void Left_Pressed_Type_Wall()
    {
        if (Wall_Type == "Left Stop")
        {
            Wall_Type = "Stop All";
        }
        else if (Wall_Type == "Stop All")
        {
            Wall_Type = "Continue Right";
        }
        else if (Wall_Type == "Continue Right")
        {
            Wall_Type = "Continue Left";
        }
        else if (Wall_Type == "Continue Left")
        {
            Wall_Type = "Right Stop";
        }
        else if (Wall_Type == "Right Stop")
        {
            Wall_Type = "Left Stop";
        }

    }

    public void Right_Pressed_Type_Wall()
    {
        if (Wall_Type == "Right Stop")
        {
            Wall_Type = "Continue Left";

        }
        else if (Wall_Type == "Continue Left")
        {
            Wall_Type = "Continue Right";
        }
        else if (Wall_Type == "Continue Right")
        {
            Wall_Type = "Stop All";
        }
        else if (Wall_Type == "Stop All")
        {
            Wall_Type = "Left Stop";
        }
        else if (Wall_Type == "Left Stop")
        {
            Wall_Type = "Right Stop";
        }

    }

    private void Hide_special_Bricks() 
    {
        foreach (Transform child in Bricks_Parent.transform) 
        {
            bool IsItLeft = child.gameObject.GetComponent<Brick_Info>().Left_Edge;
            bool IsItRight = child.gameObject.GetComponent<Brick_Info>().Right_Edge;
            bool IsItLeftCon = child.gameObject.GetComponent<Brick_Info>().Left_Continuation;
            bool IsItRightCon = child.gameObject.GetComponent<Brick_Info>().Right_Continuation;
            if (child.GetComponent<Brick_Info>().Normal == false)
            {
                // Left Stop situation
                if (Wall_Type == "Left Stop")
                {
                    if (IsItRight == true || IsItLeftCon == true)
                    {
                        child.gameObject.SetActive(false);
                    }
                    // Have to place the reveal true after or all other tiles will dissapear
                    else if (IsItLeft == true || IsItRightCon == true)
                    {
                        child.gameObject.SetActive(true);
                        Remove_Rough_Edges(child);
                    }

                }

                // Right Stop situation
                else if (Wall_Type == "Right Stop")
                {
                    if (IsItLeft == true || IsItRightCon == true)
                    {
                        child.gameObject.SetActive(false);
                    }
                    // Have to place the reveal true after or all other tiles will dissapear
                    else if (IsItRight == true || IsItLeftCon == true)
                    {
                        child.gameObject.SetActive(true);
                        Remove_Rough_Edges(child);
                    }

                }

                // Continue Left situation
                else if (Wall_Type == "Continue Left")
                {
                    if (IsItLeft == true  || IsItRight == true)
                    {
                        child.gameObject.SetActive(false);
                    }
                    // Have to place the reveal true after or all other tiles will dissapear
                    else if (IsItLeftCon == true || IsItRightCon == true)
                    {
                        child.gameObject.SetActive(true);
                        Remove_Rough_Edges(child);
                    }

                }

                // Continue Right Situation
                else if (Wall_Type == "Continue Right")
                {
                    if (IsItLeft == true || IsItRight == true)
                    {
                        child.gameObject.SetActive(false);
                    }
                    // Have to place the reveal true after or all other tiles will dissapear
                    else if (IsItLeftCon == true || IsItRightCon == true)
                    {
                        child.gameObject.SetActive(true);
                        Remove_Rough_Edges(child);
                    }
                }

                // Stop all Situation
                else if (Wall_Type == "Stop All")
                {
                    if (IsItLeftCon == true || IsItRightCon == true)
                    {
                        child.gameObject.SetActive(false);
                    }
                    // Have to place the reveal true after or all other tiles will dissapear
                    else if (IsItLeft == true || IsItRight == true)
                    {
                        child.gameObject.SetActive(true);
                        Remove_Rough_Edges(child);
                    }
                }
            }
            


        }
    }


    private void Remove_Rough_Edges(Transform child) 
    {
        if (Add_Bottom_Wall == true)
        {
            if (child.GetComponent<Brick_Info>().Bottom_Wall == true)
            {
                child.gameObject.SetActive(true);
            }
        }
        else
        {
            if (child.GetComponent<Brick_Info>().Bottom_Wall == true)
            {
                child.gameObject.SetActive(false);
            }
        }

        if (Add_Top_Wall == true)
        {
            if (child.GetComponent<Brick_Info>().Top_Wall == true)
            {
                child.gameObject.SetActive(true);
            }
        }
        else
        {
            if (child.GetComponent<Brick_Info>().Top_Wall == true)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
    public void showall() 
    {
        foreach (Transform child in Bricks_Parent.transform) 
        {
            child.gameObject.SetActive(true);
        }
    }

    private void Randomize_Depth()
    {
        foreach (Transform child in Bricks_Parent.transform)
        {
            if (child.GetComponent<Brick_Info>().Normal == true)
            {
                child.transform.localPosition = new Vector3(0, 0, Random.Range(0.166f + Max_OffsetZ, 0.166f - Min_OffsetZ));
            }
        }
        
    }

    private void Randomize_Rotation()
    {
        foreach (Transform child in Bricks_Parent.transform)
        {
            if (child.GetComponent<Brick_Info>().Normal == true) 
            {
                child.transform.localRotation = Quaternion.Euler(0.0f, Random.Range(Max_Rotation, Min_Rotation), 0.0f);
            }
            
        }
        

    }

    private int[] Determine_Brick_Chance(string Brick_Type)
    {
        int[] Chances = new int[2];
        if (Brick_Type == "Brick1")
        {
            Chances[0] = 0;
            Chances[1] = Brick1_Chance;
        }
        else if (Brick_Type == "Brick2")
        {
            Chances[0] = Brick1_Chance;
            Chances[1] = Brick1_Chance + Brick2_Chance;
        }
        else if (Brick_Type == "Brick3")
        {
            Chances[0] = Brick1_Chance + Brick2_Chance;
            Chances[1] = Brick1_Chance + Brick2_Chance + Brick3_Chance;
        }
        else if (Brick_Type == "Empty")
        {
            Chances[0] = Brick1_Chance + Brick2_Chance + Brick3_Chance;
            Chances[1] = Brick1_Chance + Brick2_Chance + Brick3_Chance + Empty_Chance;
        }

        return Chances;
    }

    private void Randomize_Bricks() 
    {
        foreach (Transform child in Bricks_Parent.transform) 
        {
            int Rand_Chance = Random.Range(0, 101);            
            if (Determine_Brick_Chance("Brick1")[0] < Rand_Chance && Rand_Chance <= Determine_Brick_Chance("Brick1")[1])
            {
                GameObject New_Brick = Instantiate(Brick_1, child.GetChild(0).transform.position, child.GetChild(0).transform.rotation);
                New_Brick.transform.SetParent(child);
                New_Brick.transform.SetAsLastSibling();
                New_Brick.transform.localScale = new Vector3(1, 1, 1);
                DestroyImmediate(child.GetChild(0).gameObject);

            }
            else if (Determine_Brick_Chance("Brick2")[0] < Rand_Chance && Rand_Chance <= Determine_Brick_Chance("Brick2")[1])
            {
                GameObject New_Brick = Instantiate(Brick_2, child.GetChild(0).transform.position, child.GetChild(0).transform.rotation);
                New_Brick.transform.SetParent(child);
                New_Brick.transform.SetAsLastSibling();
                New_Brick.transform.localScale = new Vector3(1, 1, 1);
                DestroyImmediate(child.GetChild(0).gameObject);
            }
            else if (Determine_Brick_Chance("Brick3")[0] < Rand_Chance && Rand_Chance <= Determine_Brick_Chance("Brick3")[1])
            {
                GameObject New_Brick = Instantiate(Brick_3, child.GetChild(0).transform.position, child.GetChild(0).transform.rotation);
                New_Brick.transform.SetParent(child);
                New_Brick.transform.SetAsLastSibling();
                New_Brick.transform.localScale = new Vector3(1, 1, 1);
                DestroyImmediate(child.GetChild(0).gameObject);
            }
            else if (Determine_Brick_Chance("Empty")[0] < Rand_Chance && Rand_Chance <= Determine_Brick_Chance("Empty")[1])
            {
                child.GetChild(0).gameObject.SetActive(false);
                
            }
        }
    }

    private void Remove_Cover_Ups() 
    {
        if (Parent.GetChild(0).name.Substring(0, 6) == "Wall_1") 
        {
            foreach (Transform child in Bricks_Parent) 
            {
                if (child.GetComponent<Brick_Info>().HiddenOn_Wall1 == true) 
                {
                    child.GetChild(0).gameObject.SetActive(false);
                }
            }
        }
        else if (Parent.GetChild(0).name.Substring(0, 6) == "Wall_2")
        {
            foreach (Transform child in Bricks_Parent)
            {
                if (child.GetComponent<Brick_Info>().HiddenOn_Wall2 == true)
                {
                    child.GetChild(0).gameObject.SetActive(false);
                }
            }
        }
        else if (Parent.GetChild(0).name.Substring(0, 6) == "Wall_3")
        {
            foreach (Transform child in Bricks_Parent)
            {
                if (child.GetComponent<Brick_Info>().HiddenOn_Wall3 == true)
                {
                    child.GetChild(0).gameObject.SetActive(false);
                }
            }
        }
    }

}
