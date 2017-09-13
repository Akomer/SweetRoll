using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{

    public GameObject[] availableObstacles;

    public GameObject GenerateNextObstacle()
    {
        return availableObstacles[Random.Range(0, availableObstacles.Length)];
    }
}
