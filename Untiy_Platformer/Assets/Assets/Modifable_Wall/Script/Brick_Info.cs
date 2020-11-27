using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Brick_Info : MonoBehaviour
{
    [Header("Brick Existence")]
    public bool HiddenOn_Wall1;
    public bool HiddenOn_Wall2;
    public bool HiddenOn_Wall3;

    [Space(3)]
    [Header("Part of wall")]
    public bool Top_Wall;
    public bool Middle_Wall;
    public bool Bottom_Wall;

    [Space(3)]
    [Header("Brick Specials")]
    public bool Left_Edge;
    public bool Right_Edge;
    public bool Right_Continuation;
    public bool Left_Continuation;
    public bool Normal;
}
