using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameController _GameController;

    private Rigidbody2D rb2DPlayerComponent;

    private void Awake()
    {
        _GameController = FindObjectOfType<GameController>();

        rb2DPlayerComponent = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        MovementPlayer();
    }

    private void MovementPlayer()
    {
        // Old Unity input system
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        float currentPositionPlayerX = transform.position.x;
        float currentPositionPlayerY = transform.position.y;

        rb2DPlayerComponent.velocity = new Vector2(horizontalInput * _GameController.movementSpeedPlayer, verticalInput * _GameController.movementSpeedPlayer);

        if (transform.position.x >= _GameController.limitMovementMax_X)
        {
            currentPositionPlayerX = _GameController.limitMovementMax_X;
        }
        else if (transform.position.x <= _GameController.limitMovementMin_X)
        {
            currentPositionPlayerX = _GameController.limitMovementMin_X;
        }

        if (transform.position.y >= _GameController.limitMovementMax_Y)
        {
            currentPositionPlayerY = _GameController.limitMovementMax_Y;
        }
        else if (transform.position.y <= _GameController.limitMovementMin_Y)
        {
            currentPositionPlayerY = _GameController.limitMovementMin_Y;
        }

        transform.position = new Vector2(currentPositionPlayerX, currentPositionPlayerY);
    }
}
