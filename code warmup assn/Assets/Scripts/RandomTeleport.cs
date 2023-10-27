using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTeleport : MonoBehaviour
{
    public float jumpTimer = 3.0f;
    private float elapsedTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //manually increase elapsedTime counter
        elapsedTime += Time.deltaTime;
        //if enough time has elapsed
        if (elapsedTime >= jumpTimer)
        {
            Debug.Log("time to jump!");
            //change position of this object to a random position within the plane we made
            float randomX = Random.Range(-12, 12);
            float randomZ = Random.Range(-12, 12);
            transform.position = new Vector3(randomX, 1, randomZ);
            //Reset the timer
            elapsedTime = 0.0f;
        }
    }
}