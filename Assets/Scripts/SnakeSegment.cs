using UnityEngine;

public class SnakeSegment : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float OverTime = 0.19f;

    internal int Index;

    private GameObject _head;
    private GameManager _manager;
    private Vector3 _movementVelocity = Vector3.zero;

    void Start()
    {
        _manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        _head = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        if (_manager.IsGameOver)
        {
            return;
        }

        if (Index == 0)
        {
            transform.position = Vector3.SmoothDamp(transform.position, _head.transform.position, ref _movementVelocity, OverTime);
            RotateTo(_head.transform.position);
        }
        else
        {
            Transform segmentBefore = _head.GetComponent<SnakeHead>().BodySegments[Index - 1].transform;
            transform.position = Vector3.SmoothDamp(transform.position, segmentBefore.position, ref _movementVelocity, OverTime);
            RotateTo(segmentBefore.position);
        }
    }

    private void RotateTo(Vector3 position)
    {
        float angle = Mathf.Atan2(position.y, position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Index != 0)
            {
                _manager.GameOver();
            }
        }
    }
}
