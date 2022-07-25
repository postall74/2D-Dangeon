using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Collidable : MonoBehaviour
{
    [SerializeField] ContactFilter2D _filter;

    private BoxCollider2D _collider;
    private Collider2D[] hits = new Collider2D[10];

    protected virtual void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
    {
        _collider.OverlapCollider(_filter, hits);
        
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;

            OnCollide(hits[i]);

            hits[i] = null;
        }
    }

    protected virtual void OnCollide(Collider2D collider2D)
    {
        
    }
}
