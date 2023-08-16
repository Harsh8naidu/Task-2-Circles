using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleManager : MonoBehaviour
{
    public GameObject circlePrefab;
    public Transform circlesContainer;

    private void Start()
    {
        // Generate a random number of circles between 5 and 10
        int numberOfCircles = Random.Range(5, 11);

        for (int i = 0; i < numberOfCircles; i++)
        {
            SpawnCircle();
        }
    }

    private void SpawnCircle()
    {
        float buffer = 0.1f; // A small buffer to prevent circles from being too close to the edges
        Vector3 randomViewportPos = new Vector3(
            Random.Range(buffer, 1f - buffer),
            Random.Range(buffer, 1f - buffer),
            0f
        );

        Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(randomViewportPos);
        spawnPosition.z = 0f; // Set z position to 0 to ensure the circles are on the same plane

        // Spawn the circle prefab at the calculated world position
        Instantiate(circlePrefab, spawnPosition, Quaternion.identity, circlesContainer);
    }
}

