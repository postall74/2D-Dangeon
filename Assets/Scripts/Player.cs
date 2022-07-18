using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    private BoxCollider2D _collider;
    private Vector3 _moveDelta;


    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw(Horizontal);
        float vertical = Input.GetAxisRaw(Vertical);

        _moveDelta = new Vector3(horizontal, vertical, 0);

        if (_moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (_moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        transform.Translate(_moveDelta * Time.deltaTime);
    }
}
