using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour,IPunchAble
{
    [SerializeField] float force = 5f;
    private Rigidbody2D rb;
    private Collider2D myCol;
    Coroutine ignoreColliderCoroutine;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        myCol = GetComponent<Collider2D>();
    }

    public void OnPunch(Collider2D col, bool player)
    {
        rb.velocity = Vector2.zero;
        float dir = player ? 1 : -1;
        if (ignoreColliderCoroutine != null)
            StopCoroutine(ignoreColliderCoroutine);
        ignoreColliderCoroutine = StartCoroutine(IgnorePlayerCollider(col));
        rb.AddForce(new Vector2(dir, 1) * force, ForceMode2D.Impulse);
    }
    IEnumerator IgnorePlayerCollider(Collider2D col)
    {
        Physics2D.IgnoreCollision(myCol, col, true);
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreCollision(myCol, col, false);
        ignoreColliderCoroutine = null;
    }
}
