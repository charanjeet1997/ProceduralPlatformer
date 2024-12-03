using System;
using UnityEngine;

namespace Games.Platformer2D
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f; // Speed of horizontal movement
        [SerializeField] private float jumpForce = 10f; // Force applied when jumping
        [SerializeField] private LayerMask groundLayer; // Layer used to detect ground
        [SerializeField] private Vector2 groundSensorOffset;
        private Rigidbody2D rb;
        [SerializeField] private bool isGrounded;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }


        private void Update()
        {
            // Check if the player is grounded
            isGrounded = Physics2D.OverlapCircle((Vector2)transform.position + groundSensorOffset, 0.1f, groundLayer);

            // Handle jump input
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                Jump();
            }
        }

        private void FixedUpdate()
        {
            // Automatically move horizontally
            if (isGrounded)
            {
                rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
            }
        }

        private void Jump()
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere((Vector2)transform.position + groundSensorOffset, 0.1f);
        }
    }
}