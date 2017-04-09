using UnityEngine;
using System.Collections;
 
public class StepByStepTextWriter : MonoBehaviour 
{
	public string text = "This text will shows step-by-step";
	
	bool showText = true;
	Rect textArea = new Rect(0,0,Screen.width, Screen.height);
 
	void OnGUI()
	{
		GUI.Label(textArea, text);
	}
}