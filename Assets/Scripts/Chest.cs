using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    [SerializeField] private Sprite _emptyChest;
    [SerializeField] private int _coinAmount = 0;

    protected override void OnCollect()
    {
        if (!Collected)
        {
            Collected = true;
            GetComponent<SpriteRenderer>().sprite = _emptyChest;
            GameManager.Instance.coins += _coinAmount;
            GameManager.Instance.ShowText($"{_coinAmount} coin(s)", 25, Color.yellow, transform.position, Vector3.up * 50, 3.0f);
        }
    }
}
