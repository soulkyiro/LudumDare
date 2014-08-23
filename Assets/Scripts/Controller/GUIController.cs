using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {
    private float _h, _w;
    public GUISkin mySkin = null;
    private string panel;
	// Use this for initialization
	void Start () {
        panel = "Main";
	}
	
	// Update is called once per frame
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

        switch (panel)
        {
            case "Main":
                GUIMainPanel();
                break;
            case "CREDITS":
                GUICreditsPanel();
                break;
            case "INSTRUCTIONS":

                break;

            case "SCORE": 
                break;
        }
    }

    void GUIMainPanel()
    {
        GUI.Label(new Rect((_w / 2) - (_w / 6), 0, (_w / 6) * 2, (_h / 6)), "MAIN SCREEN");


        if (GUI.Button(new Rect((_w / 4), (_h / 6) * 2, (_w / 6) * 1.5f, (_h / 8)), new GUIContent("PLAY")))
        {
            Debug.Log("PLAY");
            ApplicationController.Instance.NavigationController.NextScene("Scene");

        }

        if (GUI.Button(new Rect((_w / 4), (_h / 6) * 3, (_w / 6) * 1.5f, (_h / 8)), new GUIContent("INSTRUCTIONS")))
        {
            Debug.Log("INSTRUCTIONS");
        }

        if (GUI.Button(new Rect((_w / 4), (_h / 6) * 4, (_w / 6) * 1.5f, (_h / 8)), new GUIContent("SCORE")))
        {
            Debug.Log("SCORE");
        }

        if (GUI.Button(new Rect((_w / 4), (_h / 6) * 5, (_w / 6) * 1.5f, (_h / 8)), new GUIContent("CREDITS")))
        {
            Debug.Log("CREDITS");
            panel = "CREDITS";
        }

        if (GUI.Button(new Rect(_w - ((_w / 6) * 1.5f), _h - (_h / 8), (_w / 6) * 1.5f, (_h / 8)), new GUIContent("CONFIG")))
        {
            Debug.Log("CONFIGURE");
        }
    }

    void GUICreditsPanel()
    {
        GUI.Label(new Rect((_w / 2) - (_w / 6), 0, (_w / 6) * 2, (_h / 6)), "MAIN SCREEN");

        GUI.Label (new Rect(_w/6, _h/6, (_w/6) * 4, (_h/6) * 3),"");

        if (GUI.Button(new Rect((_w / 4), (_h / 6) * 5, (_w / 6) * 1.5f, (_h / 8)), new GUIContent("BACK")))
        {
            panel = "Main";
            Debug.Log("BACK");
        }
    }

    void GUIInstructionsPanel()
    {
        GUI.Label(new Rect((_w / 2) - (_w / 6), 0, (_w / 6) * 2, (_h / 6)), "INSTRUCTIONS");

        GUI.Label(new Rect(_w / 6, _h / 6, (_w / 6) * 4, (_h / 6) * 3), "");

        if (GUI.Button(new Rect((_w / 4), (_h / 6) * 5, (_w / 6) * 1.5f, (_h / 8)), new GUIContent("BACK")))
        {
            panel = "Main";
            Debug.Log("BACK");
        }
    }

}
