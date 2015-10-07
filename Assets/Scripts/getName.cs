using UnityEngine;
using System.Collections;

public class getName : MonoBehaviour 
{
	void Start () 
	{

	}

	void Update () 
	{
		this.GetComponent<GUIText>().text = "Name: "+PlayerPrefs.GetString("name");
	}
}
