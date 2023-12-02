using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    //This array will contain a true or false value for each of the 12 slots in our array to keep track if each is full
    public bool[] isFull;
    //This array will contain the 12 slots that are in our array
    public GameObject[] slots;
}

