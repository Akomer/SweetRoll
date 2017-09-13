using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameplayHandler : MonoBehaviour
{

    private RollActions rollActions;

    // Use this for initialization
    void Start()
    {
        rollActions = GetComponent<RollActions>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Obstacle")
        {
            var obstacleInfo = other.GetComponent<ObstacleInfo>();
            if(obstacleInfo.Breakable && rollActions.IsDashing)
            {
                Destroy(other.gameObject);
            }
            else
            {
                EventAggregator.SendMessage<PlayerLifeLostEvent>();
                StartCoroutine(FlickerWithOpacity());
            }

        }
    }

    IEnumerator FlickerWithOpacity()
    {
        var renderer = GetComponent<SpriteRenderer>();
        var secBetweenFlicks = 0.07f;
        var colorBase = renderer.color;
        var colorWithAlphaChange = colorBase;
        colorWithAlphaChange.a = 0.5f;
        for(int i = 0; i < 5; ++i)
        {
            renderer.color = colorWithAlphaChange;
            yield return new WaitForSeconds(secBetweenFlicks);
            renderer.color = colorBase;
            yield return new WaitForSeconds(secBetweenFlicks);
        }
    }


}
