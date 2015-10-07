using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour 
{
	bool textVisible = false;
	
	public bool getVisible()
	{
		return this.textVisible;
	}
	
	void Start () 
	{
		StartCoroutine (setText ());
	}
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			this.textVisible = !this.textVisible;
		}
	}

	IEnumerator setText()
	{
		while (true) 
		{
			yield return new WaitForSeconds(2);
			textVisible = true;
		}
	}
}
