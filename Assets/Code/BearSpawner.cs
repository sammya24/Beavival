using UnityEngine;

public class BearSpawner : MonoBehaviour
{
    public GameObject bearPrefab; // Reference to the bear prefab that you want to spawn
    public float spawnInterval = 30f; // Interval between each bear spawn
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime; // Increment timer with time passed

        // Check if it's time to spawn a bear
        if (timer >= spawnInterval)
        {
            SpawnBear();
            timer = 0f; // Reset the timer
        }
    }

    void SpawnBear()
    {
        // Generate a random position for the bear to spawn within the game boundaries
        Vector3 spawnPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0f); // Adjust the range according to your game's layout

        // Instantiate the bear at the random position
        Instantiate(bearPrefab, spawnPosition, Quaternion.identity);
    }
}
