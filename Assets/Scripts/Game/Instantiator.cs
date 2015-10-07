using UnityEngine;
using System.Collections;

public class Instantiator : MonoBehaviour {

	public float timeToInstantiate;
	private int currentObstacle;
	public GameObject[] obstacles;
	private Vector3 pos;

	void Start ()
	{
		StartCoroutine (Instantiate());
	}

	void Update()
	{

	}

	IEnumerator Instantiate()
	{
		while (true)
		{
			yield return new WaitForSeconds(this.timeToInstantiate);
			currentObstacle = Random.Range(0, this.obstacles.Length-1);
			if(currentObstacle == 0)
			{
				pos = new Vector3(7,Random.Range(-2.4f, -1.8f),-1);
			}
			else if(currentObstacle == 1)
			{
				pos = new Vector3(6,-1.78f,-1);
			}
			else if(currentObstacle == 2)
			{
				pos = new Vector3(5.5f,Random.Range(0, 1),-1);
			}
			else if(currentObstacle == 2)
			{
				pos = new Vector3(5.5f,Random.Range(-2.16f, -1.7f),-1);
			}
			if (GameObject.Find ("Game Manager").GetComponent<GameManager> ().getStart())
			{
				Instantiate(obstacles[this.currentObstacle], pos, Quaternion.identity);
			}
		}
	}
}
