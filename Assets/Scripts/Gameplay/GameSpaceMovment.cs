using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpaceMovment : MonoBehaviour
{

    private float speed;
    private float acceleration;
    private float maxSpeed;

    private GameController gameController;

    // Use this for initialization
    void Start()
    {
        speed = ActiveGameSettings.Instance.gameSpeed;
        acceleration = ActiveGameSettings.Instance.accelerationPerSecond;
        maxSpeed = ActiveGameSettings.Instance.maxSpeed;
        var gameControllerGO = GameObject.Find("GameController");
        gameController = gameControllerGO.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        var movementDistance = Vector3.left * speed * Time.deltaTime;
        transform.position += movementDistance;
        float scoreMultiplier = 50;
        gameController.Score += Mathf.FloorToInt(movementDistance.magnitude * scoreMultiplier);
        speed += (speed >= maxSpeed) ? 0f : Time.deltaTime * acceleration;
    }
}
