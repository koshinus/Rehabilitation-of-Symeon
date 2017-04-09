using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
 
public class History : MonoBehaviour 
{
	//public int num = 2;
	//public void StartGame() { Application.LoadLevel(num); }
	public void StartGame() { SceneManager.LoadScene("CharacterOverview"); }
	//public void ExitGame() { Application.Quit(); }
}