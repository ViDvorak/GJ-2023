using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TicketHandeling : MonoBehaviour
{
    public GameObject TicketUI;

    void Update()
    {
        TicketUI.SetActive(GlobalGameState.HasItems(Item.Ticket));
    }
}
