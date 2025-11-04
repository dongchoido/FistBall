using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput1 : MonoBehaviour, IPlayerInput
{
    public float Horizontal => 
        (Input.GetKey(KeyCode.D) ? 1 : 0) - (Input.GetKey(KeyCode.A) ? 1 : 0);

    public bool Jump => Input.GetKeyDown(KeyCode.W);

    public bool Punch => Input.GetKeyDown(KeyCode.F);
    public bool Dash => Input.GetKeyDown(KeyCode.G);
}
