using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] bool isGoal1;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(ConstManager.ballTag))
        {
            int team = isGoal1 ? 1 : 2;
            Debug.Log("Goal for team " + team);
        }
    }
}
