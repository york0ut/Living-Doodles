using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rastro : MonoBehaviour 
{
	Vector3 myPos;
	GameObject actualGO;
	
	List<GameObject> allObjects = new List<GameObject>();
	
	TrailRenderer trail = new TrailRenderer();
	Texture actualTexture;
	Pen pen;
	
	void Start() 
	{
		trail = new TrailRenderer();
		actualTexture = (Texture)Resources.Load((PlayerPrefs.HasKey("Color"))? ""+PlayerPrefs.GetString("Color") : "Textures/Menu/texBlack");
		pen = GameObject.Find("Pen").GetComponent<Pen>();
	}
	
	void Update () 
	{
		print (actualTexture);
		GetMousePosition();
		
		if (Input.GetMouseButtonDown(0) && pen.canDraw) 
		{
			CreateLine();
		}
		
		else if (Input.GetMouseButton(0)&& pen.canDraw)
		{
			MoveLine();
			if(!GameObject.Find("SoundPencil").GetComponent<AudioSource>().isPlaying)
			{
				GameObject.Find("SoundPencil").GetComponent<AudioSource>().Play();
			}
		}
		
		else if (Input.GetMouseButtonUp(0))
		{
			for(int i=0;i<allObjects.Count;i++)
			{
				GameObject gameAux = allObjects[i];
				allObjects.RemoveAt(i);
				Destroy(gameAux);
			}
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
		allObjects.Add((GameObject)actualGO);
		actualGO.transform.position = myPos;
		actualGO.AddComponent<TrailRenderer>();
		
		//Criar um material toda vez q se instancia uma linha faz com que as linhas anteriores nao tenham as cores da atual
		actualGO.GetComponent<TrailRenderer>().material = new Material((Shader)Resources.Load("Shader/Shader"));
		actualGO.GetComponent<TrailRenderer>().material.mainTexture = actualTexture;
		actualGO.GetComponent<TrailRenderer>().time = 10;
		//*****************************************************************************************************************
		actualGO.GetComponent<TrailRenderer>().startWidth = 0.07f;
		actualGO.GetComponent<TrailRenderer>().endWidth = 0.07f;
		actualGO.GetComponent<TrailRenderer>().autodestruct = true;
	}
	
	void MoveLine() 
	{
		//myPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		//myPos.z = -3;
		actualGO.transform.position = myPos;
	}
	
	//relacione este metodo com algum guibutton(ou sei la o q vc vai fazer) para trocar a cor(por meio de texturas)
	public void SetTexture(string t) 
	{
		actualTexture = (Texture)Resources.Load("Textures/Menu/"+t);
	}
}
