using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollActions : MonoBehaviour
{
    private bool rollIsBig;
    private bool inAir;
    private bool inDash;
    private Rigidbody2D body;

    private float basePositionX;

    private bool dashForward;
    private float dashDistance = 6f;
    private float dashForwardTime = 0.2f;
    private float dashBackwardTime = 0.6f;

    void Start()
    {
        rollIsBig = true;
        inAir = false;
        inDash = false;
        body = GetComponent<Rigidbody2D>();

        basePositionX = -5.65f;
    }

    void Update()
    {
        if(inDash)
        {
            if(dashForward)
            {
                if(transform.position.x < (basePositionX + dashDistance))
                {
                    var pos = transform.position;
                    pos.x += Time.deltaTime / dashForwardTime * dashDistance;
                    transform.position = pos;
                }
                else
                {
                    dashForward = false;
                }
            }
            else
            {
                if(transform.position.x > basePositionX)
                {
                    var pos = transform.position;
                    pos.x -= Time.deltaTime / dashBackwardTime * dashDistance;
                    transform.position = pos;
                }
                else
                {
                    inDash = false;
                }
            }
        }
    }

    public bool IsDashing
    {
        get { return dashForward; }
        private set{ }
    }

    public void ScaleSizeUp()
    {
        if(!rollIsBig)
        {
            transform.localScale *= 2;
            rollIsBig = true;
        }
    }

    public void ScaleSizeDown()
    {
        if(rollIsBig)
        {
            transform.localScale /= 2;
            rollIsBig = false;
        }
    }

    public void Jump()
    {
        if(inAir)
            return;

        float jumpPower = 0;
        if(rollIsBig)
            jumpPower = 9f;
        else
            jumpPower = 6f;

        body.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        inAir = true;
    }

    public void Dash()
    {
        if(inDash)
            return;
        dashForward = true;
        inDash = true;
    }

    public void BreakABit()
    {
        transform.position = transform.position + new Vector3(-.4f, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Floor")
        {
            inAir = false;
        }
    }

}
