using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelControl : MonoBehaviour
{
    private GameController _GameController;
    private Rigidbody2D rb2DBarrelComponent;

    private void Awake()
    {
        _GameController = FindObjectOfType<GameController>();
        rb2DBarrelComponent = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb2DBarrelComponent.velocity = new Vector2(_GameController.barrelSpeedMovement, 0f);
    }

    private void Update()
    {
        if (transform.position.x <= _GameController.distanceToDestroyBarrel)
        {
            Destroy(this.gameObject);
        }
    }
}
