using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("PLAYER SETTINGS")]
    public float movementSpeedPlayer;

    [Header("PLAYER SETTINGS IN BRIDGE")]
    public float limitMovementMax_X;
    public float limitMovementMin_X;
    public float limitMovementMax_Y;
    public float limitMovementMin_Y;

    [Header("BRIDGE SETTINGS")]
    public float bridgeSpeedMovement;
    public float distanceToDestroyBridge;
    public float bridgeSizeForInstantiation;
    public GameObject bridgePrefab;

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    private void Update()
    {

    }
}
