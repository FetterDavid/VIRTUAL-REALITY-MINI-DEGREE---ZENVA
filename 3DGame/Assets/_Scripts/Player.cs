using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Rigidbody rig;
    public int score;
    public UI ui;

    private bool isGrounded;

    void Update()
    {

        float xInput = Input.GetAxis("Horizontal") * moveSpeed;
        float zInput = Input.GetAxis("Vertical") * moveSpeed;

        //Set our velocity based our inputs
        rig.velocity = new Vector3(xInput, rig.velocity.y, zInput);

        //Set y axis to 0
        Vector3 vel = rig.velocity;
        vel.y = 0;

        //Stay turn on the last direction
        if (vel.x != 0 || vel.z != 0)
        {
            transform.forward = vel;
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded=false;
        }

        if (transform.position.y < -10)
            GameOver();
    }

    //IsGrounded check
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal == Vector3.up)
            isGrounded = true;
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore(int amount)
    {
        score += amount;
        ui.SetScoreText(score);
    }
}
