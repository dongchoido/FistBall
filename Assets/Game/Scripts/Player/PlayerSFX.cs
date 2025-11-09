using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    [SerializeField] AudioClip punch;
    [SerializeField] AudioClip dash;
    [SerializeField] AudioClip whip;
    [SerializeField] AudioClip jump;
    [SerializeField] AudioClip stun;
    [SerializeField] AudioClip run;
    public void Punch() => SoundManager.Instance.PlaySFX(punch);
    public void Dash() => SoundManager.Instance.PlaySFX(dash);
    public void Whip() => SoundManager.Instance.PlaySFX(whip);
    public void Jump() => SoundManager.Instance.PlaySFX(jump);
    public void Stun() => SoundManager.Instance.PlaySFX(stun);
    public void Run() => SoundManager.Instance.PlaySFX(run);
}
