using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADD_HIDEING_ITEMS : MonoBehaviour
{
    public Item setItems;

    // Start is called before the first frame update
    void Start()
    {
        GlobalGameState.PickUpItem(setItems);   
    }
}
