using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void SceneSelect(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
