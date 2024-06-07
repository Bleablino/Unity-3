using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;

public class BulletLogic : MonoBehaviour
{
    [SerializeField]
    [Range(0, 30)]
    private float speed;
    private bool KnifeFace;
    private SpriteRenderer render;
    private Camera player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hittable")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        player = Camera.main;
        KnifeFace = GameObject.Find("Frog").GetComponent<MovingControlled>().flig;
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        render.flipX = KnifeFace;
        transform.Translate(new Vector4((KnifeFace ? speed : -speed) * Time.deltaTime,0, 0));
        if (player != null)
        {
            if (player.WorldToViewportPoint(transform.position).x < 0 || player.WorldToViewportPoint(transform.position).x > 1)
            {
                Destroy(gameObject);
            }
        }
    }
    
}
