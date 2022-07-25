using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthingFountain : Collidable
{
    private float healCooldown = 1.0f;
    private float lastHeal;

    protected override void OnCollide(Collider2D collider2D)
    {
        if (collider2D.name != "Player")
            return;

        if (Time.time - lastHeal > healCooldown)
        {
            lastHeal = Time.time;
            GameManager.Instance.player.Heal();
        }
    }
}
