using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rig;

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal") * moveSpeed;
        float zInput = Input.GetAxis("Vertical") * moveSpeed;

        rig.velocity = new Vector3(xInput, rig.velocity.y, zInput);

        Vector3 vel = rig.velocity;
        vel.y = 0;

        if (vel.x != 0 || vel.z != 0)
        {
            transform.forward = vel;

        }
    }
}
