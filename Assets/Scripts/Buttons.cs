using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour 
{

	void Start () 
	{
	
	}

	void Update () 
	{

	}

	void OnMouseDown()
	{
		switch(this.gameObject.name)
		{
		case "ContinueButton":
			PlayerPrefs.SetString("name", GameObject.Find("NameField").GetComponent<TextField>().getName());
			Application.LoadLevel("Menu");
			break;
		case "Ranking":
			PlayerPrefs.SetFloat("lastScore", 0);
			Application.LoadLevel("Ranking");
			break;
		default:
			Application.LoadLevel(this.gameObject.name);
			break;
		}
	}
}
