using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour 
{
	bool pause;

	void Start () 
	{
	
	}

	void Update () 
	{
		if(pause)
		{
			this.GetComponent<GUIText>().text = "Paused";
			Time.timeScale = 0;
		}
		else
		{
			this.GetComponent<GUIText>().text = "Pause";
			Time.timeScale = 1;
		}
	}

	void OnMouseDown()
	{
		if(this.gameObject.name == "Pause")
		this.pause = !pause;
	}
}
