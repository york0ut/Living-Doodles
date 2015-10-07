using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateObject : MonoBehaviour {

	public GameObject summerObject, trampolineObject;
	private Pen pen;
    bool drawing = false;
    List<Vector3> mousePos;
    Vector3 m;//variavel usada para pegar a posição atual do mouse
    int highX, highY, lowX, lowY;
    int left, right, up, down;
    int circleMin, circleMax;

	// Use this for initialization
	void Start () 
    {
        mousePos = new List<Vector3>();
        circleMin = 2;
        circleMax = 9;
		pen = GameObject.Find("Pen").GetComponent<Pen>();

	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetMouseButton(0))
        {
            m = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.Add(m);
		//	pen.current -= 0.2f;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(MouseUp());
        }
	}

    void RecognizeExtremes() 
    {
        for (int i = 0; i < mousePos.Count; i++)
        {
            if (mousePos[i].x > mousePos[highX].x)
            {
                highX = i;
            }

            if (mousePos[i].x < mousePos[lowX].x)
            {
                lowX = i;
            }

            if (mousePos[i].y > mousePos[highY].y)
            {
                highY = i;
            }

            if (mousePos[i].y < mousePos[lowY].y)
            {
                lowY = i;
            }
            if (i % 3 == 0 && i != 0) 
            {
                DetectZoera(i);
            }
        }
    }

    void DetectZoera(int i) 
    {
        if (mousePos[i - 1].x < mousePos[i].x &&
            mousePos[i - 2].x < mousePos[i - 1].x /*&&
            mousePos[i - 3].x < mousePos[i - 2].x &&
            mousePos[i - 4].x < mousePos[i - 3].x &&
            mousePos[i - 5].x < mousePos[i - 4].x*/) 
        {
            right++;
        }

        else if (mousePos[i - 1].x > mousePos[i].x &&
            mousePos[i - 2].x > mousePos[i - 1].x &&
            mousePos[i - 3].x > mousePos[i - 2].x/*&&
            mousePos[i - 4].x > mousePos[i - 3].x &&
            mousePos[i - 5].x > mousePos[i - 4].x*/)
        {
            left++;
        }

        if (mousePos[i - 1].y < mousePos[i].y&&
            mousePos[i - 2].y < mousePos[i - 1].y &&
            mousePos[i - 3].y < mousePos[i - 2].y/* &&
            mousePos[i - 4].y < mousePos[i - 3].y &&
            mousePos[i - 5].y < mousePos[i - 4].y*/)
        {
            up++;
        }

        else if (mousePos[i - 1].y > mousePos[i].y &&
            mousePos[i - 2].y > mousePos[i - 1].y &&
            mousePos[i - 3].y > mousePos[i - 2].y /*&&
            mousePos[i - 4].y > mousePos[i - 3].y &&
            mousePos[i - 5].y > mousePos[i - 4].y*/)
        {
            down++;
        }

        Debug.Log("Right: " + right + " Up: " + up +" left: " + left + " down: "+ down);
    }

    void RecognizeForm() 
    {
		if(pen.canDraw)
		{
	        //reta
	        if (right > 0 && ((up > 0 && down == 0) || (down > 0 && up == 0)) && left ==0 )
	        {
	            Debug.Log("reta frente");
	            return;
	        }

	        else if (left > 0 && ((up > 0 && down == 0) || (down > 0 && up == 0)) && right == 0)
	        {
	            Debug.Log("reta tras");
	            return;
	        }

	        //parabola
	        if (right > 0 && up > 0 && down > 0 && left == 0) 
	        {
				InstantiateTrampoline();
	            Debug.Log("parabola frente");
	            return;
	        }

	        else if (left > 0 && up > 0 && down > 0 && right == 0)
	        {
				InstantiateTrampoline();
	            Debug.Log("parabola frente");
	            return;
	        }

	        //circulo
	        if ((right >= circleMin && up >= circleMin && down >= circleMin && left >= circleMin) &&
	            (right <= circleMax && up <= circleMax && down <= circleMax && left <= circleMax))
	        {
				if (GameObject.Find ("Game Manager").GetComponent<GameManager> ().getSummer().Equals(false))
				InstantiateSummer();

	            Debug.Log("circulo");
	            return;
	        }

	        Debug.Log("forma invalida");
		}
    }

    void ReloadVariables() 
    {
        right = 0;
        up = 0;
        left = 0;
        down = 0;

        highX = 0;
        highY = 0;
        lowX = 0;
        lowY = 0;
    }

	void InstantiateSummer()
	{		
		Vector3 mousePosition = Input.mousePosition;
		mousePosition.z = 2;

		GameObject.Find ("Game Manager").GetComponent<GameManager> ().setSummer (true);
		GameObject.Find("Tips").GetComponent<GUIText>().text = "";
		Instantiate(summerObject, Camera.main.ScreenToWorldPoint(mousePosition), Quaternion.identity);
		GameObject.Find("SoundSun").GetComponent<AudioSource>().Play();
	}

	void InstantiateTrampoline()
	{
		Vector3 mousePosition = Input.mousePosition;
		mousePosition.z = 2;

		//pen.current -= 5;
		Instantiate(trampolineObject, Camera.main.ScreenToWorldPoint(mousePosition), Quaternion.identity);
	}

    IEnumerator MouseUp() 
    {
        ReloadVariables();
        RecognizeExtremes();

        if (mousePos.Count > 0)
        {
            //Debug.Log("MaiorX: " + highX + " MenorX: " + lowX +" MaiorY: " + highY + " MenorY"+ lowY);
            if (mousePos.Count < 80 && mousePos.Count > 5)
                RecognizeForm();

            mousePos.Clear();
        }
        yield return new WaitForSeconds(0.3f);
    }
}
