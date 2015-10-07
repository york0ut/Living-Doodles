using UnityEngine;
using System.Collections;

public class TextField : MonoBehaviour 
{
	string textField;
	public GUISkin skin;

	void Start () 
	{
		PlayerPrefs.SetString("name", "");
		this.textField = "Here";
	}
	

	void Update () 
	{
	
	}

	void OnGUI()
	{
		GUI.skin = skin;
		this.textField = GUI.TextField(new Rect(260,290,250,100), this.textField, 8);

		if (Event.current.keyCode == KeyCode.Return)
		{
			PlayerPrefs.SetString("name", GameObject.Find("NameField").GetComponent<TextField>().getName());
			Application.LoadLevel("Menu");
		}
	}

	public string getName()
	{
		return this.textField;
	}
}
