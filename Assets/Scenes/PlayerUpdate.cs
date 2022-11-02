using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpdate : MonoBehaviour
{       
    bool isMoving;
    Vector3 targetPos;
    float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
        moveSpeed = 0.05f;
    }

    // Update is called once per frame
    void Update()
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
            isMoving = true;
            targetPos = transform.position + vec;
        }
    }
}
