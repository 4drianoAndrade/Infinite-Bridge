using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2DPlayerComponent;

    [Header("PLAYER SETTINGS")]
    public float movementSpeedPlayer;

    public float limitMovementMax_X;
    public float limitMovementMin_X;
    public float limitMovementMax_Y;
    public float limitMovementMin_Y;

    private void Awake()
    {
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

        rb2DPlayerComponent.velocity = new Vector2(horizontalInput * movementSpeedPlayer, verticalInput * movementSpeedPlayer);

        if (transform.position.x >= limitMovementMax_X)
        {
            currentPositionPlayerX = limitMovementMax_X;
        }
        else if (transform.position.x <= limitMovementMin_X)
        {
            currentPositionPlayerX = limitMovementMin_X;
        }

        if (transform.position.y >= limitMovementMax_Y)
        {
            currentPositionPlayerY = limitMovementMax_Y;
        }
        else if (transform.position.y <= limitMovementMin_Y)
        {
            currentPositionPlayerY = limitMovementMin_Y;
        }

        transform.position = new Vector2(currentPositionPlayerX, currentPositionPlayerY);
    }
}
