using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject itemPrefab;
    private Transform player;
    public string itemName;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SpawnDroppedItem()
    {
        // create a 3D instance of the object in the game environment.
        Vector3 playerposition = new Vector3(player.position.x, player.position.y, player.position.z + 6);
        Instantiate(itemPrefab, playerposition, Quaternion.identity);
    }
}
