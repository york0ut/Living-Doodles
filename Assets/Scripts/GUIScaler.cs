using UnityEngine;
using System.Collections;

public class GUIScaler : MonoBehaviour
{
	public float scaleAdjust = 1.0f;
	private float scaleFix = 1.4f;
	
	private const float BASE_WIDTH = 800;
	private const float BASE_HEIGHT = 600;
	
	void Start()
	{
		float _baseHeightInverted = 1.0f/BASE_HEIGHT;
		float ratio = (Screen.height * _baseHeightInverted)*scaleFix*scaleAdjust;
		
		if (GetComponent<GUITexture>()!=null)
		{
			GUITexture _guiTextureRef = GetComponent<GUITexture>();
			_guiTextureRef.pixelInset = new Rect(_guiTextureRef.pixelInset.x* ratio, _guiTextureRef.pixelInset.y* ratio, _guiTextureRef.pixelInset.width * ratio, _guiTextureRef.pixelInset.height * ratio);
		}else{
			if (GetComponent<GUIText>()!=null)
			{
				GetComponent<GUIText>().pixelOffset = new Vector2(GetComponent<GUIText>().pixelOffset.x*ratio, GetComponent<GUIText>().pixelOffset.y*ratio);
				GetComponent<GUIText>().fontSize = (int)(GetComponent<GUIText>().fontSize*ratio);
			}
		}
	}

	void FixedUpdate()
	{
		Menu ();
	}

	void Menu()
	{
		if (Application.loadedLevelName.Equals("Menu"))
		{
			if (GameObject.Find("Menu").GetComponent<MenuManager>().getVisible())
				this.gameObject.GetComponent<GUIText>().enabled = true;
			else
				this.gameObject.GetComponent<GUIText>().enabled = false;
		}
	}
}