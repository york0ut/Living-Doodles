using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ranking : MonoBehaviour 
{
	List<string> names;
	List<float> scores; 
	
	void Start () 
	{
		this.scores = new List<float>();
		this.names = new List<string>();
		
		for(int i=1;i<=10;i++)
		{
			if(PlayerPrefs.HasKey("highScore"+i))
			{
				this.scores.Add(PlayerPrefs.GetFloat("highScore"+i));
				this.names.Add(PlayerPrefs.GetString("highString"+i));
			}
			else
			{
				PlayerPrefs.SetString("highString"+i, "COM");
				PlayerPrefs.SetFloat("highScore"+i, 0);
				this.scores.Add(PlayerPrefs.GetFloat("highScore"+i));
				this.names.Add(PlayerPrefs.GetString("highString"+i));
			}
		}
		
		if(PlayerPrefs.HasKey("lastName") && PlayerPrefs.HasKey("lastScore"))
		{
			if(PlayerPrefs.GetFloat("lastScore") > this.scores[9])
			{
				this.scores[9] = PlayerPrefs.GetFloat("lastScore");
				PlayerPrefs.SetFloat("highScore10", this.scores[9]);
				
				this.names[9] = PlayerPrefs.GetString("lastName");
				PlayerPrefs.SetString("highString10", this.names[9]);
			}
		}
		//		print ("nome: "+ PlayerPrefs.GetString("lastName"));
		Bubblesort();
	}
	
	void Update () 
	{
		Bubblesort ();
	}
	
	void Bubblesort()
	{
		for (int i=0;i<this.scores.Count;i++)
		{
			for (int j=0;j<this.scores.Count-1;j++) 
			{
				if(this.scores[j] < this.scores[j + 1]) 
				{
					float aux = this.scores[j + 1];
					this.scores[j + 1] = this.scores[j];
					this.scores[j] = aux;
					
					string auxString = this.names[j+1].ToString();
					this.names[j + 1] = this.names[j].ToString();
					this.names[j] = auxString.ToString();
				}
			}
		}
		
		for(int i=1;i<=10;i++)
		{
			PlayerPrefs.SetFloat("highScore"+i, this.scores[i-1]);
			PlayerPrefs.SetString("highString"+i, this.names[i-1]);
		}
	}
}
