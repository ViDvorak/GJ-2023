using System;
using System.Collections.Generic;

using TreeEditor;

using UnityEngine;
using UnityEngine.Splines;

using static UnityEngine.Splines.SplineAnimate;

using UnityRandom = UnityEngine.Random;

/// <summary>
/// Script for handling (re)spawning of aliens.
/// </summary>
public class AlienSpawner : MonoBehaviour
{
    private SplineContainer spline;

    /// <summary>
    /// Number of aliens to spawn. CHANGES DURING RUNTIME WILL NOT TAKE EFFECT.
    /// </summary>
    public int AlienCount;
    /// <summary>
    /// Prefab of alien to spawn.
    /// </summary>
    public GameObject AlienPrefab;
    public FaceDirection FaceDirection;

    private void Start()
    {
        spline = transform.Find("Path").gameObject.GetComponent<SplineContainer>();

        for (int i = 0; i < AlienCount; i++)
        {
            SpawnAlien();
        }
    }

    /// <summary>
    /// Spawn an alien at random position along its path.
    /// </summary>
    private GameObject SpawnAlien()
    {
        GameObject alien = Instantiate(AlienPrefab, transform);

        SplineAnimate splineAnimate = alien.GetComponent<SplineAnimate>();
        splineAnimate.StartOffset = UnityRandom.value;
        splineAnimate.Container = spline;
        splineAnimate.Loop = LoopMode.Loop;

        Vector3 scale = alien.transform.localScale;
        scale.x = FaceDirection == FaceDirection.Left ? 1.0f : -1.0f;
        alien.transform.localScale = scale;

        return alien;
    }
}
