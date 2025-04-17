using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ExitButton() {
        Application.Quit();
        Debug.Log("Game Closed");
    
    }

    public void StartGame() {
        // Espefica a cena a qual o jogo inicia.
        SceneManager.LoadScene("Tutorial");

    }
}
