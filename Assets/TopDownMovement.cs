using UnityEngine;

public class TopDownMovement1 : MonoBehaviour
{
    public float movespeed = 5f;
    public Rigidbody2D rb;
    private Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 moveDirection = new Vector2(movement.x, movement.y).normalized;
        rb.MovePosition(rb.position + moveDirection * movespeed * Time.fixedDeltaTime);
    }
}