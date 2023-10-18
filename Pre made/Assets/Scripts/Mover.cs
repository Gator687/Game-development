using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private float moveSpeed = 2.5f;
    private float rotationSpeed = 1.0f;
    private GameManager gameManager;
    protected Vector3 destinationPos;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Main Camera").GetComponent<GameManager>();
        FindDestinationPoint();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if this object is close enough to the destination

        if (Vector3.Distance(transform.position, destinationPos) < 5.0f)
        {
            Debug.Log("Arrived!");
            gameManager.msg = "Arrived";
        }

        // Moves the object forward .1 units.
        //transform.Translate(0, 0, 0.1f);

        // Rotate toward the destination IMMEDIATELY
        //transform.rotation = Quaternion.LookRotation(destinationPos, Vector3.up);

        //look toward the destination GRADUALLY (realistic turn):
        Quaternion targetRotation = Quaternion.LookRotation(destinationPos - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

        // Move this Object forward
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
    }

    protected void FindDestinationPoint()
    {
        print("Finding next point");
        destinationPos = new Vector3(15, 0, 10);
    }
}
