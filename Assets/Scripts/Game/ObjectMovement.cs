using UnityEngine;
using System.Collections;

public class ObjectMovement : MonoBehaviour 
{
	float speed;

	void Start()
	{
	/*		switch(this.gameObject.name)
			{
			case "nave(Clone)":
				this.speed = 0.025f;
				break;
			case "chainsaw(Clone)":
				this.speed = 0.025f;
				break;
			case "monster(Clone)":
				this.speed = 0.025f;
				break;
			}*/
		speed = 0.025f;
	}

	void FixedUpdate () 
	{

		if (GameObject.Find ("Game Manager").GetComponent<GameManager> ().getStart())
		{
			this.transform.Translate(-speed, 0, 0);
			speed = Camera.main.GetComponent<SpeedManager>().GetSpeed();
		}
	}
}
