using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

   [SerializeField]
    private float move_force = 10f;
    private float movementX;
    private float jump_force = 11f;

    private SpriteRenderer Sr;
    private Rigidbody2D body;

    private Animator anim;
    private string Walk_Animation = "Is_Walking";

    private string Enemy_Tag = "Enemy";
    private string Ground_Tag = "Ground";
    private bool Is_Ground = true;

    private void Awake()
    {

        Sr = GetComponent<SpriteRenderer>();

        anim = GetComponent<Animator>();

        body = GetComponent<Rigidbody2D>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Player_Movement();
        Animate_Player();
    }

    private void FixedUpdate()
    {
        Player_Jump();
    }

    void Player_Movement()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * move_force; 


    }

    void Animate_Player()
    {

        if(movementX > 0)
        {
            anim.SetBool(Walk_Animation, true);
            Sr.flipX = false;
        }
        else if(movementX < 0)
        {
            anim.SetBool(Walk_Animation, true);
            Sr.flipX = true;
        }
        else
        {
            anim.SetBool(Walk_Animation, false);
        }


    }

    void Player_Jump()
    {
        
        if(Input.GetButtonDown("Jump") && Is_Ground)
        {
            Is_Ground = false;
            body.AddForce(new Vector2(0f, jump_force), ForceMode2D.Impulse);
            
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag(Ground_Tag)) 
        {
            Is_Ground = true;

        }

        if(collision.gameObject.CompareTag(Enemy_Tag))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(Enemy_Tag))
        {
            Destroy(gameObject);
        }
    }
}
