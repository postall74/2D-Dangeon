using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    //Experience
    public int experienceValue = 1;

    //Logic
    public float triggerLenght = 1;
    public float chaseLenght = 5;
    private bool chasing;
    private bool collideWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPosition;

    //Hitbox
    public ContactFilter2D filter;
    private BoxCollider2D hitBox;
    private Collider2D[] hits = new Collider2D[10];

    protected override void Start()
    {
        base.Start();
        playerTransform = GameManager.Instance.player.transform;
        startingPosition = transform.position;
        hitBox = transform.GetComponentInChildren<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        //Is the player in range?
        if (Vector3.Distance(playerTransform.position, startingPosition) < chaseLenght)
        {
            if (Vector3.Distance(playerTransform.position, startingPosition) < triggerLenght)
                chasing = true;

            if (chasing)
            {
                if (!collideWithPlayer)
                    UpdateMotor((playerTransform.position - transform.position).normalized);
            }
            else
                UpdateMotor(startingPosition - transform.position);
        }
        else
        {
            UpdateMotor(startingPosition - transform.position);
            chasing = false;
        }

        //Check for overlaps
        collideWithPlayer = false;
        collider.OverlapCollider(filter, hits);

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;

            if (hits[i].tag == "Fighters" && hits[i].name == "Player")
                collideWithPlayer = true;


            hits[i] = null;
        }
    }

    protected override void Death()
    {
        Destroy(gameObject);
        GameManager.Instance.experience += experienceValue;
        GameManager.Instance.ShowText($"+{experienceValue} exp", 25, Color.magenta, transform.position, Vector3.up * 50, 1.5f);
    }
}