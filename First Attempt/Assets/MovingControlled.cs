using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovingControlled : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpower;
    [SerializeField]
    private GameObject prefabThrowingKnife;
    public bool flig = true;
    TextMeshPro score;
    private int ReadyToJump = 1;
    private Rigidbody2D rb;
    private SpriteRenderer render;
    private Animator anim;
    private bool Shoot = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frames
    void Update()
    {
        if (ReadyToJump == 1 && Input.GetKeyDown(KeyCode.W))
        {
            ReadyToJump = 0;
            anim.SetFloat("ReadyToJumpy", 0);
            rb.AddForce(jumpower * Vector2.up, ForceMode2D.Impulse);
        }
        if ((!flig && Input.GetAxis("Horizontal") > 0) || (flig && Input.GetAxis("Horizontal") < 0))
        {
            flip();
        }
        transform.Translate(new Vector2(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0));
        anim.SetFloat("yVelocity", rb.velocity.y);
        if (Input.GetAxis("Horizontal") != 0)
        {
            anim.SetTrigger("Run");
        }
        else if (ReadyToJump == 1)
        {
            anim.SetTrigger("Idle");
        }
        if (Input.GetKeyDown(KeyCode.F) && Shoot)
        {
            if (prefabThrowingKnife != null)
            {
                Instantiate(prefabThrowingKnife, new Vector4(transform.position.x + (flig ? 1 : -1), transform.position.y, transform.position.z), Quaternion.identity);
                StartCoroutine(Delay());
            }
        }
    }
    private void flip()
    {
        render.flipX = flig;
        flig = !flig;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ReadyToJump = 1;
        anim.SetFloat("ReadyToJumpy", 1);
    }
    IEnumerator Delay()
    {
        Shoot = false;
        yield return new WaitForSeconds(2f);
        Shoot = true;
    }
}
