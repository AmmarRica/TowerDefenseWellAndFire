using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{

    // Declare any public variables that you want to be able 
    // to access throughout your scene
    //e.g. public PlayersManager playersManager;



    public static SceneController Instance { get; private set; } // static singleton
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else { Destroy(gameObject); }

        // Cache references to all desired variables
        //example: playersManager = FindObjectOfType<PlayersManager>(); 
    }
}