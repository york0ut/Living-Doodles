using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour 
{
	void Start () 
	{
		StartCoroutine (change ());
	}
	
	void Update ()
	{
		if(Input.anyKeyDown)
		{
			Application.LoadLevel("Game");
		}
	}

	IEnumerator change()
	{
		while(true)
		{
			yield return new WaitForSeconds(7);
			Application.LoadLevel("Game");
		}
	}

	void OnMouseDown()
	{
		Application.LoadLevel("Game");
	}
}
