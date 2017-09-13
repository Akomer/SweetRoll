using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject floorParent;
    [SerializeField]
    private GameObject floorPrefab;
    private float distance;

    [SerializeField]
    private ObstacleGenerator obstacleGenerator;

    // Use this for initialization
    void Start()
    {
        var boxCollider = floorPrefab.GetComponent<BoxCollider2D>();
        distance = boxCollider.size.x;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Floor")
        {
            var spawnPosition = other.transform.position + Vector3.right * (distance + 0.001f);
            var floor = Instantiate(floorPrefab, spawnPosition, Quaternion.identity, floorParent.transform);
            var obstaclePrefab = obstacleGenerator.GenerateNextObstacle();
            var spawnData = obstaclePrefab.GetComponent<ObstacleSpawnDAO>();
            var pos = spawnData.GetPositionV3() + floor.transform.position;
            var newObstacle = Instantiate(obstaclePrefab, pos, Quaternion.identity, floor.transform);
        }
    }

}
