using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;


    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private Animator anim;
    private bool looksRight = true;
    public float HP;

    public bool IsDead
    {
        get
        {
            return HP == 0;
        }
    }

    void Start()
    {
       instance = this;
       rb = GetComponent<Rigidbody2D>();
       anim = GetComponent<Animator>();

    }

    
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

        if (IsDead)
        {
            anim.SetTrigger("Death");
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            HP -= 10;
    }
}
