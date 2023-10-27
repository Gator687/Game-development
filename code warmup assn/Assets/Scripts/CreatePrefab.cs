using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePrefab : MonoBehaviour
{
    public GameObject myPrefab;
    // This script will simply instantiate the Prefab at 0, 0, 0 when the game starts.
    // Start is called before the first frame update
    void Start()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        //Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        // Instantiate at parent object's position and parent object's rotation.
        GameObject childGameObject = Instantiate(myPrefab, transform.position, transform.rotation);
        //attach a component to the spawned object--in this case, attach the Mover script to CylinderContainer
        childGameObject.AddComponent<Mover>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
