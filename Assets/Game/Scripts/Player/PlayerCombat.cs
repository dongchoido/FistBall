using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerCombat : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] GameObject punchCheck;
    private Coroutine punchCoroutine;
    private bool isPunching = false;
    private void Awake() => rb = GetComponent<Rigidbody2D>();

    public void Punch()
    {
        if (punchCoroutine != null)
            StopCoroutine(punchCoroutine);
        punchCoroutine = StartCoroutine(Punching());
    }

    public void Dash(float direction)
    {
        rb.velocity = new Vector2(direction, 0).normalized * 100f;
    }

    IEnumerator Punching()
    {
        isPunching = true;
        punchCheck.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        isPunching = false;
        punchCheck.SetActive(false);
        punchCoroutine = null;
    }
    public bool IsPunching() => isPunching;
    
}
