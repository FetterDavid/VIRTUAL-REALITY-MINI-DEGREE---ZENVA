using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Vector3 moveDirection;
    public float moveDistance;

    private Vector3 startPos;
    private bool movingToStart;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (movingToStart)
        {
            //Move towards to the start position
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);

            //We have reached the startPos?
            if (transform.position == startPos)
                movingToStart = false;
        }
        else
        {
            //Move towards to the target position
            transform.position = Vector3.MoveTowards(transform.position, startPos + (moveDirection * moveDistance), speed * Time.deltaTime);

            //We have reached target position?
            if (transform.position == startPos + (moveDirection * moveDistance)) 
                movingToStart = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().GameOver();
        }
    }
}
