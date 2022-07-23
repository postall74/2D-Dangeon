using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : Collectable
{
    //Damage
    public int damage = 1;
    public float pushForce = 3;

    protected override void OnCollide(Collider2D collider2D)
    {
        if (collider2D.tag == "Fighter" && collider2D.name == "Player")
        {
            //Create a new damage object, before sending it to the fighter we have hit
            Damage newDamage = new Damage
            {
                damageAmount = damage,
                origin = transform.position,
                pushForce = pushForce
            };

            collider2D.SendMessage("ReceiveDamage", newDamage);
        }
    }
}