using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour 
{
	float speed = 0.07f;

	void FixedUpdate () 
	{
		if (GameObject.Find ("Game Manager").GetComponent<GameManager> ().getStart())
		{
			this.transform.Translate(-speed, 0, 0);

			if (this.transform.position.x <= -8f && this.gameObject.name.Equals("Background2"))
			{
				this.transform.position = new Vector3(7.8f, this.transform.position.y, this.transform.position.z);
			}
		}
	}
}
