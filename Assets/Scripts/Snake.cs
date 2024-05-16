using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Snake : MonoBehaviour
{
    private Vector2 direction = Vector2.up;

    private List<Transform> segments = new List<Transform>();
    public Transform segmentPrefab;

    public int initialSize = 4;

    private void Start()
    {
        ResetState();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector2.right;
        }

        if (direction == Vector2.up)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (direction == Vector2.down)
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
        else if (direction == Vector2.left)
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else if (direction == Vector2.right)
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
        }
    }
    private void FixedUpdate()
    {
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }

        transform.position = new Vector3(Mathf.RoundToInt(direction.x) + transform.position.x, Mathf.RoundToInt(direction.y) + transform.position.y, 0.0f);
    }

    private void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        
        segments.Add(segment);

    }
    private void ResetState()
    {
        for (int i = 0; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }
        segments.Clear();
        segments.Add(transform);

        for (int i = 1; i < initialSize; i++)
        {
            segments.Add(Instantiate(segmentPrefab));
        }

        transform.position = Vector3.zero;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            Grow();
        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            ResetState();
        }
    }
}
