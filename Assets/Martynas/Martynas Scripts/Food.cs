using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Food : MonoBehaviour
{
    public Collider2D gridArea;

    private Snake snake;
    private AudioSource source;
    public AudioClip spawnSound;

    public GameObject spawnParticles;
    private float spawnRate;
    public float originalSpawnRate = 3f;

    public GameObject[] foodPrefabs;
    

    private void Awake()
    {
        snake = FindObjectOfType<Snake>();
        source = gameObject.GetComponent<AudioSource>();
    }

    private void Start()
    {
        RandomizePosition();
        spawnRate = originalSpawnRate;
    }

    public void RandomizePosition()
    {
        Bounds bounds = gridArea.bounds;
        var index = Random.Range(0, foodPrefabs.Length);


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

        var food = Instantiate(foodPrefabs[index], new Vector2(x, y), Quaternion.identity);
        //source.PlayOneShot(spawnSound);
        //Instantiate(spawnParticles, food.transform.position, Quaternion.identity);
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
