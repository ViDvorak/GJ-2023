using UnityEngine;

public static class GlobalGameState
{
    /// <summary>
    /// Flags bitset which contains player's items.
    /// </summary>
    private static Item playerItems = Item.None;

    public static Item PlayerItems { get { return playerItems; } }

    public static void PickUpItem(Item item)
    {
        Debug.Assert(!HasItems(item));
        playerItems |= item;
    }

    /// <summary>
    /// Determine if player has specified items.
    /// </summary>
    /// <param name="items">Specified items.</param>
    public static bool HasItems(Item items)
    {
        Item foo = playerItems & items;
        foo = ~foo;
        foo = foo & items;

        bool success = foo == Item.None;

        return success || items == Item.None;
    }
}
