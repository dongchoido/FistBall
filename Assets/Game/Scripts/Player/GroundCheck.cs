using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] float checkRadius = 0.1f;
    [SerializeField] LayerMask groundLayer;
    public bool Check()
    {
        return Physics2D.OverlapCircle(transform.position, checkRadius, groundLayer);
    }
}
