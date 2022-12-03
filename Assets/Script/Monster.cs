using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [HideInInspector]
    public float Monster_Speed;

    private Rigidbody2D mybody;

    // Start is called before the first frame update
    void Start()
    {
        mybody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mybody.velocity = new Vector2(Monster_Speed, mybody.velocity.y);
    }
}
