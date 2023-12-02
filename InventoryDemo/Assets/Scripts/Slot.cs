using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Slot : MonoBehaviour
{
    public InventoryController inventory;
    public int i;
    public TextMeshProUGUI amountText;
    public int amount;

    void Start()
    {
        inventory = FindObjectOfType<InventoryController>();
    }
    void Update()
    {
        // have this slot display the amount
        amountText.text = amount.ToString();

        //once the amount is zero, hide the text box, otherwise display it.
        if (amount > 1)
        {
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        }
        else
        {
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        }
        //if this slot does not have an icon as third child, register that it’s no longer full
        if (transform.childCount == 2)
        {
            inventory.isFull[i] = false;
        }
    }

    public void DropItem()
    {
        if (amount > 1) // If more than one are “stacked” in the same slot
        {
            amount -= 1;
            // make the Spawn script (attached to the Icon) create a 3D instance of the object in the game environment.
            transform.GetComponentInChildren<Spawn>().SpawnDroppedItem();
        }
        else if (amount == 1)
        {
            amount -= 1;
            transform.GetComponentInChildren<Spawn>().SpawnDroppedItem();
            //destroy the game object (Icon) to which the Spawn script is attached
            GameObject.Destroy(transform.GetComponentInChildren<Spawn>().gameObject);
        }
    }
}

