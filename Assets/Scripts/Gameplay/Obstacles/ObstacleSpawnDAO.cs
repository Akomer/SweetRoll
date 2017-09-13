using UnityEngine;

public class ObstacleSpawnDAO : MonoBehaviour
{
    public float x;
    public float y;

    public Vector3 GetPositionV3()
    {
        return new Vector3(x, y, 0);
    }
}
