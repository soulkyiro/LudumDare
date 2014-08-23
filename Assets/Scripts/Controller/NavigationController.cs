using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NavigationController : MonoBehaviour
{
    public const string SCENE_INIT = "Init";
    public const string SCENE_SCENE0 = "Scene0";

    public Stack<string> scenes;
	
	void Start () {
        scenes = new Stack<string>();
        scenes.Push(CurrentScene);
        NextScene(SCENE_INIT);
	}

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            PreviousScene();
        } 
    }    
    
    public string CurrentScene
    {
        get { return Application.loadedLevelName.ToString(); }
    }

    public void NextScene(string scene)
    {
        scenes.Push(CurrentScene);
        ChangeScene(scene);
    }

    public void PreviousScene()
    {
        if (SCENE_INIT == CurrentScene)
        {
            Escape();
        }
        else 
        { 
            ChangeScene(scenes.Pop());
        }
    }

    private void ChangeScene(string scene)
    {
        if (CurrentSceneEquals(scene))
        {
            return;
        }
        else
        {
            Application.LoadLevel(scene);
        }
    }

    private bool CurrentSceneEquals(string scene)
    {
        return CurrentScene.Equals(scene);
    }

    private void Escape()
    {
        Application.Quit();
    }

    public void RestartScene() {
        Application.LoadLevel(CurrentScene);
    }

    public void ChangeBetweenScenes(string scene) {
        ChangeScene(scene);
    }
}
