using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{

    private float xBorderOfScreen;
    private float destroyDistance;
    // Use this for initialization

    void Start()
    {
        CalculateXBorderOfScreen();
        destroyDistance = -5f;
    }
	
    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < xBorderOfScreen + destroyDistance)
        {
            Destroy(gameObject);
        }
    }

    void CalculateXBorderOfScreen()
    {
        xBorderOfScreen = -8.5F;
    }

}
