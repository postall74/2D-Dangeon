using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialog : Collectable
{
    public string message;

    private float coolDown = 4.0f;
    private float lastShow;

    protected override void Start()
    {
        base.Start();
        lastShow -= coolDown;
    }

    protected override void OnCollide(Collider2D collider2D)
    {
        if (Time.time - lastShow > coolDown)
        {
            lastShow = Time.time;
            GameManager.Instance.ShowText(message, 25, Color.white, transform.position + new Vector3(0, 0.16f, 0), Vector3.zero, coolDown);
        }

    }
}
