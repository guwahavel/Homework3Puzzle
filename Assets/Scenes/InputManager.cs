using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{   
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) {
            player.SendMessage("Move", new Vector3(0,1,0));
        } else if (Input.GetKeyDown(KeyCode.A)) {
            player.SendMessage("Move", new Vector3(-1,0,0));
        } else if (Input.GetKeyDown(KeyCode.S)) {
            player.SendMessage("Move", new Vector3(0,-1,0));
        } else if (Input.GetKeyDown(KeyCode.D)) {
            player.SendMessage("Move", new Vector3(1,0,0));
        }
    }
}
