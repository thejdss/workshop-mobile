using UnityEngine.SceneManagement;
using UnityEngine;

// This methods will be used in Buttons on Menu and the Game Scene
public class ButtonFunctions : MonoBehaviour
{
	public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void GameTime(int time)
    {
        Time.timeScale = time;
    }
}
