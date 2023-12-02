using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private InventoryController inventory;
    public GameObject itemIcon;
    public string itemName;

    void Start()
    {
        inventory = FindObjectOfType<InventoryController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {

                //Here, we set '2' as the max # of the same item allowed in a slot. Additional ones will spill over into a new slot
                if (inventory.isFull[i] == true && inventory.slots[i].transform.GetComponent<Slot>().amount < 2)
                {
                    //if another item of the same kind is already in this slot
                    if (itemName == inventory.slots[i].transform.GetComponentInChildren<Spawn>().itemName)
                    {
                        Destroy(gameObject); //destroy this 3d representation from the game environment
                        inventory.slots[i].GetComponent<Slot>().amount += 1;
                        break;
                    }
                }
                // otherwise put one of this item into the slot
                else if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(itemIcon, inventory.slots[i].transform, false);
                    inventory.slots[i].GetComponent<Slot>().amount += 1;
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}