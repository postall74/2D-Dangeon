using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collectable
{
    //Damage struct
    public int[] damagePoint = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
    public float[] pushForce = { 2.0f, 2.2f, 2.4f, 2.6f, 2.8f, 3.0f, 3.2f, 3.4f, 3.6f, 3.8f, 4.0f, 4.2f, 4.4f, 4.6f, 4.8f, 5.0f, 5.2f };

    //Upgrade
    public int weaponLevel = 0;
    public SpriteRenderer spriteRenderer;

    //Swing
    private Animator animator;
    private float coolDown = 0.5f;
    private float lastSwing;


    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetMouseButtonDown(0))
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
                damageAmount = damagePoint[weaponLevel],
                origin = transform.position,
                pushForce = pushForce[weaponLevel]
            };

            collider2D.SendMessage("ReceiveDamage", damage);
        }
    }

    private void Swing()
    {
        animator.SetTrigger("Swing");
    }

    public void UpgradeWeapon()
    {
        weaponLevel++;
        spriteRenderer.sprite = GameManager.Instance.weaponSprites[weaponLevel];
    }

    public void SetLevelWeapon(int level)
    {
        weaponLevel = level;
        spriteRenderer.sprite = GameManager.Instance.weaponSprites[weaponLevel];
    }
}
