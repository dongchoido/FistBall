using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPunchAble
{
    void OnPunch(Collider2D col,bool player);
}
