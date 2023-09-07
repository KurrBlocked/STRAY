using UnityEngine.Events;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryDisplay : MonoBehaviour
{
    protected InventorySystem inventorySystem;
    protected Dictionary<InventorySlot_UI, InventorySlot> slotDictionary;

    public InventorySystem InventorySystem => inventorySystem;
    public Dictionary<InventorySlot_UI, InventorySlot> SlotDictionary => slotDictionary;

    public abstract void AssignSlot(InventorySystem invToDisplay);

    protected virtual void Start()
    {

    }

    public virtual void UpdateSlot(InventorySlot updatedSlot)
    {
        if (slotDictionary == null) // check if slotDictionary is null
        {
            AssignSlot(inventorySystem); // initialize slotDictionary
        }

        foreach (var slot in SlotDictionary)
        {
            if (slot.Value == updatedSlot) //Slot value - the "under the hood" inventory slot.
            {
                slot.Key.UpdateUISlot(updatedSlot); //Slot key - the UI representation of the value.
            }
        }
    }
}
