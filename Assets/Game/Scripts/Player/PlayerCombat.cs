using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerCombat : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] GameObject punchCheck;
    private Coroutine punchCoroutine;
    private void Awake() => rb = GetComponent<Rigidbody2D>();

    public void Punch()
    {
        if (punchCoroutine != null)
            StopCoroutine(punchCoroutine);
        punchCoroutine = StartCoroutine(Punching());
    }

    public void Dash(float direction)
    {
        rb.AddForce(new Vector2(direction, 0).normalized * 200f, ForceMode2D.Impulse);
    }

    IEnumerator Punching()
    {
        punchCheck.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        punchCheck.SetActive(false);
        punchCoroutine = null;
    }
}
