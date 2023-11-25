using System;
using System.Collections.Generic;

using UnityEngine;

using UnityRandom = UnityEngine.Random;

/// <summary>
/// Script for handling (re)spawning of aliens.
/// </summary>
public class AlienSpawner : MonoBehaviour
{
    /// <summary>
    /// Contains all active aliens.
    /// </summary>
    private readonly List<GameObject> alienList = new();

    /// <summary>
    /// Number of aliens to spawn. CHANGES DURING RUNTIME WILL NOT TAKE EFFECT.
    /// </summary>
    public int AlienCount;
    /// <summary>
    /// Size of the area in which will be aliens (re)spawned. Area center is (0,0).
    /// </summary>
    public Vector2 AreaSize;
    /// <summary>
    /// Prefab of alien to spawn.
    /// </summary>
    public GameObject AlienPrefab;

    private void Awake()
    {
        for (int i = 0; i < AlienCount; i++)
        {
            alienList.Add(SpawnAlien(true));
        }
    }

    private void Update()
    {
        Rect area = new(-AreaSize / 2.0f, AreaSize);

        for (int i = 0; i < alienList.Count; i++)
        {
            if (area.Contains(alienList[i].transform.localPosition))
                continue;

            Destroy(alienList[i]);
            alienList[i] = SpawnAlien(false);
        }
    }

    /// <summary>
    /// Spawn an alien at random position.
    /// </summary>
    /// <param name="spawnInMap">
    /// Determine if alien should be spawned in the area. If false alien will spawn at left or right area border.
    /// </param>
    private GameObject SpawnAlien(bool spawnInMap)
    {
        GameObject alien = Instantiate(AlienPrefab, transform);

        MoveDirection direction = (MoveDirection)(UnityRandom.value * Enum.GetValues(typeof(MoveDirection)).Length);

        Vector2 spawnPosition;
        if (spawnInMap)
        {
            spawnPosition = (AreaSize * new Vector2(UnityRandom.value, UnityRandom.value));
               
        }
        else
        {
            spawnPosition = new Vector2()
            {
                /* 
                 * We need to offset the spawn otherwise alien will get immediatly despawned, because it is outside
                 * spawn area (Rect.Contains returns falls for border points). 
                 */
                x = direction == MoveDirection.Right ? 1.0f : AreaSize.x - 1.0f,
                y = UnityRandom.value * AreaSize.y,
            };
        }
        spawnPosition -= AreaSize / 2.0f;

        alien.transform.localPosition = spawnPosition;
        alien.GetComponent<AlienController>().MovementDirection = direction;

        return alien;
    }
}
