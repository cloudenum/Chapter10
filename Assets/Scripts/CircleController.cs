using UnityEngine;

public class CircleController : MonoBehaviour
{
    public float speed;

    private static ILogger logger = Debug.unityLogger;
    private static string TAG = "CircleSpeed";
    private Rigidbody2D rigidBody2D;
    private Vector2 goUp = new Vector2(0f, 1f);
    private Vector2 goDown = new Vector2(0f, -1f);
    private Vector2 goLeft = new Vector2(-1f, 0f);
    private Vector2 goRight = new Vector2(1f, 0f);
    private Vector2 stop = new Vector2(0, 0);

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            move(goUp);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            move(goDown);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            move(goLeft);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            move(goRight);
        }
        else
        {
            move(stop);
            // rigidBody2D.velocity = new Vector2(0, 0);
        }
    }

    private void move(Vector2 direction)
    {
        // rigidBody2D.AddForce(direction * speed);
        rigidBody2D.velocity = direction * speed;

        if (rigidBody2D.velocity != stop)
        {
            logger.Log(TAG, $"Velocity: x:{ rigidBody2D.velocity.x } y:{ rigidBody2D.velocity.y }");
        }
    }
}
