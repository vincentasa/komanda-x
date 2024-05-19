using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Food : MonoBehaviour
{
    public Collider2D gridArea;

    private Snake snake;

    public float spawnRate = 3f;
    public float originalSpawnRate = 3f;

    public GameObject foodPrefab;
    

    private void Awake()
    {
        snake = FindObjectOfType<Snake>();
    }

    private void Start()
    {
        RandomizePosition();
        spawnRate = originalSpawnRate;
    }

    public void RandomizePosition()
    {
        Bounds bounds = gridArea.bounds;

        // Pick a random position inside the bounds.
        int x = Mathf.RoundToInt(Random.Range(bounds.min.x, bounds.max.x));
        int y = Mathf.RoundToInt(Random.Range(bounds.min.y, bounds.max.y));

        // Prevent the food from spawning on the snake
        while (snake.Occupies(x, y))
        {
            x++;

            if (x > bounds.max.x)
            {
                x = Mathf.RoundToInt(bounds.min.x);
                y++;

                if (y > bounds.max.y)
                {
                    y = Mathf.RoundToInt(bounds.min.y);
                }
            }
        }

        Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);
    }
    private async void Update()
    {
        spawnRate -= Time.deltaTime;
        if (spawnRate <= 0)
        {
            RandomizePosition();
            spawnRate = originalSpawnRate;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            RandomizePosition();
        }
    }
}
