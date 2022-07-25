using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class Player : Mover
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    private SpriteRenderer spriteRenderer;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void ReceiveDamage(Damage damage)
    {
        base.ReceiveDamage(damage);
        GameManager.Instance.OnHitPointChange();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw(Horizontal);
        float vertica = Input.GetAxisRaw(Vertical);

        UpdateMotor(new Vector3(horizontal, vertica, 0));
    }

    public void SwapSprite(int skinId)
    {
        spriteRenderer.sprite = GameManager.Instance.playerSprites[skinId];
    }

    public void OnLevelUp()
    {
        maxHitPoint++;
        hitPoint = maxHitPoint;
    }

    public void SetLevel(int level)
    {
        for (int i = 0; i < level; i++)
        {
            OnLevelUp();
        }
    }

    public void Heal()
    {
        if (hitPoint == maxHitPoint)
            return;

        GameManager.Instance.ShowText($"+{maxHitPoint - hitPoint} + HP", 25, Color.green, transform.position, Vector3.up * 50, 1.0f);
        hitPoint = maxHitPoint;
        GameManager.Instance.OnHitPointChange(); 
    }
}
