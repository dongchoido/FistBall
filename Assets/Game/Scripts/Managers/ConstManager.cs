using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConstManager 
{
    public const string playerTag = "Player";
    public const string ballTag = "Ball";
    public const string wallTag = "Wall";
    public const string item = "Item";

    public const string animVelocityX = "velocityX";
    public const string animVelocityY = "velocityY";
    public const string animIsHorizontalMoving = "isHorizontalMoving";
    public const string animJump = "jump";
    public const string animIsGrounded = "isGrounded";
    public const string animMeleeAttack = "meleeAttack";
    public const string animReverseMeleeAttack = "rangeAttack";
    public const string animStunning = "stunning";
    public const string animSimulateDamage = "simulateDamage";
    public enum EffectType
    {
        Speedup,
        Boom,
        ResetSkill
    }
}
