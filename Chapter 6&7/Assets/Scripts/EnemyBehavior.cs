using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyBehavior : MonoBehaviour
{
    // 1
    public Transform PatrolRoute;
    // 2 
    public List<Transform> Locations;
    // 2 
    private int _locationIndex = 0;
    // 3 
    private NavMeshAgent _agent;
    public Transform Player;
    void Start()
    {
        // 3 
        InitializePatrolRoute();
        // 4 
        _agent = GetComponent<NavMeshAgent>();
        Player = GameObject.Find("Player").transform;
        InitializePatrolRoute();
        // 5 
        MoveToNextPatrolLocation();
    }

    void Update()
    {
        // 1 
        if (_agent.remainingDistance < 0.2f && !_agent.pathPending)
        {
            // 2 
            MoveToNextPatrolLocation();
        }
    }
    void MoveToNextPatrolLocation()
    {
        if (Locations.Count == 0)
            return;
        // 6 
        _agent.destination = Locations[_locationIndex].position;

        _locationIndex = (_locationIndex + 1) % Locations.Count;
    }
    void InitializePatrolRoute()
    {
        // 5 
        foreach (Transform child in PatrolRoute)
        {
            // 6 
            Locations.Add(child);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        //2 
        if (other.name == "Player")
        {
            _agent.destination = Player.position;
            Debug.Log("Player detected - attack!");
        }
    }
    // 3
    void OnTriggerExit(Collider other)
    {
        // 4
        if (other.name == "Player")
        {
            Debug.Log("Player out of range, resume patrol");
        }
    }

    // 1 
    private int _lives = 3;
    public int EnemyLives
    {
        // 2 
        get { return _lives; }
        // 3 
        private set
        {
            _lives = value;
            // 4 
            if (_lives <= 0)
            {
                Destroy(this.gameObject);
                Debug.Log("Enemy down.");
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            // 6 
            EnemyLives -= 1;
            Debug.Log("Critical hit!");
        }
    }
}