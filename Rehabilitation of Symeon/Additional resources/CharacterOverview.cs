using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
 
public class CharacterOverview : MonoBehaviour 
{
	//public int num = 3;
	//public void StartGame() { Application.LoadLevel(num); }
	public void StartGame() { SceneManager.LoadScene("UselessTutorial"); }
	//public void ExitGame() { Application.Quit(); }
}