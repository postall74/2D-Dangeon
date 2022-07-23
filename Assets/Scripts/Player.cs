using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class Player : Mover
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw(Horizontal);
        float vertica = Input.GetAxisRaw(Vertical);

        UpdateMotor(new Vector3(horizontal, vertica, 0));
    }
}
