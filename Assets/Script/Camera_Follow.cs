using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour

{

    private Transform Player;
    private string Player_Tag = "Player";
    private Vector3 Camera;

    [SerializeField]
    private float min_x, max_x;

    // Start is called before the first frame update
    void Start()
    {

        Player = GameObject.FindWithTag(Player_Tag).transform;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!Player)
        {
            return;
        }

        Camera = transform.position;
        Camera.x = Player.position.x;

        if (Camera.x < min_x)
        {
            Camera.x = min_x;
        }

        if (Camera.x > max_x)
        {
            Camera.x = max_x;
        }

        transform.position = Camera;


    }


}
