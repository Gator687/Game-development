using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomTeleport : MonoBehaviour
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
        //manually increase counter
        elapsedTime += Time.deltaTime;

        //if enough time has elapsed
        if (elapsedTime >= jumpTimer)
        {
            float randomX = Random.Range(-12, 12);
            float randomZ = Random.Range(-12, 12);

            //move this object to those coordinates
            transform.position = new Vector3(randomX, 1, randomZ);
            //reset the timer
            elapsedTime = 0.0f;
        }
    }
}
