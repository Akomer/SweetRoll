using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDeleter : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
		
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Floor")
        {
            GameObject.Destroy(other.gameObject);
        }
        if(other.tag == "Obstacle")
        {
            GameObject.Destroy(other.gameObject);
        }
    }
}
