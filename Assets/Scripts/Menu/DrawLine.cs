using UnityEngine;
using System.Collections;

public class DrawLine : MonoBehaviour 
{
	Vector3 myPos;
	GameObject actualGO;
	float complement;
	
	//TrailRenderer trail;
	Texture actualTexture;
	
	void Start() 
	{
		//trail = new TrailRenderer();
		//actualTexture = (Texture)Resources.Load("Textures/Menu/texRed");
		//PlayerPrefs.DeleteKey("Color");
		//PlayerPrefs.DeleteAll ();
		if (!PlayerPrefs.HasKey ("Color"))
		{
			PlayerPrefs.SetString("Color", "Textures/Menu/texRed");
		}
		else
			actualTexture = (Texture)Resources.Load (PlayerPrefs.GetString("Color"));
	}
	
	void Update () 
	{
		print (actualTexture);
		GetMousePosition();
		this.complement += 0.000001f;
		
		if (Input.GetMouseButtonDown(0)) 
		{
			CreateLine();
		}
		
		else if (Input.GetMouseButton(0))
		{
			MoveLine();
			if(!GameObject.Find("SoundPencil").GetComponent<AudioSource>().isPlaying)
			{
				GameObject.Find("SoundPencil").GetComponent<AudioSource>().Play();
			}
		}
		
		else if (Input.GetMouseButtonUp(0))
		{
			actualGO = null;
		}
	}
	
	void GetMousePosition() 
	{
		myPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		myPos.z = -3;
	}
	
	void CreateLine() 
	{
		actualGO = new GameObject();
		actualGO.transform.position = myPos;
		actualGO.AddComponent<TrailRenderer>();
		
		//Criar um material toda vez q se instancia uma linha faz com que as linhas anteriores nao tenham as cores da atual
		actualGO.GetComponent<TrailRenderer>().material = new Material((Shader)Resources.Load("Shader/Shader"));
		actualGO.GetComponent<TrailRenderer>().material.mainTexture = actualTexture;
		//*****************************************************************************************************************
		actualGO.GetComponent<TrailRenderer>().startWidth = 0.2f;
		actualGO.GetComponent<TrailRenderer>().endWidth = 0.2f;
		actualGO.GetComponent<TrailRenderer> ().time = 600;
		actualGO.GetComponent<TrailRenderer>().autodestruct = true;
	}
	
	void MoveLine() 
	{
		//myPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		//myPos.z = -3;
		actualGO.transform.position = new Vector3(myPos.x, myPos.y, -3-complement);
	}
	
	//relacione este metodo com algum guibutton(ou sei la o q vc vai fazer) para trocar a cor(por meio de texturas)
	public void SetTexture(string t) 
	{
		actualTexture = (Texture)Resources.Load ("Textures/Menu/"+t);//(Texture)Resources.Load("Textures/Menu/"+t);
		GameObject.Find ("Pen").GetComponent<Pen>().SetFillTexture((Texture)Resources.Load ("Textures/Pen/fill_"+t));
		GameObject.Find ("Pen").GetComponent<Pen>().SetStrokeTexture((Texture)Resources.Load ("Textures/Pen/stroke_"+t));
		
		PlayerPrefs.SetString("Color", "Textures/Menu/"+t);
	}
}
