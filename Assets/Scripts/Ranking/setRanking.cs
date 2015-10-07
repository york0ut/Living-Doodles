using UnityEngine;
using System.Collections;

public class setRanking : MonoBehaviour 
{

	void Start () 
	{

	}

	void Update () 
	{
		for(int i=1;i<=10;i++)
		{
			GameObject.Find(i+".").GetComponent<GUIText>().text = i+". "+PlayerPrefs.GetString("highString"+i)+" ...................................................................... "+PlayerPrefs.GetFloat("highScore"+i).ToString();
		}
	}
}
