using UnityEngine;
using System.Collections;

public class SpeedManager : MonoBehaviour 
{
    float speed;

	void Start () 
    {
        speed = 0.025f;
        StartCoroutine(AddSpeed());
	}

    IEnumerator AddSpeed() 
    {
        speed += 0.005f;
        Debug.Log(speed);
        yield return new WaitForSeconds(10);
        StartCoroutine(AddSpeed());
    }

    public float GetSpeed() 
    {
        return speed;
    }
}
