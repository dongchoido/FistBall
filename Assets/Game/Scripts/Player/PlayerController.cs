using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour,IPunchAble
{
    public MonoBehaviour _input;
    private IPlayerInput input;
    private PlayerMovement movement;
    private PlayerCombat combat;
    public bool canDash = true;
    private bool shouldDash;
    private Coroutine DashCooldownCoroutine;
    public bool stunned = false;//
    private Coroutine StunnedCoroutine;
    private float stunnedDuration = 3f;
    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        combat = GetComponent<PlayerCombat>();
        input = _input.GetComponent<IPlayerInput>();
    }

    private void Update()
    {
        if (!stunned)
        {
            movement.Move(input.Horizontal);
            if (input.Jump) movement.Jump();
            if (input.Punch) combat.Punch();
        }
        else movement.Stand();
        if (input.Dash && canDash) {shouldDash = true; }
    }
    void FixedUpdate()
    {
        if (shouldDash)
        {
            if (!stunned)
                combat.Dash(input.Horizontal != 0 ? input.Horizontal : 1);
            else
                stunned = false;
                shouldDash = false;
            if (DashCooldownCoroutine != null) StopCoroutine(DashCooldownCoroutine);
            DashCooldownCoroutine = StartCoroutine(DashCoolDown());
        }
    }
    IEnumerator DashCoolDown()
    {
        canDash = false;
        yield return new WaitForSeconds(5f);
        DashCooledDown();
        DashCooldownCoroutine = null;
    }
    void DashCooledDown()
    {
        if (!canDash)
        {
            canDash = true;
        }
    }

    public void OnPunch(Collider2D col,bool player)
    {
        if (StunnedCoroutine != null)
            StopCoroutine(StunnedCoroutine);
        StunnedCoroutine=StartCoroutine(Stunning());
    }
    
    IEnumerator Stunning()
    {
        stunned = true;
        yield return new WaitForSeconds(stunnedDuration);
        stunned = false;
        StunnedCoroutine = null;
    }
}
