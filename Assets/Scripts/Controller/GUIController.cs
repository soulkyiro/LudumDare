using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {
    private float _h, _w;
    public GUISkin mySkin = null;
    private string view;

    public Texture2D imagenFondo;
    public Texture2D imagenFrente;
    public Texture2D title = Resources.Load("Textures/connected") as Texture2D;
    public Texture2D tutorial = Resources.Load("Textures/tutorial") as Texture2D;
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
        GUI.Box(new Rect(0, 0, (_w/4) * 3, (_h/4)), title);

        if (GUI.Button(new Rect((_w / 4), (_h / 6) * 2, (_w / 6) * 1.5f, (_h / 8)), new GUIContent("PLAY")))
        {
            Debug.Log("PLAY");
			ApplicationController.Instance.NavigationController.NextScene("Scene");
            ApplicationController.Instance.GameController.PlayGame();
        }

        if (GUI.Button(new Rect((_w / 4), (_h / 6) * 3, (_w / 6) * 1.5f, (_h / 8)), new GUIContent("INSTRUCTIONS")))
        {
            Debug.Log("INSTRUCTIONS");
            View = "INSTRUCTIONS";
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

        GUI.Label (new Rect(_w/9, _h/9, (_w/6) * 4, (_h/6) * 4),"Project leader: Estanislao Castro Nieblas \n" +
            "Main programmer: Estanislao Castro Nieblas \n" +
            "Level designers: Silverio Cardona Rodríguez and Israel Fleitas \n" +
            "Programmer: Silverio Cardona Rodríguez \n" +
            "Sound: Israel Fleitas \n" +
            "Illustrator: Francisco Montesdeoca Vega \n" +
            "Tester: Carlota Texeira Saavedra \n" +
            "Marketing: Israel Fleitas \n" +
            "Editor and Community manager: Carlota Texeira Saavedra \n" +
            
            "Sounds \n" +
            "RocketBag clip: Joshun \n" +
            "Signal clip: GameAudio \n" +
            "Music: Betray_09 \n" +

            "Skybox: HedgehogTeam                      THANK YOU"
            );


        if (GUI.Button(new Rect((_w / 4), (_h / 6) * 5, (_w / 6) * 1.5f, (_h / 8)), new GUIContent("BACK")))
        {
            View = "MAIN";
            Debug.Log("BACK");
        }
    }

    void GUIInstructionsPanel()
    {
        GUI.Label(new Rect((_w / 2) - (_w / 6), 0, (_w / 6) * 2, (_h / 6)), "INSTRUCTIONS");

        GUI.Box(new Rect(_w / 9, _h / 9, (_w / 6) * 4, (_h / 6) * 4), tutorial);

        if (GUI.Button(new Rect((_w / 4), (_h / 6) * 5, (_w / 6) * 1.5f, (_h / 8)), new GUIContent("BACK")))
        {
            View = "MAIN";
            Debug.Log("BACK");
        }
    }

    void GUIPlayPanel()
    {
        //GUI.BeginGroup(new Rect(10,10,256,10));
        //    GUI.Box(new Rect(0, 0, 256, 10), imagenFondo);
        //    GUI.BeginGroup(new Rect(0, 0, 256, 10));
        //        GUI.Box(new Rect(0, 0, 128, 10),imagenFrente);
        //    GUI.EndGroup();
        //GUI.EndGroup();

        if (GUI.Button(new Rect((_w / 4), 0, (_w / 6) * 1.5f, (_h / 8)), new GUIContent("PAUSE")))
        {
            ApplicationController.Instance.GameController.LevelController.Pause();
            View = "MENU";
            Debug.Log("PAUSE");
        }
    }

    void GUIMenuPanel()
    {
        GUI.Label(new Rect((_w / 2) - (_w / 6), 0, (_w / 6) * 2, (_h / 6)), "MENU");

        if (GUI.Button(new Rect((_w / 4), (_h / 6) * 2, (_w / 6) * 1.5f, (_h / 8)), new GUIContent("EXIT")))
        {
            Debug.Log("EXIT");
            ApplicationController.Instance.GameController.LevelController.Pause();
            ApplicationController.Instance.NavigationController.PreviousScene();
        }

        if (GUI.Button(new Rect((_w / 4), (_h / 6) * 5, (_w / 6) * 1.5f, (_h / 8)), new GUIContent("BACK")))
        {
            ApplicationController.Instance.GameController.LevelController.Pause();
            View = "PLAY";
            Debug.Log("BACK");
        }
    }
}
