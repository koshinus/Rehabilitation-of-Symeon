using UnityEngine;
using System.Collections;
 
public class StepByStepTextWriter : MonoBehaviour 
{
	public string text = "This text will shows step-by-step";
	
	bool showText = true;
	Rect textArea = new Rect(0,0,Screen.width, Screen.height);
 
	void OnGUI()
	{
		if(showText)
		{
            GUI.Label(textArea, text);
            /*
            for (int i = 0; i < text.Length; i++)
            {
                //Rect textArea = new Rect(0, 0, Screen.width, Screen.height);
                GUI.Label(textArea, text.Substring(0, i));
                //new WaitForSecondsRealtime(0.5f);
            }
            */
		}
	}
}