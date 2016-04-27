using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBarScript : MonoBehaviour
{
	private Mask heart0;
	private Mask heart1;
	private Mask heart2;

	// Use this for initialization
	void Start ()
	{
		heart0 = GameObject.Find ("Hearts_0").GetComponent<Mask> ();
		heart1 = GameObject.Find ("Hearts_1").GetComponent<Mask> ();
		heart2 = GameObject.Find ("Hearts_2").GetComponent<Mask> ();
	}


	// Update is called once per frame
	void Update ()
	{
		if (HealthManager.playerHealth == 100) {
			heart0.showMaskGraphic = true;
			heart1.showMaskGraphic = true;
			heart2.showMaskGraphic = true;
		} 
		else if (HealthManager.playerHealth <= 65 && HealthManager.playerHealth > 30) 
		{
			heart2.showMaskGraphic = false;
		} 
		else if (HealthManager.playerHealth <= 30 && HealthManager.playerHealth > 0) 
		{
			heart2.showMaskGraphic = false;
			heart1.showMaskGraphic = false;
		}
		else if (HealthManager.playerHealth <= 0) 
		{
			heart0.showMaskGraphic = false;
			heart1.showMaskGraphic = false;
			heart2.showMaskGraphic = false;
		}
		Debug.Log (HealthManager.playerHealth);
	}
}

