using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Snake : MonoBehaviour
{
    public Transform segmentPrefab;
    public Vector2Int direction = Vector2Int.right;
    public float speed = 20f;
    public int initialSize = 4;
    public float speedMultiplier = 1.0f;
    public GameObject checkpoint;

    private List<Transform> segments = new List<Transform>();
    private Vector2Int input;
    private float nextUpdate;

    private void Start()
    {
        ResetState();
    }

    private void Update()
    {
        // Only allow turning up or down while moving in the x-axis
        if (direction.x != 0f)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                input = Vector2Int.up;
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                input = Vector2Int.down;
            }
        }
        // Only allow turning left or right while moving in the y-axis
        else if (direction.y != 0f)
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                input = Vector2Int.right;
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                input = Vector2Int.left;
            }
        }

        // Rotate snake head to a direction it's moving
        if (direction == Vector2.up)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else if (direction == Vector2.down)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
        }
        else if (direction == Vector2.left)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }
        else if (direction == Vector2.right)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
        }
    }

    private void FixedUpdate()
    {
        // Wait until the next update before proceeding
        if (Time.time < nextUpdate)
        {
            return;
        }

        // Set the new direction based on the input
        if (input != Vector2Int.zero)
        {
            direction = input;
        }

        // Set each segment's position to be the same as the one it follows.
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }

        // Move the snake in the direction it is facing
        // Round the values to ensure it aligns to the grid
        int x = Mathf.RoundToInt(transform.position.x) + direction.x;
        int y = Mathf.RoundToInt(transform.position.y) + direction.y;
        transform.position = new Vector2(x, y);

        // Set the next update time based on the speed
        nextUpdate = Time.time + (1f / speed * speedMultiplier);
    }

    public void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
    }

    public void ResetState()
    {
        direction = Vector2Int.right;
        transform.position = checkpoint.transform.position;

        // Start at 1 to skip destroying the head
        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }

        // Clear the list but add back this as the head
        segments.Clear();
        segments.Add(transform);

        // -1 since the head is already in the list
        for (int i = 0; i < initialSize - 1; i++)
        {
            Grow();
        }
    }

    // Check where the snake is currently at
    public bool Occupies(int x, int y)
    {
        foreach (Transform segment in segments)
        {
            if (Mathf.RoundToInt(segment.position.x) == x &&
                Mathf.RoundToInt(segment.position.y) == y)
            {
                return true;
            }
        }

        return false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            Grow();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            ResetState();
        }
    }
}
