using UnityEngine;
using System.Collections;

public class Date : MonoBehaviour 
{
	string day, month, year;

	void Start () 
	{
		this.day = System.DateTime.UtcNow.Day.ToString();
		this.month = System.DateTime.UtcNow.Month.ToString();
		this.year = System.DateTime.UtcNow.Year.ToString();
	}

	void Update () 
	{
		this.GetComponent<GUIText>().text = "" + day + "/" + month + "/" + year;
	}
}
