using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
 
public class UselessTutorial : MonoBehaviour 
{
	//public int num = 4;
	//public void StartGame() { Application.LoadLevel(num); }
	public void StartGame() { SceneManager.LoadScene("firstScene"); }
	//public void ExitGame() { Application.Quit(); }
}