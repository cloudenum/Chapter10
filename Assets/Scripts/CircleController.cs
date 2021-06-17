using UnityEngine;

public class CircleController : MonoBehaviour
{
    public float speed;

    private static ILogger logger = Debug.unityLogger;
    private static string TAG = "CircleSpeed";
    private Rigidbody2D rigidBody2D;
    private Vector2 movePos;
    private Vector2 stop = new Vector2(0, 0);

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        movePos = Vector2.Lerp(transform.position, mousePos, speed);
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rigidBody2D.MovePosition(movePos);

        if (rigidBody2D.velocity != stop)
        {
            logger.Log(TAG, $"Velocity: x:{ rigidBody2D.velocity.x } y:{ rigidBody2D.velocity.y }");
        }
    }
}
