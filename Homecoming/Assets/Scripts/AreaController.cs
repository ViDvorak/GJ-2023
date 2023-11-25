using UnityEngine;

/// <summary>
/// Script for handling logic of an area.
/// </summary>
public class AreaController : MonoBehaviour
{
    private const float colliderThickness = 1.0f;

    /// <summary>
    /// Width and height of the area. Area center is (0, 0).
    /// </summary>
    public Vector2 AreaSize;
    /// <summary>
    /// Prefab used for top and bottom area colliders.
    /// </summary>
    public GameObject AreaColliderPrefab;

    private void Awake()
    {
        GameObject topCollider = SpawnHorizontalCollider();
        topCollider.transform.localPosition = new Vector3()
        {
            y = -AreaSize.y / 2.0f - colliderThickness / 2.0f,
        };

        GameObject bottomCollider = SpawnHorizontalCollider();
        bottomCollider.transform.localPosition = new Vector3()
        {
            y = +AreaSize.y / 2.0f + colliderThickness / 2.0f,
        };

        GameObject leftCollider = SpawnVerticalCollider();
        leftCollider.transform.localPosition = new Vector3()
        {
            x = -AreaSize.x / 2.0f - colliderThickness / 2.0f,
        };

        GameObject rightCollider = SpawnVerticalCollider();
        rightCollider.transform.localPosition = new Vector3()
        {
            x = +AreaSize.x / 2.0f + colliderThickness / 2.0f,
        };
    }

    /// <summary>
    /// Spawn horizontal area collider.
    /// </summary>
    private GameObject SpawnHorizontalCollider()
    {
        GameObject collider = Instantiate(AreaColliderPrefab);

        collider.transform.localScale = new Vector3()
        {
            x = AreaSize.x,
            y = colliderThickness,
            z = 1.0f
        };
        collider.GetComponent<BoxCollider2D>().size = new Vector2(AreaSize.y, colliderThickness);

        return collider;
    }

    /// <summary>
    /// Spawn vertiacal area collider.
    /// </summary>
    private GameObject SpawnVerticalCollider()
    {
        GameObject collider = Instantiate(AreaColliderPrefab);

        collider.transform.localScale = new Vector3()
        {
            x = colliderThickness,
            y = AreaSize.y,
            z = 1.0f
        };
        collider.GetComponent<BoxCollider2D>().size = new Vector2(colliderThickness, AreaSize.y);

        return collider;
    }
}
