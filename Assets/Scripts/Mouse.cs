using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour
{
    public Texture2D cursorImage;

    private int cursorWidth = 48;
    private int cursorHeight = 48;

    void Start()
    {
   		Cursor.visible = false;
	}

    void Update()
    {

    }

    void OnGUI()
    {
		GUI.DrawTexture(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y - (Screen.height*0.07f), cursorWidth, cursorHeight), cursorImage);
    }
}