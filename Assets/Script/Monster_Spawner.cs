using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Monster_Refrence;

    private GameObject spawned_monster;

    [SerializeField]
    private Transform left_pos, right_pos;

    private int random_index;
    private int random_side;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            random_index = Random.Range(0, Monster_Refrence.Length);
            random_side = Random.Range(0, 2);


            spawned_monster = Instantiate(Monster_Refrence[random_index]);

            if(random_side == 0)
            {
                spawned_monster.transform.position = left_pos.position;
                spawned_monster.GetComponent<Monster>().Monster_Speed = Random.Range(4, 10);
            }
            else
            {
                spawned_monster.transform.position = right_pos.position;
                spawned_monster.GetComponent<Monster>().Monster_Speed = -Random.Range(4, 10);
                spawned_monster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }


        }
    }
}
