using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    float value;

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void SairDoJogo()
    {
        Application.Quit();
    }
}
