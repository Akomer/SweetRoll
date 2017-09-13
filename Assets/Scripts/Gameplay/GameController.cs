using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour, 
IListener<PlayerLifeLostEvent>
{

    private int lifeCounter;
    [SerializeField]
    private GameObject UILifeBar;

    [SerializeField]
    private Text scoreText;

    private int score;

    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            scoreText.text = score.ToString();
        }
    }

    // Use this for initialization
    void Start()
    {
        EventAggregator.Register<PlayerLifeLostEvent>(this);
        lifeCounter = 3;
        Score = 0;
    }

    void OnDestroy()
    {
        EventAggregator.UnRegister<PlayerLifeLostEvent>(this);
    }
	
    // Update is called once per frame
    void Update()
    {
		
    }

    #region IListener implementation

    void IListener<PlayerLifeLostEvent>.Handle(PlayerLifeLostEvent message)
    {
        DecreaseLife();
    }

    #endregion

    void DecreaseLife()
    {
        lifeCounter--;
        var lifeController = UILifeBar.GetComponent<UILifeController>();
        lifeController.lifes[lifeCounter].SetActive(false);
    }
}
