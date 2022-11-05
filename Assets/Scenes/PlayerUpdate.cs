using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerUpdate : MonoBehaviour
{       
    bool isMoving;
    Vector3 targetPos;
    float moveSpeed;
    Tilemap tilemap;

    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
        moveSpeed = 0.2f;
        tilemap = GameObject.Find("TileMap").GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMoving) {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed);
            if (Vector3.Distance(transform.position,targetPos) <= 0f) {
                isMoving = false;
            }
        }   
    }

    public void Move(Vector3 vec) {
        if (!isMoving) {
            Vector3Int newpos = new Vector3Int((int)Mathf.Floor(transform.position.x + vec.x),(int)Mathf.Floor(transform.position.y + vec.y));
            TileBase tile = tilemap.GetTile(newpos);
            if (!(tile && tile.name == "red")) {
                isMoving = true;
                targetPos = transform.position + vec;
            }
        }
    }
}
