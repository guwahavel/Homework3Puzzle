using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InputManager : MonoBehaviour
{   
    GameObject player;
    Tilemap tilemap;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        tilemap = GameObject.Find("TileMap").GetComponent<Tilemap>();
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

        Vector3Int pos = new Vector3Int((int)Mathf.Floor(player.transform.position.x),(int)Mathf.Floor(player.transform.position.y));
        TileBase tile = tilemap.GetTile(pos);
        if (tile) {
            //if (tile.name == "pink") {Debug.Log("ispink");}
        }
    }
}
