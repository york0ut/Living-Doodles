using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.position = new Vector3(-2.9f, this.transform.position.y, this.transform.position.z);
	}
	
	
	void OnCollisionEnter2D(Collision2D c)
	{
		if (c.gameObject.name.Equals ("Floor"))
			GameObject.Find ("Game Manager").GetComponent<GameManager> ().setStart (true);
		
		if (c.gameObject.name.Equals("Trampoline(Clone)"))
		{
			GetComponent<Rigidbody2D>().AddForce(Vector3.up * 300);
			GetComponent<Rigidbody2D>().AddForce(Vector3.right * 40);
		}
		
		if (c.gameObject.CompareTag("Lose")) 
		{
			GameObject.Find("Game Manager").GetComponent<GameManager>().Lose();
		}
	}
}