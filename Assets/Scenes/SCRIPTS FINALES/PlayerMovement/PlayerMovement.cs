using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;

    public float speed = 5f;

    public float runSpeed = 10f;   // Velocidad corriendo
    private float currentSpeed;
    private bool isRunning = false;

    public float gravity = -9.8f;
    public float jumpHeight = 4f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        currentSpeed = speed; // Velocidad inicial


    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Aplicar gravedad siempre
        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void ProcessMove(Vector2 input) //recibe inputs y los aplica al personaje
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        currentSpeed = isRunning ? runSpeed : speed;
        controller.Move(transform.TransformDirection(moveDirection) * currentSpeed * Time.deltaTime);

        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

    }

    public void Jump()
    {
        if (isGrounded)
        {
            Debug.Log("Salto");
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    public void SetRunning(bool running)
    {
        Debug.Log("Run");
        isRunning = running; // Cambiar estado de correr
    }

}
