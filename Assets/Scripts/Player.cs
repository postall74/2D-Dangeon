using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    private const string Actors = "Actors";
    private const string Blocking = "Blocking";

    private BoxCollider2D _collider;
    private Vector3 _moveDelta;
    private RaycastHit2D _hit;


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

        _hit = Physics2D.BoxCast(transform.position, _collider.size, 0, new Vector2(0, _moveDelta.y), Mathf.Abs(_moveDelta.y * Time.deltaTime), LayerMask.GetMask(Actors, Blocking));

        if (_hit.collider == null)
            transform.Translate(0, _moveDelta.y * Time.deltaTime, 0);

        _hit = Physics2D.BoxCast(transform.position, _collider.size, 0, new Vector2(_moveDelta.x, 0), Mathf.Abs(_moveDelta.x * Time.deltaTime), LayerMask.GetMask(Actors, Blocking));

        if (_hit.collider == null)
            transform.Translate(_moveDelta.x * Time.deltaTime, 0, 0);
    }
}
