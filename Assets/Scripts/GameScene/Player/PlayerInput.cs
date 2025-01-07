using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private InputActionAsset actionAsset;
    private InputActionMap actionMap;
    private InputAction moveAction;
    private InputAction sprintAction;
    
    private Vector2 moveInput;
    private bool isSprinting;
    
    void Awake()
    {
        actionAsset = GetComponent<UnityEngine.InputSystem.PlayerInput>().actions;
        actionMap = actionAsset.FindActionMap("Player");
        moveAction = actionMap.FindAction("Move");
        sprintAction = actionMap.FindAction("Sprint");
    }

    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();
        isSprinting = sprintAction.ReadValue<float>() > 0;
    }

    public Vector2 GetMoveInput()
    {
        return moveInput;
    }
    
    public bool IsSprinting()
    {
        return isSprinting;
    }
}
