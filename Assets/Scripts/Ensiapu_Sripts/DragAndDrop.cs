using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public int itemID;
    private int currentSlot = 0;
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
        for(int i = 0; i < slots.Count; i++)
        {
            if(currentSlot == slots[i].slotID)
                slots[i].isFull = false;
        }
        currentSlot = 0;
        offset = getMousePos() - (Vector2)transform.position;
    }

    private void OnMouseUp()
    {
        // When placing item in slot, check if ID matches
        bool slotFound = false;

        for(int i = 0; i < slots.Count; i++)
        {
            if (Vector2.Distance(transform.position, slots[i].transform.position) < 1 && !slots[i].isFull)
            {             
                transform.position = slots[i].transform.position;
                slots[i].isFull = true;
                currentSlot = slots[i].slotID;
                isDragging = false;
                slotFound = true;
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
            }
        }

        if(!slotFound)
            transform.position = originalPos;

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
            EventSystem.Instance.TriggerEvent("gameWon", Timer.timePassed);
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
