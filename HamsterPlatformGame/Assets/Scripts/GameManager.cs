using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance = null;				// Static instance of GameManager which allows it to be accessed by any other script.
	public static string CurrentLevelKey = "current_level_key";
	public static string LivesKey = "lives_key";
	private int lives;
	private int currentLevel;
	void Awake()
	{
		//Check if instance already exists
		if (instance == null)
		{
			//if not, set instance to this
			instance = this;
		}
		//If instance already exists and it's not this:
		else if (instance != this)
		{
			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy (gameObject);	
		}
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start ()
	{
		if (PlayerPrefs.HasKey (GameManager.CurrentLevelKey)) {
			currentLevel = PlayerPrefs.GetInt (GameManager.CurrentLevelKey);
		} else {
			currentLevel = 0;
			PlayerPrefs.SetInt(GameManager.CurrentLevelKey, currentLevel);
		}

		if (PlayerPrefs.HasKey (GameManager.LivesKey)) {
			lives = PlayerPrefs.GetInt (GameManager.LivesKey);
		} else {
			lives = 5;
			PlayerPrefs.SetInt(GameManager.LivesKey, lives);
		}
	}
		
	public void WinGame()
	{
		currentLevel += 1;
		PlayerPrefs.SetInt (CurrentLevelKey, currentLevel);
		SceneManager.LoadScene ("LevelsScene");
	}

	public void GameOver()
	{
		lives -= 1;
		PlayerPrefs.SetInt (LivesKey, lives);
		SceneManager.LoadScene ("LevelsScene");
	}
}
