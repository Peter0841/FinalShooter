using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f;
    private float gravity = -9.81f;
    public float jumpHeight;
    public float playerHealth = 100;
    public float x;
    public float z;

    public Vector3 velocity;
    private bool isGrounded;

    private HudController hudController;
    Random rand = new Random();

    void Start()
    {
        hudController = GameObject.Find("Canvas").GetComponent<HudController>();
    }

    void FixedUpdate(){
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, 1.2f);
    }

    void Update() {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (isGrounded == false){
            velocity.y += gravity * Time.deltaTime;
        }

        controller.Move(velocity * Time.deltaTime);
    }

    public void takeDamage(float amt)
    {
        if (gameObject != null)
        {
            hudController.TakeDamage((int)amt);
            playerHealth -= amt;

            if (playerHealth <= 0)
            {
                hudController.score = 0;
                hudController.health = 10;
                hudController.ammo = 30;
                hudController.UseAmmo(0);
                hudController.TakeDamage(0);
                hudController.AddScore(0);

                x = rand.Next(50);
                z = rand.Next(50);
            }
        }
    }
}
