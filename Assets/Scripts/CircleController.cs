using UnityEngine;

public class CircleController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();

        rigidBody2D.AddForce(new Vector2(1f, 1f) * speed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
