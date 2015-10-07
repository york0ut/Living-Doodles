using UnityEngine;
using System.Collections;

public class HintController : MonoBehaviour 
{
	string textHint;

	void Start () 
	{
		this.textHint = "Escuro, falta de luz solar";
		StartCoroutine(checkSun());
	}

	void Update ()
	{

	}

	void OnGUI()
	{
		this.GetComponent<GUIText>().text = "Hint: "+textHint;
	}

	IEnumerator checkSun()
	{
		yield return new WaitForSeconds(5);
		if(!GameObject.Find("Game Manager").GetComponent<GameManager>().getSummer())
		{
			this.textHint = "Como se desenha o sol?";
		}
	}
}
