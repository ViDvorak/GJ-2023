using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class AlienDetectionHandeling : MonoBehaviour
{
    public Item[] ItemsLoweringAweraness;

    [SerializeField]
    private float aweranessIncreasSpeed = 0.5f;

    public float minAweranesIncreasSpeed = 0f;

    public float AweranessIncreasSpeed { get {
        int restrectedItemOwnedCount = 0;

        foreach (Item item in ItemsLoweringAweraness)
        {
            if (GlobalGameState.HasItems(item))
            {
                restrectedItemOwnedCount++;
            }
        }
        float parameter;
        if (ItemsLoweringAweraness.Length > 0)
            parameter = 1 - (float)restrectedItemOwnedCount / ItemsLoweringAweraness.Length;
        else
            parameter = 1;
        return minAweranesIncreasSpeed + (aweranessIncreasSpeed - minAweranesIncreasSpeed) * parameter;
        }
    }
}
