using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private float direction;
    void Awake()
    {
        direction = transform.localScale.x;
        anim = GetComponent<Animator>();
    }
    public void SetVelocity(Vector2 velocity)
    {
        anim.SetFloat(ConstManager.animVelocityX, velocity.x);
        anim.SetFloat(ConstManager.animVelocityY, velocity.y);
        anim.SetBool(ConstManager.animIsHorizontalMoving, Mathf.Abs(velocity.x) >= 0.01f);
        if (velocity.x > 0) transform.localScale = new Vector2(direction, transform.localScale.y);
        else if (velocity.x < 0) transform.localScale = new Vector2(-direction, transform.localScale.y);
    }
    public void SetJump()
    {
        anim.SetTrigger(ConstManager.animJump);
    }
    public void SetMeleeAttack(bool isPLayer1)
    {
        if (isPLayer1 ^ (direction == transform.localScale.x))
            anim.SetTrigger(ConstManager.animMeleeAttack);
        else
            anim.SetTrigger(ConstManager.animReverseMeleeAttack);
    }
    public void SetGroundCheck(bool isGrounded)
    {
        anim.SetBool(ConstManager.animIsGrounded, isGrounded);
    }
    public void SetStunning(bool t)
    {
        anim.SetBool(ConstManager.animStunning, t);
    }
    public void SetSimulateDamage()
    {
        anim.SetTrigger(ConstManager.animSimulateDamage);
    }
}
