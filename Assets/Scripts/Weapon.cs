using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collectable
{
    //Damage struct
    public int damagePoint = 1;
    public float pushForce = 2.0f;

    //Upgrade
    public int weaponLevel = 0;
    private SpriteRenderer spriteRenderer;

    //Swing
    private Animator animator;
    private float coolDown = 0.5f;
    private float lastSwing;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastSwing > coolDown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }
    }

    protected override void OnCollide(Collider2D collider2D)
    {
        if (collider2D.tag == "Fighter")
        {
            if (collider2D.name == "Player")
                return;

            //create a new damage object, then we'll send it to the fighter we have hit
            Damage damage = new Damage 
            { 
                damageAmount = damagePoint, 
                origin = transform.position, 
                pushForce = pushForce 
            };

            collider2D.SendMessage("ReceiveDamage", damage);
        }
    }

    private void Swing()
    {
        animator.SetTrigger("Swing");
    }
}
