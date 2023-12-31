using UnityEngine;
using UnityEngine.Assertions;

public class AutomatInteractionHandeling : MonoBehaviour
{
    public bool isInteractable = false;
    public GameObject text;

    private bool isIntersectingWithTicketMachine = false;
    PlayerInputActions input;
    TextMesh textComponent;

    public void Awake()
    {
        input = new PlayerInputActions();
        input.Enable();
        textComponent = text.GetComponent<TextMesh>();
        Assert.IsNotNull(textComponent);
    }

    public void Update()
    {
        if ( !GlobalGameState.HasItems(Item.Ticket) && input.Player.Interaction.WasPressedThisFrame() && isIntersectingWithTicketMachine)
        {
            GlobalGameState.PickUpItem(Item.Ticket);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isIntersectingWithTicketMachine = true;
        if (isInteractable && !GlobalGameState.HasItems(Item.Ticket))
        {
            text.SetActive(true);
            if (GlobalGameState.HasItems(Item.Money))
            {
                textComponent.text = "Press E to buy a ticket";
            }
            else
            {
                textComponent.text = "You do not have any money\nto buy a ticket";
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        text.SetActive(false);
        isIntersectingWithTicketMachine = false;
    }
}
