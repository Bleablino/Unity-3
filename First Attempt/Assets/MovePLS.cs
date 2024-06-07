using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MovePLS : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpower;
    private bool Jumpy = true;
    private bool flig = true;
    private Rigidbody2D rb;
    private SpriteRenderer render;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Jumpy && Input.GetKeyDown(KeyCode.W))
        {
            Jumpy = false;
            rb.AddForce(jumpower * Vector2.up, ForceMode2D.Impulse);
        }
        if((!flig && Input.GetAxis("Horizontal") > 0) || (flig && Input.GetAxis("Horizontal") < 0))
        {
            flip();
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            anim.SetTrigger("Run");
        }
        else
        {
            anim.SetTrigger("Idle");
        }
        transform.Translate(new Vector2(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0));
    }
    private void flip()
    {
        render.flipX = flig;
        flig = !flig;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Jumpy = true;
    }
}
