using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Bricks_Information : MonoBehaviour
{
    [Header("Brick Existence")]
    public bool HiddenOn_Wall1;
    public bool HiddenOn_Wall2;
    public bool HiddenOn_Wall3;
    public bool HiddenOn_Wall4;
    public bool HiddenOn_Wall5;
    public bool HiddenOn_Wall6;
    public bool HiddenOn_Wall7;
    public bool HiddenOn_Wall8;
    public bool HiddenOn_Wall9;

    [Space(3)]
    [Header("Brick Modification")]
    public string Condition_Wall1;
    public string Condition_Wall2;
    public string Condition_Wall3;
    public string Condition_Wall4;
    public string Condition_Wall5;
    public string Condition_Wall6;
    public string Condition_Wall7;
    public string Condition_Wall8;
    public string Condition_Wall9;

    [Space(3)]
    [Header("Brick Specials")]
    public bool Left_Edge;
    public bool Right_Edge;
    public bool Right_Continuation;
    public bool Left_Continuation;
    public bool Normal;
}
