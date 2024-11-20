using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.GameplayActions gameplay;
    private PlayerMovement movement;


    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        gameplay = playerInput.Gameplay;
        movement = GetComponent<PlayerMovement>();
        gameplay.Jump.performed += ctx => movement.Jump();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //decimos al playermovement que se mueva usando los valores de nuestras actions
        movement.ProcessMove(gameplay.Move.ReadValue<Vector2>());
        
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
