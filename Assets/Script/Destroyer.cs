using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    private string Enemy_Tag = "Enemy";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(Enemy_Tag))
        {
            Destroy(collision.gameObject);
        }
    }

}
