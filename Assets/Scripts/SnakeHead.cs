using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    public GameObject SegmentObject;
    public float Speed = 8;
    public float TurningRadius = 0.3f;
    public GameManager Manager;

    internal List<GameObject> BodySegments = new List<GameObject>();
    internal int Size = 1;

    private Rigidbody2D _rigidBody2D;
    private Vector3 _lastMousePos;
    private Quaternion _rotateTo;

    void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // if ((Input.mousePosition != _lastMousePos) || (transform.rotation != _rotateTo))
        // {
        // if (!Input.touchSupported || Input.GetTouch(0).phase == TouchPhase.Moved)
        // {
        if (!Manager.IsGameOver)
        {
            Vector3 mousePos = Input.mousePosition;
            _lastMousePos = mousePos;
            mousePos.z = Camera.main.nearClipPlane;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.x = mousePos.x - transform.position.x;
            mousePos.y = mousePos.y - transform.position.y;
            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            _rotateTo = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.rotation = Quaternion.Slerp(transform.rotation, _rotateTo, Time.deltaTime / TurningRadius);
        }
        // }
        // }
    }

    void FixedUpdate()
    {
        if (!Manager.IsGameOver)
        {
            Move();
        }
    }

    private void Move()
    {
        // float speedReduction = Mathf.Clamp((1 - ((Size - 1)*0.5f / 10)), 0.5f, 1);
        Vector2 moveTo = transform.right * Speed * Time.deltaTime;
        transform.position += (Vector3)moveTo;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Food")
        {
            Food food = other.gameObject.GetComponent<Food>();
            Destroy(other.gameObject, 0);

            if (food.NutritionValue == 1)
            {
                Manager.RegularFoodEaten = true;
            }

            if (food.NutritionValue < 0)
            {
                if (Size < 1)
                {
                    Manager.GameOver();
                }
                else
                {
                    TurningRadius -= 0.0075f;
                    RemoveBodySegment();
                }
            }
            else
            {
                for (int i = 0; i < food.NutritionValue; i++)
                {
                    TurningRadius += 0.0075f;
                    AddNewSegment();
                }
            }

            Manager.UpdateScore();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Walls")
        {
            Manager.GameOver();
        }
    }

    private void AddNewSegment()
    {
        Vector3 position = transform.position;
        Quaternion rotation = transform.rotation;
        if (BodySegments.Count > 0)
        {
            Transform lastSegment = BodySegments[BodySegments.Count - 1].transform;
            position = lastSegment.position;
            rotation = lastSegment.rotation;
        }

        GameObject newSegment = Instantiate(SegmentObject, position, rotation);
        newSegment.transform.localScale = transform.localScale;
        SnakeSegment segment = newSegment.GetComponent<SnakeSegment>();
        segment.Index = BodySegments.Count;
        BodySegments.Add(newSegment);
    }

    private void RemoveBodySegment()
    {
        GameObject lastSegment = BodySegments[BodySegments.Count - 1];
        Destroy(lastSegment);
        BodySegments.RemoveAt(BodySegments.Count - 1);
    }
}
