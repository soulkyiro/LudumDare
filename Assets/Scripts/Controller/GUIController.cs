using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {
    private float _h, _w;
    public GUISkin mySkin = null;
    private string view;

    public string View
    {
        get { return view; }
        set { view = value; }
    }

    void Start()
    {
        View = "MAIN";
    }
	
	void Update () {
        _h = Screen.height;
        _w = Screen.width;
	}


    void OnGUI() 
    {
        if (mySkin != null)
        {
            GUI.skin = mySkin;
        }

        switch (View)
        {
            case "MAIN":
                GUIMainPanel();
                break;
            case "CREDITS":
                GUICreditsPanel();
                break;
            case "INSTRUCTIONS":
                GUIInstructionsPanel();
                break;
            case "SCORE":
                GUIScorePanel();
                break;
            case "MENU":
                GUIMenuPanel();
                break;
            case "PLAY":
                GUIPlayPanel();
                break;
        }
    }

    void GUIMainPanel()
    {
        GUI.Label(new Rect((_w / 2) - (_w / 6), 0, (_w / 6) * 2, (_h / 6)), "MAIN SCREEN");


        if (GUI.Button(new Rect((_w / 4), (_h / 6) * 2, (_w / 6) * 1.5f, (_h / 8)), new GUIContent("PLAY")))
        {
            Debug.Log("PLAY");
			ApplicationController.Instance.NavigationController.NextScene("Scene (Silver)");
            ApplicationController.Instance.GameController.PlayGame();
        }

        if (GUI.Button(new Rect((_w / 4), (_h / 6) * 3, (_w / 6) * 1.5f, (_h / 8)), new GUIContent("INSTRUCTIONS")))
        {
            Debug.Log("INSTRUCTIONS");
            View = "INSTRUCTIONS";
        }

        if (GUI.Button(new Rect((_w / 4), (_h / 6) * 4, (_w / 6) * 1.5f, (_h / 8)), new GUIContent("SCORE")))
        {
            Debug.Log("SCORE");
            View = "SCORE";
        }

        if (GUI.Button(new Rect((_w / 4), (_h / 6) * 5, (_w / 6) * 1.5f, (_h / 8)), new GUIContent("CREDITS")))
        {
            Debug.Log("CREDITS");
            View = "CREDITS";
        }
    }

    void GUICreditsPanel()
    {
        GUI.Label(new Rect((_w / 2) - (_w / 6), 0, (_w / 6) * 2, (_h / 6)), "CREDITS");

        GUI.Label (new Rect(_w/6, _h/6, (_w/6) * 4, (_h/6) * 3),"");

        if (GUI.Button(new Rect((_w / 4), (_h / 6) * 5, (_w / 6) * 1.5f, (_h / 8)), new GUIContent("BACK")))
        {
            View = "MAIN";
            Debug.Log("BACK");
        }
    }

    void GUIInstructionsPanel()
    {
        GUI.Label(new Rect((_w / 2) - (_w / 6), 0, (_w / 6) * 2, (_h / 6)), "INSTRUCTIONS");

        GUI.Label(new Rect(_w / 6, _h / 6, (_w / 6) * 4, (_h / 6) * 3), "");

        if (GUI.Button(new Rect((_w / 4), (_h / 6) * 5, (_w / 6) * 1.5f, (_h / 8)), new GUIContent("BACK")))
        {
            View = "MAIN";
            Debug.Log("BACK");
        }
    }

    void GUIPlayPanel()
    {
        GUI.Label(new Rect((_w / 2) - (_w / 6), 0, (_w / 6) * 2, (_h / 6)), "PLAY");

        GUI.Label(new Rect(_w / 6, _h / 6, (_w / 6) * 4, (_h / 6) * 3), "");

        if (GUI.Button(new Rect((_w / 4), (_h / 6) * 5, (_w / 6) * 1.5f, (_h / 8)), new GUIContent("PAUSE")))
        {
            ApplicationController.Instance.GameController.LevelController.Pause();
            View = "MENU";
            Debug.Log("PAUSE");
        }
    }

    void GUIMenuPanel()
    {
        GUI.Label(new Rect((_w / 2) - (_w / 6), 0, (_w / 6) * 2, (_h / 6)), "MENU");

        GUI.Label(new Rect(_w / 6, _h / 6, (_w / 6) * 4, (_h / 6) * 3), "");

        if (GUI.Button(new Rect((_w / 4), (_h / 6) * 5, (_w / 6) * 1.5f, (_h / 8)), new GUIContent("BACK")))
        {
            ApplicationController.Instance.GameController.LevelController.Pause();
            View = "PLAY";
            Debug.Log("BACK");
        }
    }

    void GUIScorePanel()
    {
        GUI.Label(new Rect((_w / 2) - (_w / 6), 0, (_w / 6) * 2, (_h / 6)), "SCORE");

        GUI.Label(new Rect(_w / 6, _h / 6, (_w / 6) * 4, (_h / 6) * 3), "");

        if (GUI.Button(new Rect((_w / 4), (_h / 6) * 5, (_w / 6) * 1.5f, (_h / 8)), new GUIContent("BACK")))
        {
            View = "MAIN";
            Debug.Log("BACK");
        }
    }

}
