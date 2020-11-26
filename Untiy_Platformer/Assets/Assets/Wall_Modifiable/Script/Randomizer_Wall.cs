using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Randomizer_Wall : MonoBehaviour
{
    public Transform Parent;
    [Space(3)]


    [Header("Bricks")]
    public GameObject Brick_1;
    public GameObject Brick_2;
    public GameObject Brick_3;
    public GameObject Brick_4;
    public GameObject Brick_5;
    public GameObject Brick_6;
    [Space(3)]

    [Header("Walls")]
    public GameObject Wall_Type1;
    public GameObject Wall_Type2;
    public GameObject Wall_Type3;
    public GameObject Wall_Type4;
    public GameObject Wall_Type5;
    public GameObject Wall_Type6;
    public GameObject Wall_Type7;
    public GameObject Wall_Type8;
    public GameObject Wall_Type9;
    [Space(3)]

    [Header("Modifiers")]
    [Range(0, 100)] public int Brick1_Chance;
    [Range(0, 100)] public int Brick2_Chance;
    [Range(0, 100)] public int Brick3_Chance;
    [Range(0, 100)] public int Brick4_Chance;
    [Range(0, 100)] public int Brick5_Chance;
    [Range(0, 100)] public int Brick6_Chance;
    [Range(0, 100)] public int Empty_Chance;
    public float Max_Rotation = 2;
    public float Min_Rotation = -2;
    public float Max_OffsetZ = 0;
    public float Min_OffsetZ = -0.15f;

    public string Wall_Type = "Left Stop";


    public void Randomize_Layout()
    {
        foreach (Transform child in transform)
        {
            if (child.name.Substring(0, 5) == "Brick")
            {
                Randomize_Brick(child.GetChild(0).gameObject, child);
                Randomize_Depth(child.GetChild(0).gameObject);
                if (child.name.Substring(6, 3) == "LEF" || child.name.Substring(6, 3) == "RIG")
                    Randomize_Rotation(child.GetChild(0).gameObject, true);
                else
                    Randomize_Rotation(child.GetChild(0).gameObject, false);

                // Spawns all the normal bricks
                Spawn_Normal_Bricks(child.gameObject);
                // Removes bricks if they are infront of a hole
                Modify_Bricks_if_Needed(child.gameObject);
                // Removes and adds the exterior bricks
                Special_Bricks(child.gameObject);

            }
        }

    }

    // Left Stop, Right Stop, Continue Left, Continue Right, Stop All
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

    //---------------------------------------------------------
    public void Left_Pressed_Wall()
    {
        if (Parent.GetChild(0).name.Substring(0, 5) == "Wall1")
        {
            Change_Too_Wall_9();
        }
        else if (Parent.GetChild(0).name.Substring(0, 5) == "Wall2")
        {
            Change_Too_Wall_1();
        }
        else if (Parent.GetChild(0).name.Substring(0, 5) == "Wall3")
        {
            Change_Too_Wall_2();
        }
        else if (Parent.GetChild(0).name.Substring(0, 5) == "Wall4")
        {
            Change_Too_Wall_3();
        }
        else if (Parent.GetChild(0).name.Substring(0, 5) == "Wall5")
        {
            Change_Too_Wall_4();
        }
        else if (Parent.GetChild(0).name.Substring(0, 5) == "Wall6")
        {
            Change_Too_Wall_5();
        }
        else if (Parent.GetChild(0).name.Substring(0, 5) == "Wall7")
        {
            Change_Too_Wall_6();
        }
        else if (Parent.GetChild(0).name.Substring(0, 5) == "Wall8")
        {
            Change_Too_Wall_7();
        }
        else if (Parent.GetChild(0).name.Substring(0, 5) == "Wall9")
        {
            Change_Too_Wall_8();
        }
    }

    public void Right_Pressed_Wall()
    {
        if (Parent.GetChild(0).name.Substring(0, 5) == "Wall1")
        {
            Change_Too_Wall_2();
        }
        else if (Parent.GetChild(0).name.Substring(0, 5) == "Wall2")
        {
            Change_Too_Wall_3();
        }
        else if (Parent.GetChild(0).name.Substring(0, 5) == "Wall3")
        {
            Change_Too_Wall_4();
        }
        else if (Parent.GetChild(0).name.Substring(0, 5) == "Wall4")
        {
            Change_Too_Wall_5();
        }
        else if (Parent.GetChild(0).name.Substring(0, 5) == "Wall5")
        {
            Change_Too_Wall_6();
        }
        else if (Parent.GetChild(0).name.Substring(0, 5) == "Wall6")
        {
            Change_Too_Wall_7();
        }
        else if (Parent.GetChild(0).name.Substring(0, 5) == "Wall7")
        {
            Change_Too_Wall_8();
        }
        else if (Parent.GetChild(0).name.Substring(0, 5) == "Wall8")
        {
            Change_Too_Wall_9();
        }
        else if (Parent.GetChild(0).name.Substring(0, 5) == "Wall9")
        {
            Change_Too_Wall_1();
        }
    }

    private void Change_Too_Wall_1()
    {
        GameObject New_Wall = Instantiate(Wall_Type1, transform.position, transform.localRotation) as GameObject;
        New_Wall.transform.SetParent(transform);
        New_Wall.transform.SetSiblingIndex(1);
        DestroyImmediate(Parent.GetChild(0).gameObject);

        foreach (Transform child in transform)
        {
            if (child.name.Substring(0, 5) == "Brick")
            {
                child.gameObject.SetActive(true);
            }
        }
    }
    private void Change_Too_Wall_2()
    {
        GameObject New_Wall = Instantiate(Wall_Type2, transform.position, transform.localRotation) as GameObject;
        New_Wall.transform.SetParent(transform);
        New_Wall.transform.SetSiblingIndex(1);
        DestroyImmediate(Parent.GetChild(0).gameObject);

        foreach (Transform child in transform)
        {
            if (child.name.Substring(0, 5) == "Brick")
            {
                if (child.tag.ToString() == "Absent_Wall2")
                {
                    child.gameObject.SetActive(false);
                }
                else
                {
                    child.gameObject.SetActive(true);
                }
            }
        }
    }
    private void Change_Too_Wall_3()
    {
        GameObject New_Wall = Instantiate(Wall_Type3, transform.position, transform.localRotation) as GameObject;
        New_Wall.transform.SetParent(transform);
        New_Wall.transform.SetSiblingIndex(1);
        DestroyImmediate(Parent.GetChild(0).gameObject);

        foreach (Transform child in transform)
        {
            if (child.name.Substring(0, 5) == "Brick")
            {
                child.gameObject.SetActive(true);
            }
        }
    }
    private void Change_Too_Wall_4()
    {
        GameObject New_Wall = Instantiate(Wall_Type4, transform.position, transform.localRotation) as GameObject;
        New_Wall.transform.SetParent(transform);
        New_Wall.transform.SetSiblingIndex(1);
        DestroyImmediate(Parent.GetChild(0).gameObject);

        foreach (Transform child in transform)
        {
            if (child.name.Substring(0, 5) == "Brick")
            {
                child.gameObject.SetActive(true);
            }
        }
    }
    private void Change_Too_Wall_5()
    {
        GameObject New_Wall = Instantiate(Wall_Type5, transform.position, transform.localRotation) as GameObject;
        New_Wall.transform.SetParent(transform);
        New_Wall.transform.SetSiblingIndex(1);
        DestroyImmediate(Parent.GetChild(0).gameObject);

        foreach (Transform child in transform)
        {
            if (child.name.Substring(0, 5) == "Brick")
            {
                child.gameObject.SetActive(true);
            }
        }
    }
    private void Change_Too_Wall_6()
    {
        GameObject New_Wall = Instantiate(Wall_Type6, transform.position, transform.localRotation) as GameObject;
        New_Wall.transform.SetParent(transform);
        New_Wall.transform.SetSiblingIndex(1);
        DestroyImmediate(Parent.GetChild(0).gameObject);

        foreach (Transform child in transform)
        {
            if (child.name.Substring(0, 5) == "Brick")
            {
                child.gameObject.SetActive(true);
            }
        }
    }
    private void Change_Too_Wall_7()
    {
        GameObject New_Wall = Instantiate(Wall_Type7, transform.position, transform.localRotation) as GameObject;
        New_Wall.transform.SetParent(transform);
        New_Wall.transform.SetSiblingIndex(1);
        DestroyImmediate(Parent.GetChild(0).gameObject);

        foreach (Transform child in transform)
        {
            if (child.name.Substring(0, 5) == "Brick")
            {
                child.gameObject.SetActive(true);
            }
        }
    }
    private void Change_Too_Wall_8()
    {
        GameObject New_Wall = Instantiate(Wall_Type8, transform.position, transform.localRotation) as GameObject;
        New_Wall.transform.SetParent(transform);
        New_Wall.transform.SetSiblingIndex(1);
        New_Wall.transform.localScale = new Vector3(150, 300, 150);
        New_Wall.transform.localRotation = Quaternion.Euler(-90, 90, -90);
        New_Wall.transform.localPosition = new Vector3(0, 0, 1.5f);
        DestroyImmediate(Parent.GetChild(0).gameObject);

        foreach (Transform child in transform)
        {
            if (child.name.Substring(0, 5) == "Brick")
            {
                child.gameObject.SetActive(true);
            }
        }
    }
    private void Change_Too_Wall_9() 
    {
        GameObject New_Wall = Instantiate(Wall_Type9, transform.position, transform.localRotation) as GameObject;
        New_Wall.transform.SetParent(transform);
        New_Wall.transform.SetSiblingIndex(1);
        New_Wall.transform.localPosition = new Vector3(-3, 0, 0.95f);
        DestroyImmediate(Parent.GetChild(0).gameObject);
        foreach (Transform child in transform)
        {
            if (child.name.Substring(0, 5) == "Brick")
            {
                child.gameObject.SetActive(true);
            }
        }
    }


    //--------------------------------------------------------
    private void Randomize_Depth(GameObject Brick)
    {
        Brick.transform.localPosition = new Vector3(0, 0, Random.Range(Max_OffsetZ, Min_OffsetZ));
    }

    private void Randomize_Rotation(GameObject Brick, bool Edges)
    {
        if (Edges == true)
        {
            Brick.transform.localRotation = Quaternion.Euler(0.0f, Random.Range(90 + Max_Rotation, 90 + Min_Rotation), 0.0f);
        }
        else
        {
            Brick.transform.localRotation = Quaternion.Euler(0.0f, Random.Range(Max_Rotation, Min_Rotation), 0.0f);
        }

    }

    private void Randomize_Brick(GameObject Brick, Transform Child)
    {
        if (Child.name.Substring(6, 3) == "LEF" || Child.name.Substring(6, 3) == "RIG")
        {
            int Rand_Chance = Random.Range(0, 101);
            if ((Determine_Brick_Chance("Empty")[0] < Rand_Chance && Rand_Chance <= Determine_Brick_Chance("Empty")[1]))
            {
                Brick.SetActive(false);
            }
            else
            {
                GameObject New_Brick = Instantiate(Brick_1, Brick.transform.position, Brick.transform.localRotation);
                New_Brick.transform.SetParent(Child);
                DestroyImmediate(Brick);
            }

        }
        else
        {
            int Rand_Chance = Random.Range(0, 101);
            if (Determine_Brick_Chance("Brick1")[0] < Rand_Chance && Rand_Chance <= Determine_Brick_Chance("Brick1")[1])
            {
                GameObject New_Brick = Instantiate(Brick_1, Brick.transform.position, Brick.transform.localRotation);
                New_Brick.transform.SetParent(Child);
                DestroyImmediate(Brick);
            }
            else if (Determine_Brick_Chance("Brick2")[0] < Rand_Chance && Rand_Chance <= Determine_Brick_Chance("Brick2")[1])
            {
                GameObject New_Brick = Instantiate(Brick_2, Brick.transform.position, Brick.transform.localRotation);
                New_Brick.transform.SetParent(Child);
                DestroyImmediate(Brick);
            }
            else if (Determine_Brick_Chance("Brick3")[0] < Rand_Chance && Rand_Chance <= Determine_Brick_Chance("Brick3")[1])
            {
                GameObject New_Brick = Instantiate(Brick_3, Brick.transform.position, Brick.transform.localRotation);
                New_Brick.transform.SetParent(Child);
                DestroyImmediate(Brick);
            }
            else if (Determine_Brick_Chance("Brick4")[0] < Rand_Chance && Rand_Chance <= Determine_Brick_Chance("Brick4")[1])
            {
                GameObject New_Brick = Instantiate(Brick_4, Brick.transform.position, Brick.transform.localRotation);
                New_Brick.transform.SetParent(Child);
                DestroyImmediate(Brick);
            }
            else if (Determine_Brick_Chance("Brick5")[0] < Rand_Chance && Rand_Chance <= Determine_Brick_Chance("Brick5")[1])
            {
                GameObject New_Brick = Instantiate(Brick_5, Brick.transform.position, Brick.transform.localRotation);
                New_Brick.transform.SetParent(Child);
                DestroyImmediate(Brick);
            }
            else if (Determine_Brick_Chance("Brick6")[0] < Rand_Chance && Rand_Chance <= Determine_Brick_Chance("Brick6")[1])
            {
                GameObject New_Brick = Instantiate(Brick_6, Brick.transform.position, Brick.transform.localRotation);
                New_Brick.transform.SetParent(Child);
                DestroyImmediate(Brick);
            }
            else if (Determine_Brick_Chance("Empty")[0] < Rand_Chance && Rand_Chance <= Determine_Brick_Chance("Empty")[1])
            {
                Brick.SetActive(false);
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
        else if (Brick_Type == "Brick4")
        {
            Chances[0] = Brick1_Chance + Brick2_Chance + Brick3_Chance;
            Chances[1] = Brick1_Chance + Brick2_Chance + Brick3_Chance + Brick4_Chance;
        }
        else if (Brick_Type == "Brick5")
        {
            Chances[0] = Brick1_Chance + Brick2_Chance + Brick3_Chance + Brick4_Chance;
            Chances[1] = Brick1_Chance + Brick2_Chance + Brick3_Chance + Brick4_Chance + Brick5_Chance;
        }
        else if (Brick_Type == "Brick6")
        {
            Chances[0] = Brick1_Chance + Brick2_Chance + Brick3_Chance + Brick4_Chance + Brick5_Chance;
            Chances[1] = Brick1_Chance + Brick2_Chance + Brick3_Chance + Brick4_Chance + Brick5_Chance + Brick6_Chance;
        }
        else if (Brick_Type == "Empty")
        {
            Chances[0] = Brick1_Chance + Brick2_Chance + Brick3_Chance + Brick4_Chance + Brick5_Chance + Brick6_Chance;
            Chances[1] = Brick1_Chance + Brick2_Chance + Brick3_Chance + Brick4_Chance + Brick5_Chance + Brick6_Chance + Empty_Chance;
        }

        return Chances;
    }


    private void Modify_Bricks_if_Needed(GameObject Child)
    {
        Transform InnerChild = Child.transform.GetChild(0);

        bool Wall1 = Child.GetComponent<Bricks_Information>().HiddenOn_Wall1;
        bool Wall2 = Child.GetComponent<Bricks_Information>().HiddenOn_Wall2;
        bool Wall3 = Child.GetComponent<Bricks_Information>().HiddenOn_Wall3;
        bool Wall4 = Child.GetComponent<Bricks_Information>().HiddenOn_Wall4;
        bool Wall5 = Child.GetComponent<Bricks_Information>().HiddenOn_Wall5;
        bool Wall6 = Child.GetComponent<Bricks_Information>().HiddenOn_Wall6;
        bool Wall7 = Child.GetComponent<Bricks_Information>().HiddenOn_Wall7;
        bool Wall8 = Child.GetComponent<Bricks_Information>().HiddenOn_Wall8;
        bool Wall9 = Child.GetComponent<Bricks_Information>().HiddenOn_Wall9;


        if (Wall1 == true && Parent.GetChild(0).name.Substring(0, 5) == "Wall1")
        {
            Child.SetActive(false);
        }
        if (Wall2 == true && Parent.GetChild(0).name.Substring(0, 5) == "Wall2")
        {
            Child.SetActive(false);
        }
        if (Wall3 == true && Parent.GetChild(0).name.Substring(0, 5) == "Wall3")
        {
            Child.SetActive(false);
        }
        if (Wall4 == true && Parent.GetChild(0).name.Substring(0, 5) == "Wall4")
        {
            Child.SetActive(false);
        }
        if (Wall5 == true && Parent.GetChild(0).name.Substring(0, 5) == "Wall5")
        {
            Child.SetActive(false);
        }
        if (Wall6 == true && Parent.GetChild(0).name.Substring(0, 5) == "Wall6")
        {
            Child.SetActive(false);
        }
        if (Wall7 == true && Parent.GetChild(0).name.Substring(0, 5) == "Wall7")
        {
            Child.SetActive(false);
        }
        if (Wall8 == true && Parent.GetChild(0).name.Substring(0, 5) == "Wall8")
        {
            Child.SetActive(false);
        }
        if (Wall9 == true && Parent.GetChild(0).name.Substring(0, 5) == "Wall9")
        {
            Child.SetActive(false);
        }

    }

    private void Special_Bricks(GameObject child) 
    {
        // Left Stop, Right Stop, Continue Left, Continue Right, Stop All        
            bool IsItLeft = child.gameObject.GetComponent<Bricks_Information>().Left_Edge;
            bool IsItRight = child.gameObject.GetComponent<Bricks_Information>().Right_Edge;
            bool IsItLeftCon = child.gameObject.GetComponent<Bricks_Information>().Left_Continuation;
            bool IsItRightCon = child.gameObject.GetComponent<Bricks_Information>().Right_Continuation;

        if (child.GetComponent<Bricks_Information>().Normal == false) 
        {
            // Left Stop situation
            if (Wall_Type == "Left Stop")
            {
                if (IsItRight == true || IsItLeftCon == true)
                {
                    child.transform.GetChild(0).gameObject.SetActive(false);
                }
                // Have to place the reveal true after or all other tiles will dissapear
                else if (IsItLeft == true || IsItRightCon == true)
                {
                    child.transform.GetChild(0).gameObject.SetActive(true);
                }



            }

            // Right Stop situation
            else if (Wall_Type == "Right Stop")
            {
                if (IsItLeft == true || IsItRightCon == true)
                {
                    child.transform.GetChild(0).gameObject.SetActive(false);
                }
                // Have to place the reveal true after or all other tiles will dissapear
                else if (IsItRight == true || IsItLeftCon == true)
                {
                    child.transform.GetChild(0).gameObject.SetActive(true);
                }

            }

            // Continue Left situation
            else if (Wall_Type == "Continue Left")
            {
                if (IsItLeft == true || IsItRightCon == true || IsItRight == true)
                {
                    child.transform.GetChild(0).gameObject.SetActive(false);
                }
                // Have to place the reveal true after or all other tiles will dissapear
                else if (IsItLeftCon == true)
                {
                    child.transform.GetChild(0).gameObject.SetActive(true);
                }

            }

            // Continue Right Situation
            else if (Wall_Type == "Continue Right")
            {
                if (IsItLeft == true || IsItLeftCon == true || IsItRight == true)
                {
                    child.transform.GetChild(0).gameObject.SetActive(false);
                }
                // Have to place the reveal true after or all other tiles will dissapear
                else if (IsItRightCon == true)
                {
                    child.transform.GetChild(0).gameObject.SetActive(true);
                }
            }

            // Stop all Situation
            else if (Wall_Type == "Stop All")
            {
                if (IsItLeftCon == true || IsItRightCon == true)
                {
                    child.transform.GetChild(0).gameObject.SetActive(false);
                }
                // Have to place the reveal true after or all other tiles will dissapear
                else if (IsItLeft == true || IsItRight == true)
                {
                    child.transform.GetChild(0).gameObject.SetActive(true);
                }
            }
        }            
 
    }

    private void Spawn_Normal_Bricks(GameObject child) 
    {
        if (child.GetComponent<Bricks_Information>().Normal == true) 
        {
            child.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
