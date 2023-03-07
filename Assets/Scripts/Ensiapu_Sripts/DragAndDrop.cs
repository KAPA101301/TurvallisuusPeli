using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public int itemID;
    private bool isDragging;
    private bool inCorrectSlot = false;

    private Vector2 offset;
    private Vector2 originalPos;

    public List<ItemSlot> slots;

    public List<DragAndDrop> items;

    private void Awake()
    {
        originalPos = transform.position;
        slots.AddRange(FindObjectsOfType<ItemSlot>());
        items.AddRange(FindObjectsOfType<DragAndDrop>());
    }

    private void OnMouseDown()
    {
        // When picking up item, reset ID checking
        isDragging = true;
        inCorrectSlot = false;
        offset = getMousePos() - (Vector2)transform.position;
    }

    private void OnMouseUp()
    {
        // When placing item in slot, check if ID matches

        for(int i = 0; i < slots.Count; i++)
        {
            if (Vector2.Distance(transform.position, slots[i].transform.position) < 1)
            {
                // TODO: Check if slot is full
                transform.position = slots[i].transform.position;
                isDragging = false;
                if (isInCorrectSlot(slots[i]))
                {
                    inCorrectSlot = true;
                    Debug.Log("Is in correct slot");
                }
                break;
            }
            else
            {
                isDragging = false;
                //transform.position = originalPos;
            }
        }

        // Check if all items are in correct slots
        bool nullFound = false;

        for (int j = 0; j < items.Count; j++)
        {
            if (!items[j].inCorrectSlot)
            {
                nullFound = true;
                break;
            }
        }

        if (!nullFound)
        {
            Debug.Log("You win!");
        }

    }

    private void Update()
    {
        if (isDragging)
        {
            Vector2 mousePos = getMousePos();
            transform.position = getMousePos() - offset;
        }

        for (int i = 0; i < slots.Count; i++)
        {
            if (Vector2.Distance(transform.position, slots[i].transform.position) < 3)
            {
                //Debug.Log("Near slot: " + slots[i].name);
            }
        }
    }

    public bool isInCorrectSlot(ItemSlot slot)
    {
        return this.itemID == slot.slotID;
    }



public Vector2 getMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
