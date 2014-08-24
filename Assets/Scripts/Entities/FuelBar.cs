using UnityEngine;
using System.Collections;

public class FuelBar: MonoBehaviour {
	
	public int maxHealth = 100;
	public float currentHealth = 100;
	
	public Texture2D bgImage; 
	public Texture2D fgImage; 
	public float fuelBarHeight = 20;
	public float healthBarLength;


	void Start () {   
		healthBarLength = Screen.width /2;    
	}

	void Update () {
		//AddjustCurrentHealth(0.5f);
	}
	
	void OnGUI () {
		GUI.Box (new Rect (0,0, maxHealth, fuelBarHeight), bgImage);
		//GUI.Box (new Rect (0,0, healthBarLength, fuelBarHeight), fgImage);
	}
	
	public void AddjustCurrentHealth(float adj){
		
		currentHealth -= adj;
		
		if(currentHealth < 0)
			currentHealth = 0;
		
		if(currentHealth > maxHealth)
			currentHealth = maxHealth;
		
		if(maxHealth < 1)
			maxHealth = 1;
		
		healthBarLength = (Screen.width /2) * (currentHealth / (float)maxHealth);
	}
}