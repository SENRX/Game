using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private Animator anim;
    private bool looksRight = true;

    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVelocity.x = Input.GetAxisRaw("Horizontal");
        moveVelocity.y = Input.GetAxisRaw("Vertical");
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }

        

    void FixedUpdate()
    {
            rb.MovePosition (rb.position + moveVelocity * Time.fixedDeltaTime);

        if ((moveVelocity.x > 0) && !looksRight)
        {
            Flip();
        }
        else if ((moveVelocity.x < 0) && looksRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        looksRight = !looksRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
