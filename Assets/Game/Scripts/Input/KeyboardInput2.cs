using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput2 : MonoBehaviour, IPlayerInput
{
    public float Horizontal => 
        (Input.GetKey(KeyCode.RightArrow) ? 1 : 0) - (Input.GetKey(KeyCode.LeftArrow) ? 1 : 0);

    public bool Jump => Input.GetKeyDown(KeyCode.UpArrow);
    public bool Punch => Input.GetKeyDown(KeyCode.L);
    public bool Dash => Input.GetKeyDown(KeyCode.RightShift);
}
