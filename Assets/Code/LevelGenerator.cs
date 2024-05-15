using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject treePrefab; // Prefab for the tree
    public GameObject rockTopPrefab; // Prefab for the rock
    public GameObject rockBottomPrefab; // Prefab for the rock
    public GameObject bearPrefab; //Prefab for the bear
    public GameObject trunkPrefab; //Prefab for trunk
    public GameObject acornPrefab;
    public GameObject wolfPrefab;
    public GameObject coinPrefab;

    public int numberOfTrees; // Number of trees to spawn
    public int numberOfRocks; // Number of rocks to spawn
    public int numberOfBears; //Number of bears to spawn 
    public int numberOfAcorns;
    public int numberOfWolves;
    public int numberOfCoins; 

    public Vector2 spawnAreaSize = new Vector2(18f, 9f); // Size of the area in which objects will spawn

    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        // List to hold the positions of trees for reference
        List<Vector2> treePositions = new List<Vector2>();

        // Define overlapRadius here
        float overlapRadius = 1f; // Adjust this value based on the size of your objects

        // Spawn trees
        for (int i = 0; i < numberOfTrees; i++)
        {
            Vector2 randomPosition = GetRandomNonOverlappingPosition();
            Instantiate(treePrefab, randomPosition, Quaternion.identity);
            Instantiate(trunkPrefab, randomPosition, Quaternion.identity);
            treePositions.Add(randomPosition); // Add the tree's position to the list
            //Debug.Log("added tree to " + randomPosition);
        }

        // Spawn rocks
        for (int i = 0; i < numberOfRocks; i++)
        {
            Vector2 randomPosition = GetRandomNonOverlappingPosition();
            Instantiate(rockTopPrefab, randomPosition, Quaternion.identity);
            Instantiate(rockBottomPrefab, randomPosition, Quaternion.identity);
        }

        // Spawn bears
        for (int i = 0; i < numberOfBears; i++)
        {
            Vector2 randomPosition = GetRandomNonOverlappingPosition();
            Instantiate(bearPrefab, randomPosition, Quaternion.identity);
        }

        // Spawn wolves
        for (int i = 0; i < numberOfWolves; i++)
        {
            Vector2 randomPosition = GetRandomNonOverlappingPosition();
            Instantiate(wolfPrefab, randomPosition, Quaternion.identity);
        }

        // Spawn Acorns
        for (int i = 0; i < numberOfAcorns; i++)
        {
            //Debug.Log("Choosing random tree pos");

            // Choose a random tree position
            Vector2 treePosition = treePositions[Random.Range(0, treePositions.Count)];

            //Debug.Log("Chose this tree:" + treePosition);

            Vector2 acornPosition = new Vector2(treePosition.x, treePosition.y);

            Instantiate(acornPrefab, acornPosition, Quaternion.identity);
        }

        // Spawn coin
        for (int i = 0; i < numberOfWolves; i++)
        {
            Vector2 randomPosition = GetRandomNonOverlappingPosition();
            Instantiate(coinPrefab, randomPosition, Quaternion.identity);
        }
    }


    Vector2 GetRandomNonOverlappingPosition()
    {
        Vector2 randomPosition;
        bool positionFound = false;
        int attempts = 0;
        float overlapRadius = 1f; // Adjust this value based on the size of your objects

        while (!positionFound && attempts < 500) // Limit attempts to avoid infinite loop
        {
            randomPosition = GetRandomPosition();
            Collider2D[] colliders = Physics2D.OverlapCircleAll(randomPosition, overlapRadius);

            if (colliders.Length == 0) // No overlapping objects found
            {
                positionFound = true;
                return randomPosition;
            }

            attempts++;
        }

        Debug.LogWarning("Failed to find non-overlapping position after " + attempts + " attempts.");
        return new Vector2(-7, 3);
    }

    Vector2 GetRandomPosition()
    {
        float randomX = 0;
        float randomY = 0; 

        //Debug.Log("Position before:" + randomX + " " + randomY);

        while (randomX >= -1 && randomX <= 1)
        {
            randomX = Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2);
            //Debug.Log("Spawn area X: " + spawnAreaSize.x);
        }

        while (randomY >= -1 && randomY <= 1)
        {
            randomY = Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2);
            //Debug.Log("Spawn area Y: " + spawnAreaSize.y);
        }

        //Debug.Log("Position After:" + randomX + " " + randomY);

        Vector2 randomPosition = new Vector2(randomX, randomY);
        return randomPosition;
    }
}
