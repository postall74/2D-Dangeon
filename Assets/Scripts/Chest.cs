using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    [SerializeField] private Sprite _emptyChest;
    [SerializeField] private int _coinAmount = 10;

    protected override void OnCollect()
    {
        if (!Collected)
        {
            Collected = true;
            GetComponent<SpriteRenderer>().sprite = _emptyChest;
            Debug.Log($"Grand {_coinAmount} coins");
        }
    }
}
