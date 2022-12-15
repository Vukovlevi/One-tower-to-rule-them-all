using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Transform slotHolder;
    public List<Slot> slots = new List<Slot>();

    // Start is called before the first frame update
    void Start()
    {
        Slot[] slotList = slotHolder.GetComponentsInChildren<Slot>();
        foreach (var _slot in slotList)
        {
            slots.Add(_slot);
        }
    }

    public void AddItem(Item item)
    {
        foreach (var slot in slots)
        {
            if (slot.item.name == item.name)
            {
                slot.increaseItem();
                break;
            }
        }
    }
}
