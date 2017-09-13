using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Vector3 firstPosition;
    private Vector3 lastPosition;
    private RollActions rollActions;

    // Use this for initialization
    void Start()
    {
        rollActions = GetComponent<RollActions>();
    }
	
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount == 0)
            return;

        var touch = Input.GetTouch(0);
        if(touch.phase == TouchPhase.Began)
        {
            firstPosition = touch.position;
            lastPosition = touch.position;
        }
        else if(touch.phase == TouchPhase.Ended)
        {
            lastPosition = touch.position;

            if(TouchWasSwipe())
                ProcessSwipe();
            else
                ProcessTap();
        }
    }

    bool TouchWasSwipe()
    {
        return firstPosition != lastPosition;
    }

    void ProcessTap()
    {
        rollActions.Jump();
    }

    private void ProcessSwipe()
    {
        var swipeDirection = lastPosition - firstPosition;
        if(SwipeHorizontalIsLongerThenVertivcal(swipeDirection))
        {
            if(SwipeForward(swipeDirection))
            {
                rollActions.Dash();
            }
            else
            {
                rollActions.BreakABit();
            }
        }
        else
        {
            if(SwipeUp(swipeDirection))
            {
                rollActions.ScaleSizeUp();
            }
            else
            {
                rollActions.ScaleSizeDown();
            }
        }
    }

    private bool SwipeHorizontalIsLongerThenVertivcal(Vector3 swipe)
    {
        return Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y);
    }

    bool SwipeForward(Vector3 swipeDirection)
    {
        return swipeDirection.x > 0;
    }

    bool SwipeUp(Vector3 swipeDirection)
    {
        return swipeDirection.y > 0;
    }
}
