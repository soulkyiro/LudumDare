using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    private LevelController levelController;
    private NavigationController navigatorController;

    public int NUM_MAX_DEATHS = 2;
    private int numOfDeaths= 0;

    void Start() {
        navigatorController = ApplicationController.Instance.NavigationController;
    }

    public int NumOfDeaths
    {
        get { return numOfDeaths; }
        set { numOfDeaths = value; }
    }

    public LevelController LevelController
    {
        get { return levelController; }
        set { levelController = value; }
    }

    public void PlayGame() {
        GameObject LevelController = new GameObject();
        LevelController.name = "LevelController";
        LevelController.AddComponent<LevelController>();
    }

    private void IncrementNumOfDeaths()
    {
        numOfDeaths++;
    }

    private void RestartNumOFDeaths()
    {
        numOfDeaths = 0;
    }

    public void RestartLevel()
    {
        IncrementNumOfDeaths();
        Debug.Log("Numero de muertes" + numOfDeaths);

        if (NumOfDeaths > NUM_MAX_DEATHS)
        {
            LevelController.LevelFail();
            RestartNumOFDeaths();
            navigatorController.PreviousScene();
        }
        else 
        {
            navigatorController.RestartScene();      
        }
    }
    public void NextLevel() {
        if (navigatorController.CurrentScene == "Scene0") 
        {
            navigatorController.ChangeBetweenScenes("Scene1");
        }
        if (navigatorController.CurrentScene == "Scene1")
        {
            navigatorController.PreviousScene();
            RestartNumOFDeaths();
        }
    }
}
