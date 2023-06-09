using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float movement;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] const int SPEED = 15;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] float jumpForce = 500.0F;
    [SerializeField] bool isGrounded = true;

    const int IDLE = 0;
    const int RUN = 1;
    const int JUMP = 2;
    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null) {
            rigid = this.GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump")) {
            jumpPressed = true;
        }
    }

    // Used for physics and movement
    void FixedUpdate() 
    {
        rigid.velocity = new Vector2(SPEED * movement, rigid.velocity.y);
        if (movement < 0 && isFacingRight || movement > 0 && !isFacingRight) {
            Flip();
        }
        if (jumpPressed && isGrounded) {
            Jump();
        }
        else {
            jumpPressed = false;
        }
    }

    private void Flip() {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    private void Jump() {
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.AddForce(new Vector2(0, jumpForce));
        jumpPressed = false;
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            isGrounded = true;
        }
    }
}
