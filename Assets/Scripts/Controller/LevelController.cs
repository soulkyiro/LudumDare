using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelController : MonoBehaviour
{

    private bool pause;
	private List<string> letters = new List<string>();
	private string worlds = "worlds";
    private AnimationController animationController;

    public AnimationController AnimationController
    {
        get { return animationController; }
        set { animationController = value; }
    }

	void Start()
    {
		pause = false;
        AnimationController = this.gameObject.AddComponent<AnimationController>();
	}

	public void Pause () 
    {
		if(!pause)
        {
			pause = true;
			Time.timeScale = 0;
		}
		else
        {
			pause = false;
			Time.timeScale = 1;
		}
	}

    public void LevelFail()
    {
        //FinishState("GameOver");
        Debug.Log("GameOver");
    }

    public void LevelComplete()
    {
        //FinishState("Congratulation");
        Debug.Log("Congratulation");
        ApplicationController.Instance.NavigationController.ChangeBetweenScenes("Finish");
        ApplicationController.Instance.GUIController.View = "FINISH";
    }
    
	public void FinishState (string end){
        //GameController.Instance.transform.DetachChildren();
		//GameController.Instance.Load(7);
        //GameController.View = end;
	}

    public void FinishLevel() {
        ApplicationController.Instance.GameController.NextLevel();
    }
    
	public void Restart (){
        ApplicationController.Instance.GameController.RestartLevel();
	}

	public void AddLetter (string letter){
		if (!letters.Contains(letter)){
			Debug.Log (letter);
			letters.Add(letter);
			if (letters.Count == worlds.Length){
				LevelComplete();
			}
		}
	}
}
