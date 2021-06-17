using UnityEngine;

public class CircleController : MonoBehaviour
{
    public float speed;

    private static ILogger logger = Debug.unityLogger;
    private static string TAG = "CircleSpeed";
    private Rigidbody2D rigidBody2D;
    private Vector2 direction = new Vector2();
    private Vector2 stop = new Vector2(0, 0);

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Move(x, y);
    }

    private void Move(float x, float y)
    {
        direction.Set(x, y);
        // rigidBody2D.AddForce(direction * speed);
        rigidBody2D.velocity = direction * speed;

        if (rigidBody2D.velocity != stop)
        {
            logger.Log(TAG, $"Velocity: x:{ rigidBody2D.velocity.x } y:{ rigidBody2D.velocity.y }");
        }
    }
}
