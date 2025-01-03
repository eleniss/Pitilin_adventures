using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.GameplayActions gameplay;
    private PlayerMovement movement;

    private PlayerLook look;


    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        gameplay = playerInput.Gameplay;
        movement = GetComponent<PlayerMovement>();
        look = GetComponent<PlayerLook>();
        gameplay.Jump.performed += ctx => movement.Jump();

        gameplay.Run.performed += ctx => movement.SetRunning(true);
        gameplay.Run.canceled += ctx => movement.SetRunning(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //decimos al playermovement que se mueva usando los valores de nuestras actions
        movement.ProcessMove(gameplay.Move.ReadValue<Vector2>());

    }
    private void LateUpdate()
    {
        look.ProcessLook(gameplay.Look.ReadValue<Vector2>()); //Look.ReadValue<Vector2>()

    }
    private void OnEnable()
    {
        gameplay.Enable();
    }
    private void OnDisable()
    {
        gameplay.Disable();
    }

}
