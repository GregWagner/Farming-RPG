﻿using System;
using UnityEngine;

public class Player : SingletonMonobehaviour<Player> {
    // Movement Parameters
    private float xInput;
    private float yInput;
    private bool isCarrying = false;
    private bool isIdle;
    private bool isLiftingToolDown;
    private bool isLiftingToolLeft;
    private bool isLiftingToolRight;
    private bool isLiftingToolUp;
    private bool isRunning;
    private bool isUsingToolDown;
    private bool isUsingToolLeft;
    private bool isUsingToolRight;
    private bool isUsingToolUp;
    private bool isSwingingToolDown;
    private bool isSwingingToolLeft;
    private bool isSwingingToolRight;
    private bool isSwingingToolUp;
    private bool isWalking;
    private bool isPickingUp;
    private bool isPickingDown;
    private bool isPickingLeft;
    private bool isPickingRight; 

    private ToolEffect toolEffect = ToolEffect.None;

    private Rigidbody2D rigidbody2D;

    private Direction playerDirection;

    private float movementSpeed;

    private bool _playerInputIsDisabled {
        get => _playerInputIsDisabled;
        set => _playerInputIsDisabled = value;
    }

    protected override void Awake() {
       base.Awake();

       rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        #region Player Input
        ResetAnimationTriggers();

        PlayerMovementInput();
        PlayerWalkInput();
        
        // Send event to any listeners for player movement input
        EventHandler.CallMovementEvent(xInput, yInput, isWalking, isRunning, isIdle, isCarrying, toolEffect,
                                       isUsingToolRight, isUsingToolLeft, isUsingToolUp, isUsingToolDown,
                                       isLiftingToolRight, isLiftingToolLeft, isLiftingToolUp, isLiftingToolDown,
                                       isPickingRight, isPickingLeft, isPickingUp, isPickingDown,
                                       isSwingingToolRight, isSwingingToolLeft, isSwingingToolUp, isSwingingToolDown,
                                       false, false, false, false);

        #endregion
    }

    private void FixedUpdate() {
        PlayerMovement();
    }

    private void PlayerMovement() {
        Vector2 move = new Vector2(xInput * movementSpeed * Time.deltaTime,
                                   yInput * movementSpeed * Time.deltaTime);
        
        rigidbody2D.MovePosition(rigidbody2D.position + move);
    }

    private void ResetAnimationTriggers() {
        isPickingRight = false;
        isPickingLeft = false;
        isPickingUp = false;
        isPickingDown = false;
        isUsingToolRight = false;
        isUsingToolLeft = false;
        isUsingToolUp = false;
        isUsingToolDown = false;
        isLiftingToolRight = false;
        isLiftingToolLeft = false;
        isLiftingToolUp = false;
        isLiftingToolDown = false;
        isSwingingToolRight = false;
        isSwingingToolLeft = false;
        isSwingingToolUp = false;
        isSwingingToolDown = false;
        toolEffect = ToolEffect.None;
    }
    
    private void PlayerMovementInput() {
        yInput = Input.GetAxisRaw("Vertical");
        xInput = Input.GetAxisRaw("Horizontal");

        // check if moving diagonally
        if (yInput != 0 && xInput != 0) {
            xInput = xInput * 0.71f;
            yInput = yInput * 0.71f;
        }

        if (xInput != 0 || yInput != 0) {
            isRunning = true;
            isWalking = false;
            isIdle = false;
            movementSpeed = Settings.runningSpeed;

            // Capture player direction for save game
            if (xInput < 0) {
                playerDirection = Direction.Left;
            } else if (xInput > 0) {
                playerDirection = Direction.Right;
            } else if (yInput < 0) {
                playerDirection = Direction.Down;
            } else {
                playerDirection = Direction.Up;
            }
        } else if (xInput == 0 && yInput == 0) {
            isRunning = false;
            isWalking = false;
            isIdle = true;
        }
    }
    
    private void PlayerWalkInput() {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
            isRunning = false;
            isWalking = true;
            isIdle = false;
            movementSpeed = Settings.walkingSpeed;
        } else {
            isRunning = true;
            isWalking = false;
            isIdle = false;
            movementSpeed = Settings.runningSpeed;
        }
    }
}
