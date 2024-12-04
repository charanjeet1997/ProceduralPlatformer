using System;
using UnityEngine;

namespace Games.Platformer2D
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float jumpForce = 10f;
        [SerializeField] private float fallMultiplier = 2.5f; // Multiplier to increase downward speed
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private Vector2 groundSensorOffset;
        [SerializeField] private Vector2 groundSensorSize;

        private Rigidbody2D rb;
        [SerializeField] private bool isGrounded;

        private int jumpCount = 0;
        private const int maxJumpCount = 2;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            isGrounded = CheckGrounded();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isGrounded || jumpCount < maxJumpCount)
                {
                    float jumpForce = jumpCount == 0 ? this.jumpForce : this.jumpForce * 1.5f;
                    Jump(jumpForce);
                }
            }
        }

        private void FixedUpdate()
        {
            if (isGrounded)
            {
                rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
                jumpCount = 0;
            }
            else
            {
                rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);

                // Apply fall multiplier if the player is falling
                if (rb.linearVelocity.y < 0)
                {
                    rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
                }
                else
                {
                    rb.linearVelocity += Vector2.up * Physics2D.gravity.y  * Time.fixedDeltaTime;
                }
            }
        }

        private bool CheckGrounded()
        {
            RaycastHit2D hit = Physics2D.BoxCast((Vector2)transform.position + groundSensorOffset,
                groundSensorSize, 0f, Vector2.down, 0.1f, groundLayer);

            return hit.collider != null;
        }

        private void Jump(float jumpForce)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpCount++;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube((Vector2)transform.position + groundSensorOffset, groundSensorSize);
        }
    }
}
