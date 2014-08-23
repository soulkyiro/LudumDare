﻿using UnityEngine;
using System.Collections;

public class ApplicationController : Singleton<ApplicationController>
{
    private GameController gameController;
    private NavigationController navigationController;
    private SoundController soundController;

    protected ApplicationController() { }

    public SoundController SoundController
    {
        get { return soundController; }
        set { soundController = value; }
    }

    public GameController GameController
    {
        get { return gameController; }
        set { gameController = value; }
    }   

    public NavigationController NavigationController
    {
        get { return navigationController; }
        set { navigationController = value; }
    }

    void Start()
    {
        GameController = this.gameObject.AddComponent<GameController>();
        NavigationController = this.gameObject.AddComponent<NavigationController>();
        SoundController = this.gameObject.AddComponent<SoundController>();
        
	}
}