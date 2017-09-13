using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveGameSettings
{
    private static ActiveGameSettings instance;

    public float gameSpeed;
    public float accelerationPerSecond;
    public float maxSpeed;

    public static ActiveGameSettings Instance
    { 
        get
        {
            if(instance == null)
                Instance = new ActiveGameSettings();
            return instance; 
        }
        private set
        { 
            instance = value; 
        }
    }

    private ActiveGameSettings()
    {
        gameSpeed = 5f;
        accelerationPerSecond = 0.1f;
        maxSpeed = 8f;
    }
}
