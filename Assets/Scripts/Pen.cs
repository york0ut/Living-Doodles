using UnityEngine;
using System.Collections;

public class Pen : MonoBehaviour 
{
	//texturePainted   = tinta
	//textureNoPainted = corpo
	public Texture fillTexture, strokeTexture;
	public float current;
	public bool canDraw;
	private Rect strokeRect;
	
	void Start ()
	{
		DontDestroyOnLoad(this.gameObject);
		Cursor.visible = false;
		current = 100;
		strokeRect = new Rect(60,14,strokeTexture.width/7.5f,strokeTexture.height/7.5f);
	}
	
	public void SetFillTexture(Texture t)
	{
		fillTexture = t;
	}
	
	public void SetStrokeTexture(Texture t)
	{
		strokeTexture = t;
	}
	
	void Update () 
	{
		if(current > 0.1f)
		{
			canDraw = true;
			if(current >= 100)
			{
				current = 100;
			}
		}
		else
		{
			canDraw = false;
			current = 0;
		}
		
		strokeRect.x =  Input.mousePosition.x;
		strokeRect.y = Screen.height - Input.mousePosition.y - (Screen.height*0.07f);
	}
	
	void OnGUI()
	{
		GUI.DrawTexture(strokeRect, strokeTexture);
		GUI.DrawTextureWithTexCoords(new Rect(strokeRect.x+16, strokeRect.y+2f, current/2.5f, 40), fillTexture, new Rect(0f, 0f, (float)current / 100, 1f));
	}
}