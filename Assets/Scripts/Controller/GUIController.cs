using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {
    private float _h, _w;
    
    private string view;
    private int fontSize;
    private Texture2D title = Resources.Load("Textures/Text/connected") as Texture2D;
    private Texture2D tutorial = Resources.Load("Textures/Images/tutorial") as Texture2D;

    public GUISkin mySkin = null;
    public Texture2D imagenFondo;
    public Texture2D imagenFrente;

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
        fontSize = (int)_w / 32;
	}

    void OnGUI() 
    {
        GUI.skin.box.fontSize = fontSize;
        GUI.skin.button.fontSize = fontSize;
        GUI.skin.label.fontSize = fontSize;

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
            case "FINISH":
                GUIFinishPanel();
                break;
        }
    }

    void GUIMainPanel()
    {
        GUI.Box(new Rect(0, 0, (_w/4) * 3, (_h/4)), title);

        if (GUI.Button(new Rect((_w / 4), (_h / 6) * 2, (_w / 6) * 1.5f, (_h / 8)), new GUIContent("PLAY")))
        {
			ApplicationController.Instance.NavigationController.NextScene("Scene");
            ApplicationController.Instance.GameController.PlayGame();
        }

        if (GUI.Button(new Rect((_w / 6) * 1.25f, (_h / 6) * 3, (_w / 6) * 2f, (_h / 8)), new GUIContent("INSTRUCTIONS")))
        {
            View = "INSTRUCTIONS";
        }

        if (GUI.Button(new Rect((_w / 4), (_h / 6) * 5, (_w / 6) * 1.5f, (_h / 8)), new GUIContent("CREDITS")))
        {
            View = "CREDITS";
        }
    }

    void GUICreditsPanel()
    {
        GUI.Label(new Rect((_w / 2) - (_w / 6), 0, (_w / 6) * 2, (_h / 6)), "CREDITS");

        GUI.Label (new Rect(_w/9, _h/9, (_w/6) * 4, (_h/6) * 4),
            "Estanislao Castro Nieblas \n" +
            "Silverio Cardona Rodríguez \n" +
            "Israel Fleitas \n" +
            "Francisco Montesdeoca Vega \n" +
            "Carlota Texeira Saavedra \n\n" +
            "Sounds \n" +
            "RocketBag clip: Joshun \n" +
            "Signal clip: GameAudio \n" +
            "Music: Betray_09 \n" +

            "Skybox: HedgehogTeam            THANK YOU"

            // "Project leader: Estanislao Castro Nieblas \n" +
            //"Main programmer: Estanislao Castro Nieblas \n" +
            //"Level designers: Silverio Cardona Rodríguez and Israel Fleitas \n" +
            //"Programmer: Silverio Cardona Rodríguez \n" +
            //"Sound: Israel Fleitas \n" +
            //"Illustrator: Francisco Montesdeoca Vega \n" +
            //"Tester: Carlota Texeira Saavedra \n" +
            //"Marketing: Israel Fleitas \n" +
            //"Editor and Community manager: Carlota Texeira Saavedra \n" +
            
            //"Sounds \n" +
            //"RocketBag clip: Joshun \n" +
            //"Signal clip: GameAudio \n" +
            //"Music: Betray_09 \n" +

            //"Skybox: HedgehogTeam                      THANK YOU"
            );


        if (GUI.Button(new Rect((_w / 4), (_h / 6) * 5, (_w / 6) * 1.5f, (_h / 8)), new GUIContent("BACK")))
        {
            View = "MAIN";
        }
    }

    void GUIInstructionsPanel()
    {
        GUI.Label(new Rect((_w / 2) - (_w / 6), 0, (_w / 6) * 2, (_h / 6)), "INSTRUCTIONS");

        GUI.Box(new Rect(_w / 9, _h / 9, (_w / 6) * 3, (_h / 6) * 3), tutorial);
        GUI.Label(new Rect(_w / 9, (_h / 6) * 4, (_w / 6) * 4, (_h / 6) * 4), "The aim  of the game is activate the antennas of each world. ¡Good luck!");

        if (GUI.Button(new Rect((_w / 4), (_h / 6) * 5, (_w / 6) * 1.5f, (_h / 8)), new GUIContent("BACK")))
        {
            View = "MAIN";
        }
    }

    void GUIPlayPanel()
    {
        //GUI.BeginGroup(new Rect(10, 10, 256, 10));
        //GUI.Box(new Rect(0, 0, 256, 10), imagenFondo);
        //GUI.BeginGroup(new Rect(0, 0, 256, 10));
        //GUI.Box(new Rect(0, 0, 128, 10), imagenFrente);
        //GUI.EndGroup();
        //GUI.EndGroup();

        if (GUI.Button(new Rect((_w / 4), 0, (_w / 6) * 1.5f, (_h / 8)), new GUIContent("PAUSE")))
        {
            ApplicationController.Instance.GameController.LevelController.Pause();
            View = "MENU";
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
        }
    }

    void GUIFinishPanel()
    {
        if (GUI.Button(new Rect((_w / 4), (_h / 6) * 5, (_w / 6) * 1.5f, (_h / 8)), new GUIContent("EXIT")))
        {
            ApplicationController.Instance.NavigationController.PreviousScene();
        }
    }
}
