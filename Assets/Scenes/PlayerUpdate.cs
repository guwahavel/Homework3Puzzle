using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class PlayerUpdate : MonoBehaviour
{       
    bool isMoving;
    Vector3 targetPos;
    Vector3 moveVec;
    float moveSpeed;
    Tilemap tilemap;
    Vector3Int[] tileOffsets;
    string flavor;

    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
        moveSpeed = 0.2f;
        tilemap = GameObject.Find("TileMap").GetComponent<Tilemap>();
        tileOffsets = new Vector3Int[] {new Vector3Int(1,0), new Vector3Int(-1,0), new Vector3Int(0,1), new Vector3Int(0,-1)};
        flavor = "None";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMoving) {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed);
            if (Vector3.Distance(transform.position,targetPos) <= 0f) {
                isMoving = false;
                Vector3Int pos = new Vector3Int((int)Mathf.Floor(transform.position.x),(int)Mathf.Floor(transform.position.y));
                TileBase tile = tilemap.GetTile(pos);
                if (tile) {
                    if (tile.name == "yellow") {
                        Move(-moveVec);
                    } else if (tile.name == "blue") {
                        if (flavor == "Orange") {
                            Move(-moveVec);
                        } else {
                            for (int i = 0; i < tileOffsets.Length; ++i) {
                                TileBase adjtile = tilemap.GetTile(pos + tileOffsets[i]);
                                if (adjtile && adjtile.name == "yellow") {
                                    Move(-moveVec);
                                }
                            }
                        }
                    } else if (tile.name == "purple") {
                        flavor = "Lemon";
                        Move(moveVec);
                    } else if (tile.name == "orange") {
                        flavor = "Orange";
                    } else if (tile.name == "black") {
                        string scenename = SceneManager.GetActiveScene().name;
                        if (scenename == "EasyLevel") {SceneManager.LoadScene("MediumLevel", LoadSceneMode.Single);}
                        else if (scenename == "MediumLevel") {SceneManager.LoadScene("HardLevel", LoadSceneMode.Single);}
                        else if (scenename == "HardLevel") {SceneManager.LoadScene("YouWin", LoadSceneMode.Single);}
                    } else if (tile.name == "green") {
                        flavor = "Pineapple";
                    } else if (tile.name == "cyan") {
                        if (flavor == "Pineapple") {
                            flavor = "None";
                            Move(moveVec);
                        } else {
                            Move(-moveVec);
                        }
                    }
                }
            }
        }   
    }

    public void Move(Vector3Int vec) {
        Move(new Vector3(vec.x,vec.y));
    }

    public void Move(Vector3 vec) {
        if (!isMoving) {
            Vector3Int newpos = new Vector3Int((int)Mathf.Floor(transform.position.x + vec.x),(int)Mathf.Floor(transform.position.y + vec.y));
            TileBase tile = tilemap.GetTile(newpos);
            if (!(tile && tile.name == "red")) {
                isMoving = true;
                targetPos = transform.position + vec;
                moveVec = vec;
            }
        }
    }
}
