using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static Dictionary<int, int> puzzlePairs;

    private void Awake()
    {
        ItemSlot[] slots = FindObjectsOfType<ItemSlot>();
        DragAndDrop[] items = FindObjectsOfType<DragAndDrop>();

        foreach (ItemSlot slot in slots)
        {
            foreach (DragAndDrop item in items) 
            { 
                if(slot.slotID == item.itemID)
                {
                    puzzlePairs.Add(slot.slotID, item.itemID); 
                    break;
                }
            }
        }
    }

}
