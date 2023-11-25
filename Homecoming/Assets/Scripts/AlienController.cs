using System;

using UnityEngine;

/// <summary>
/// Script for controlling the aliens.
/// </summary>
public class AlienController : MonoBehaviour
{
    private new Rigidbody2D rigidbody;

    /// <summary>
    /// Direction of the alien movement.
    /// </summary>
    public MoveDirection MovementDirection;
    /// <summary>
    /// Speed of alien movement.
    /// </summary>
    public float MovementSpeed;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        Vector3 scale = transform.localScale;
        scale.x *= MovementDirection == MoveDirection.Left ? 1.0f : -1.0f;
        transform.localScale = scale;
    }

    private void Update()
    {
        Vector2 direction = new(MovementDirection == MoveDirection.Right ? 1.0f : -1.0f, 0.0f);
        rigidbody.AddForce(MovementSpeed * Time.deltaTime * direction);
    }
}
