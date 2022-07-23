using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public int hitPoint = 10;
    public int maxHitPoint = 10;
    public float pushRecoverySpeed = 0.1f;

    //Immunity
    protected float immuneTime = 1.0f;
    protected float lastImmune;

    //Push
    protected Vector3 pushDirection;

    //All fighters can ReceiveDamage / Die
    protected virtual void ReceiveDamage(Damage damage)
    {
        if(Time.time - lastImmune  > immuneTime)
        {
            lastImmune = Time.time;
            hitPoint -= damage.damageAmount;
            pushDirection = (transform.position - damage.origin).normalized * damage.pushForce;

            GameManager.Instance.ShowText(damage.damageAmount.ToString(), 25, Color.red, transform.position, Vector3.up * 25, 1.5f);

            if (hitPoint <= 0)
            {
                hitPoint = 0;
                Death();
            }
        }
    }

    protected virtual void Death()
    {

    }
}
