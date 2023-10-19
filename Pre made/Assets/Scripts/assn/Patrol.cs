using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float rotationSpeed = 2.0f;
    public float minDistance = 1.0f;

    private Vector3 currentDestination;
    private GameManager2 gameManager;

    private bool changingDestination = false;

    void Start()
    {
        GenerateRandomDestination();
        gameManager = GameObject.FindObjectOfType<GameManager2>();
    }

    void Update()
    {
        Vector3 direction = currentDestination - transform.position;

        if (direction.magnitude < minDistance && !changingDestination)
        {
            changingDestination = true;
            GenerateRandomDestination();
            gameManager.IncreaseScore();
        }
        if (direction.magnitude >= minDistance)
        {
            changingDestination = false;
        }

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void GenerateRandomDestination()
    {
        float randomX = Random.Range(-25.0f, 25.0f);
        float randomZ = Random.Range(-25.0f, 25.0f);
        currentDestination = new Vector3(randomX, 0.5f, randomZ);
    }
}
