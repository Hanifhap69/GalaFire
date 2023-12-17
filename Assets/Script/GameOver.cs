using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public GameObject ui;

    public void Retry ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    
    }

    public void Menu ()
	{
		Debug.Log("Go to menu.");
	}

}
