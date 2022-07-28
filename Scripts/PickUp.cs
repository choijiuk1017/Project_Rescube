using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject slotItem;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E))
        {
            ItemSlot slot = collision.GetComponent<ItemSlot>();
            for (int i = 0; i < slot.slots.Count; i++)
            {
                if(slot.slots[i].isEmpty)
                {
                    Instantiate(slotItem, slot.slots[i].slotObj.transform, false);
                    slot.slots[i].isEmpty = false;
                    Destroy(this.gameObject);
                    break;
                }
            }
        }
    }
}
