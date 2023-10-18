using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    private float moveSpeed = 2.5f;
    private float rotationSpeed = 1.0f;
    private GameManager gameManager;
    protected Vector3 destinationPos;
    // Start is called before the first frame update
    void Start()
    {
        FindDestinationPoint();
        gameManager = GameObject.Find("Main Camera").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if this object is close enough to its destination
        if (Vector3.Distance(transform.position, destinationPos) < 5.0f)
        {
            Debug.Log("Arrived");
        }

        // Rotate toward the destination IMMEDIATLY
        //transform.rotation = Quaternion.LookRotation(destinationPos, Vector3.up);
        // Rotate toward the destination GRADUALLY
        Quaternion targetRotation = Quaternion.LookRotation(destinationPos - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

        // Move the object Forward
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
    }

    protected void FindDestinationPoint()
    {
        destinationPos = new Vector3(15, 0, 20);
    }
}
