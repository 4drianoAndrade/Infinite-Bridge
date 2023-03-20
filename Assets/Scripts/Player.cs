using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2DPlayerComponent;

    [Header("Player Settings")]
    public float movementSpeedPlayer;

    private void Awake()
    {
        rb2DPlayerComponent = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        rb2DPlayerComponent.velocity = new Vector2(horizontalInput * movementSpeedPlayer, verticalInput * movementSpeedPlayer);
    }
}
