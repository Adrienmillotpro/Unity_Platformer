using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieces_Pillar : MonoBehaviour
{
    public GameObject Parent;
    [Space(3)]
    [Header("Bricks")]
    public GameObject Brick_1;
    public GameObject Brick_2;
    public GameObject Brick_3;
    public GameObject Brick_4;
    public GameObject Brick_5;
    public GameObject Brick_6;

    public void Randomize_Total(int B1_Chance, int B2_Chance, int B3_Chance, int B4_Chance, int B5_Chance, int B6_Chance, int Empty)
    {
        foreach (Transform child in Parent.transform)
        {
            Randomize_Bricks(B1_Chance,B2_Chance, B3_Chance, B4_Chance, B5_Chance, B6_Chance, Empty);
        }
    }



    private void Randomize_Bricks(int B1Chance, int B2Chance, int B3Chance, int B4Chance, int B5Chance, int B6Chance, int Empty) 
    {
        int[] Brick1_Poba = Determine_Brick_Chance("Brick1",B1Chance, B2Chance, B3Chance, B4Chance, B5Chance, B6Chance, Empty);
        int[] Brick2_Poba = Determine_Brick_Chance("Brick2", B1Chance, B2Chance, B3Chance, B4Chance, B5Chance, B6Chance, Empty);
        int[] Brick3_Poba = Determine_Brick_Chance("Brick3", B1Chance, B2Chance, B3Chance, B4Chance, B5Chance, B6Chance, Empty);
        int[] Brick4_Poba = Determine_Brick_Chance("Brick4", B1Chance, B2Chance, B3Chance, B4Chance, B5Chance, B6Chance, Empty);
        int[] Brick5_Poba = Determine_Brick_Chance("Brick5", B1Chance, B2Chance, B3Chance, B4Chance, B5Chance, B6Chance, Empty);
        int[] Brick6_Poba = Determine_Brick_Chance("Brick6", B1Chance, B2Chance, B3Chance, B4Chance, B5Chance, B6Chance, Empty);
        int[] Empty_Poba = Determine_Brick_Chance("Empty", B1Chance, B2Chance, B3Chance, B4Chance, B5Chance, B6Chance, Empty);

        foreach (Transform child in Parent.transform) 
        {
            int Rand_Chance = Random.Range(0, 101);
            if (Brick1_Poba[0] < Rand_Chance && Rand_Chance <= Brick1_Poba[1])
            {
                Vector3 old_pos = child.position;
                Quaternion old_rot = child.rotation;
                GameObject New_Brick = Instantiate(Brick_1, old_pos, old_rot);
                New_Brick.transform.SetParent(Parent.transform);
                DestroyImmediate(child.gameObject);
            }
            else if (Brick2_Poba[0] < Rand_Chance && Rand_Chance <= Brick2_Poba[1]) 
            {
                Vector3 old_pos = child.position;
                Quaternion old_rot = child.rotation;
                GameObject New_Brick = Instantiate(Brick_2, old_pos, old_rot);
                New_Brick.transform.SetParent(Parent.transform);
                DestroyImmediate(child.gameObject);
            }
            else if (Brick3_Poba[0] < Rand_Chance && Rand_Chance <= Brick3_Poba[1])
            {
                Vector3 old_pos = child.position;
                Quaternion old_rot = child.rotation;
                GameObject New_Brick = Instantiate(Brick_3, old_pos, old_rot);
                New_Brick.transform.SetParent(Parent.transform);
                DestroyImmediate(child.gameObject);
            }
            else if (Brick4_Poba[0] < Rand_Chance && Rand_Chance <= Brick4_Poba[1])
            {
                Vector3 old_pos = child.position;
                Quaternion old_rot = child.rotation;
                GameObject New_Brick = Instantiate(Brick_4, old_pos, old_rot);
                New_Brick.transform.SetParent(Parent.transform);
                DestroyImmediate(child.gameObject);
            }
            else if (Brick5_Poba[0] < Rand_Chance && Rand_Chance <= Brick5_Poba[1])
            {
                Vector3 old_pos = child.position;
                Quaternion old_rot = child.rotation;
                GameObject New_Brick = Instantiate(Brick_5, old_pos, old_rot);
                New_Brick.transform.SetParent(Parent.transform);
                DestroyImmediate(child.gameObject);
            }
            else if (Brick6_Poba[0] < Rand_Chance && Rand_Chance <= Brick6_Poba[1])
            {
                Vector3 old_pos = child.position;
                Quaternion old_rot = child.rotation;
                GameObject New_Brick = Instantiate(Brick_6, old_pos, old_rot);
                New_Brick.transform.SetParent(Parent.transform);
                DestroyImmediate(child.gameObject);
            }
            else if (Empty_Poba[0] < Rand_Chance && Rand_Chance <= Empty_Poba[1])
            {
                child.gameObject.SetActive(false);
            }

        }
    }
    private int[] Determine_Brick_Chance(string Brick_Type, int B1_Chance, int B2_Chance, int B3_Chance, int B4_Chance, int B5_Chance, int B6_Chance, int Empty_Chance) 
    {
        int[] Chances = new int[2];
        if (Brick_Type == "Brick1")
        {
            Chances[0] = 0;
            Chances[1] = B1_Chance;
        }
        else if (Brick_Type == "Brick2")
        {
            Chances[0] = B1_Chance;
            Chances[1] = B1_Chance + B2_Chance;
        }
        else if (Brick_Type == "Brick3")
        {
            Chances[0] = B1_Chance + B2_Chance;
            Chances[1] = B1_Chance + B2_Chance + B3_Chance;
        }
        else if (Brick_Type == "Brick4")
        {
            Chances[0] = B1_Chance + B2_Chance + B3_Chance;
            Chances[1] = B1_Chance + B2_Chance + B3_Chance + B4_Chance;
        }
        else if (Brick_Type == "Brick5")
        {
            Chances[0] = B1_Chance + B2_Chance + B3_Chance + B4_Chance;
            Chances[1] = B1_Chance + B2_Chance + B3_Chance + B4_Chance + B5_Chance;
        }
        else if (Brick_Type == "Brick6")
        {
            Chances[0] = B1_Chance + B2_Chance + B3_Chance + B4_Chance + B5_Chance;
            Chances[1] = B1_Chance + B2_Chance + B3_Chance + B4_Chance + B5_Chance + B6_Chance;
        }
        else if (Brick_Type == "Empty")
        {
            Chances[0] = B1_Chance + B2_Chance + B3_Chance + B4_Chance + B5_Chance + B6_Chance;
            Chances[1] = B1_Chance + B2_Chance + B3_Chance + B4_Chance + B5_Chance + B6_Chance + Empty_Chance;
        }

        return Chances;
    }
}
