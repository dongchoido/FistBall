using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour,IPunchAble
{
    [SerializeField] bool isPlayer1;
    public MonoBehaviour _input;
    private IPlayerInput input;
    private PlayerMovement movement;
    private PlayerCombat combat;
    public bool canDash = true;
    private bool isDashing = false;
    private bool shouldDash;
    private Coroutine DashCooldownCoroutine;
    public bool stunned = false;
    private Coroutine StunnedCoroutine;
    private float stunnedDuration = 3f;
    PlayerAnimation anim;
    private float firstScale;
    private bool canPunch = true;
    private Coroutine punchCooldownCoroutine = null;
    private PlayerSFX sfx;
    private void Awake()
    {
        anim = GetComponent<PlayerAnimation>();
        movement = GetComponent<PlayerMovement>();
        combat = GetComponent<PlayerCombat>();
        input = _input.GetComponent<IPlayerInput>();
        sfx = GetComponent<PlayerSFX>();
        firstScale = transform.localScale.x;
    }

    private void Update()
    {
        if (!stunned && !isDashing && !combat.IsPunching())
        {
            movement.Move(input.Horizontal);
            anim.SetVelocity(movement.Velocity());
            if (input.Jump) { movement.Jump(); anim.SetJump(); sfx.Jump(); }
            if (input.Punch && canPunch)
            {
                combat.Punch();
                anim.SetMeleeAttack(isPlayer1);
                sfx.Punch();
                if (punchCooldownCoroutine != null) StopCoroutine(punchCooldownCoroutine);
                punchCooldownCoroutine = StartCoroutine(PunchCooldown());
            }
        }
        else movement.Stand();
        if (input.Dash && canDash) { shouldDash = true; }
        anim.SetGroundCheck(movement.IsGrounded());
    }
    void FixedUpdate()
    {
        if (shouldDash)
        {
                bool t = stunned;
                stunned = false;
                shouldDash = false;
                anim.SetStunning(false);
            if (DashCooldownCoroutine != null) StopCoroutine(DashCooldownCoroutine);
            DashCooldownCoroutine = StartCoroutine(DashCoolDown(t));
        }
    }
    IEnumerator DashCoolDown(bool t)
    {
        if (!t)
        { combat.Dash(transform.localScale.x / firstScale); isDashing = true; sfx.Dash(); }
        canDash = false;
        yield return new WaitForSeconds(0.4f);
        isDashing = false;
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
        anim.SetSimulateDamage();
        anim.SetStunning(true);
        sfx.Stun();
        yield return new WaitForSeconds(stunnedDuration);
        stunned = false;
        anim.SetStunning(false);
        StunnedCoroutine = null;
    }
    
    IEnumerator PunchCooldown()
    {
        canPunch = false;
        yield return new WaitForSeconds(4f);
        canPunch = true;
        punchCooldownCoroutine = null;
    }
}
