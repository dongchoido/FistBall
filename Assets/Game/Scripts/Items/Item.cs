using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private ConstManager.EffectType effectType;
    [SerializeField] PoolManager poolManager;
    private Rigidbody2D rb;
    private PlayerMovement playerMovement;
    private Coroutine speedBuffCoroutine;
    [SerializeField] float speedBuffDuration = 4f;
    private bool canTrigger = true;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnEnable()
    {
        OnWallCollide();
        rb.position = new Vector2(Random.Range(-10,10), 10);
        canTrigger = true;
        effectType = (ConstManager.EffectType)Random.Range(0, 3);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(ConstManager.playerTag) && canTrigger)
        {
            ApplyEffect();
            playerMovement = collision.collider.GetComponent<PlayerMovement>();
            canTrigger = false;
        }
    }

    private void ApplyEffect()
    {
        switch (effectType)
        {
            case 0:
                SpeedBuff();
                break;
        }
        PoolManager.instance.ReturnItem<Item>(this, ConstManager.item);
    }
    private void OnWallCollide()
    {
        rb.velocity = Vector2.zero;
        Vector2 dir = new Vector2(Random.Range(-1, 1),0);
        float force = Random.Range(1, 10);
        rb.AddForce(force*dir,ForceMode2D.Impulse);
    }

    private void SpeedBuff()
    {
        if (playerMovement != null)
        {
            if (speedBuffCoroutine != null)
            {

                playerMovement.SpeedDebuff();
                StopCoroutine(_SpeedBuff());
            }
            speedBuffCoroutine = StartCoroutine(_SpeedBuff());
        }
    }
    IEnumerator _SpeedBuff()
    {
        playerMovement.SpeedBuff();
        yield return new WaitForSeconds(speedBuffDuration);
        playerMovement.SpeedDebuff();
        speedBuffCoroutine = null;
    }
}
