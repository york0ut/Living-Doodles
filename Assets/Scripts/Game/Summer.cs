using UnityEngine;
using System.Collections;

public class Summer : MonoBehaviour 
{
	GameObject summerPosition;

	void Start () 
	{
		summerPosition = GameObject.Find ("SummerPosition");
	}

	void Update () 
	{
		transform.position = Vector3.Lerp(transform.position, summerPosition.transform.position, 0.01f);
	}
}
