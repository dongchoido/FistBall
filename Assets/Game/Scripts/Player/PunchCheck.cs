using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchCheck : MonoBehaviour
{
    [SerializeField] bool player1;
    [SerializeField] Collider2D playerCol;
    void Awake()
    {
        Debug.Log("jirg");
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.CompareTag(ConstManager.playerTag) || collision.CompareTag(ConstManager.ballTag))
        {
            IPunchAble punchAble = collision.GetComponent<IPunchAble>();
            if (punchAble != null)
            {
                punchAble.OnPunch(playerCol,player1);
            }
        }
    }

}
