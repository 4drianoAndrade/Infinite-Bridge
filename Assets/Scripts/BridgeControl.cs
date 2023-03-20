using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeControl : MonoBehaviour
{
    private GameController _GameController;

    private Rigidbody2D rb2DBridgeComponent;

    // Control variables
    private bool isInstantiated;

    private void Awake()
    {
        _GameController = FindObjectOfType<GameController>();

        rb2DBridgeComponent = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb2DBridgeComponent.velocity = new Vector2(_GameController.bridgeSpeedMovement, 0f);
    }

    private void Update()
    {
        if (isInstantiated == false)
        {
            if (transform.position.x <= 0f)
            {
                isInstantiated = true;

                GameObject bridgeTemp = Instantiate(_GameController.bridgePrefab);
                float instantiatePositionX = transform.position.x + _GameController.bridgeSizeForInstantiation;
                bridgeTemp.transform.position = new Vector2(instantiatePositionX, transform.position.y);
            }
        }

        if (transform.position.x <= _GameController.distanceToDestroyBridge)
        {
            Destroy(this.gameObject);
        }
    }
}
