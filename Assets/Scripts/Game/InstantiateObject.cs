using UnityEngine;
using System.Collections;

public class InstantiateObject : MonoBehaviour 
{
	public GameObject[] obstacles;

	void Start () 
	{
		StartCoroutine (Instancia ());
	}

	void Update () 
	{
	
	}

	IEnumerator Instancia()
	{
		while(true)
		{
			int w = Random.Range(2,5);
			yield return new WaitForSeconds(w);
			
			int r = Random.Range(1, 4);
			
			switch(r)
			{
			case 1:
				Instantiate(obstacles[0], new Vector3(5.5f, -2.2f, -1f), Quaternion.identity);
				print("1");
				break;
				
			case 2:
				Instantiate(obstacles[1], new Vector3(5.5f, -2, -1f), Quaternion.identity);
				print("2");
				break;
				
			case 3:
				Instantiate(obstacles[2], new Vector3(5.5f, 2f, -1f), Quaternion.identity);
				print("3");
				break;
				
			default:
				Instantiate(obstacles[0], new Vector3(5.5f, -2.2f, -1f), Quaternion.identity);
				print("4");
				break;
			}
		}
	}
}
