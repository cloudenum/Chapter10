using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    public float Speed;
    public GameManager Manager;

    private Rigidbody2D _rigidBody2D;
    private Vector2 _movePos;
    private Vector2 _stop = new Vector2(0, 0);
    private List<GameObject> _consumedBoxes;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        _movePos = Vector2.Lerp(transform.position, mousePos, Speed);
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rigidBody2D.MovePosition(_movePos);

        if (_rigidBody2D.velocity != _stop)
        {
            Debug.Log($"Velocity: x:{ _rigidBody2D.velocity.x } y:{ _rigidBody2D.velocity.y }");
        }
    }
}
