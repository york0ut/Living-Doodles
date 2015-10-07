using UnityEngine;
using System.Collections;

public class Trampoline : MonoBehaviour 
{
	public Sprite on, off;
	bool active;

	void Start () 
	{
	
	}

	void FixedUpdate () 
	{
		this.transform.Translate (-0.05f, 0, 0);

		if (this.active)
		{
			this.gameObject.GetComponent<SpriteRenderer>().sprite = on;
		}
		else
		{
			this.gameObject.GetComponent<SpriteRenderer>().sprite = off;
		}
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		if (c.gameObject.name.Equals("Player"))
		{
			this.active = true;
			c.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 100 * Time.deltaTime);
			GameObject.Find("SoundJump").GetComponent<AudioSource>().Play();
		}
	}

	void OnCollisionExit2D()
	{
		this.active = false;
	}
}
