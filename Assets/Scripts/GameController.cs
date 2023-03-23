using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Player _Player;

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

    [Header("BARREL SETTINGS")]
    public float barrelSpeedMovement;
    public float distanceToDestroyBarrel;
    public float positionSpawnBarrelTop_Y;
    public float positionSpawnBarrelBottom_Y;
    public int orderTopBarrel;
    public int orderBottomBarrel;
    public GameObject barrelPrefab;
    public float timeToRespawnBarrel;

    [Header("GLOBAL VARIABLES")]
    public float positionXPlayer;

    [Header("GAME SCORE")]
    public int gameScore;

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        _Player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        StartCoroutine(SpawnBarril());
    }

    private void Update()
    {

    }

    IEnumerator SpawnBarril()
    {
        float positionBarrel_Y = 0f;
        int orderBarrel = 0;

        int randomNumberRespawnBarrel = Random.Range(0, 100);

        if (randomNumberRespawnBarrel < 50)
        {
            positionBarrel_Y = positionSpawnBarrelTop_Y;
            orderBarrel = orderTopBarrel;
        }
        else
        {
            positionBarrel_Y = positionSpawnBarrelBottom_Y;
            orderBarrel = orderBottomBarrel;
        }

        GameObject barrelTemp = Instantiate(barrelPrefab);
        barrelTemp.transform.position = new Vector2(barrelTemp.transform.position.x, positionBarrel_Y);
        barrelTemp.GetComponent<SpriteRenderer>().sortingOrder = orderBarrel;

        yield return new WaitForSeconds(timeToRespawnBarrel);
        StartCoroutine(SpawnBarril());
    }

    private void LateUpdate()
    {
        positionXPlayer = _Player.transform.position.x;
    }

    public void ToScore(int amountOfPoints)
    {
        gameScore += amountOfPoints;
    }
}
