using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	GameObject scoreText;
	GameObject tips;
	float score, addSpeed, speed;
	string textScore;
	bool started, summer;
	int count;
	
	public void setStart(bool started)
	{
		this.started = started;
	}
	
	public void setSummer(bool summer)
	{
		this.summer = summer;
	}
	
	public bool getSummer()
	{
		return summer;
	}
	
	public bool getStart()
	{
		return started;
	}
	
	public float getCurrentSpeed()
	{
		return speed;
	}
	
	
	void Start () 
	{
		scoreText = GameObject.Find ("Score");
		score = 0;
		tips = GameObject.Find ("Tips");
	}
	
	void FixedUpdate () 
	{
		if (started)
		{
			score += 0.5f;
			textScore = score.ToString ();
			scoreText.GetComponent<GUIText> ().text = textScore+"m";
		}
		
		if (summer)
		{
			count = 0;
			
			if (GameObject.Find("SummerLight").GetComponent<Light>().intensity < 3.6f)
			{
				GameObject.Find("SummerLight").GetComponent<Light>().intensity += 0.1f;
			}			
		}
		else
		{
			count++;
			GameObject.Find("SummerLight").GetComponent<Light>().intensity = 0;
			
			if (count > 300 && count < 750)
			{
				tips.GetComponent<GUIText>().text = "It's so dark in here, isn't it?\n I really miss a sparkle of sunlight "; //It's so dark in here, isn't it? I really miss a sparkle of sunlight
			}
			else if (count > 750)
			{
				tips.GetComponent<GUIText>().text = "Do you remember the sun's shape??";// Do you remember the sun's shape?
			}
		}
		
		/*	addSpeed += 0.5f;

		if (addSpeed > 600)
		{
			speed += 0.005f;
			speed = 0;
		}
		*/
	}
	
	public void Lose() 
	{
		PlayerPrefs.SetFloat("lastScore", score);
		PlayerPrefs.SetString("lastName", PlayerPrefs.GetString("name"));
		Application.LoadLevel("Ranking");
	}
}
