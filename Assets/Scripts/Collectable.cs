using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable
{
    protected bool Collected;
    
    protected override void OnCollide(Collider2D collider2D)
    {
        if (collider2D.name == "Player") 
            OnCollect();
    }
    
    protected virtual void OnCollect()
    {
        Collected = true;
    }
}
