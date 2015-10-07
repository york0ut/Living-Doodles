using UnityEngine;
using System.Collections;

public class ChoosePencil : MonoBehaviour 
{
	void Start () 
	{
	
	}

	void Update () 
	{
		
	}

	void OnMouseUp()
	{
		GameObject.Find("TrailPen").GetComponent<DrawLine>().SetTexture(this.gameObject.name);
	}
}
