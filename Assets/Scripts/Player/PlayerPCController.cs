using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPCController : MonoBehaviour
{
    private RollActions rollActions;

    // Use this for initialization
    void Start()
    {
        rollActions = GetComponent<RollActions>();
    }
	
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
            rollActions.Jump();

        if(Input.GetKeyDown("right"))
            rollActions.Dash();

        if(Input.GetKeyDown("left"))
            rollActions.BreakABit();

        if(Input.GetKeyDown("up"))
            rollActions.ScaleSizeUp();

        if(Input.GetKeyDown("down"))
            rollActions.ScaleSizeDown();
    }
}
