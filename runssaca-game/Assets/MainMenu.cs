 using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ExitButton() {
        Application.Quit();
        Debug.Log("Game Closed");
    
    }

    public void loadTutorial() {
        // Carrega a cena que os parentesis especificam
        SceneManager.LoadScene("Tutorial");

    }

    public void StartGame() {
        // Carrega o Jogo (Especificar o nome)
        SceneManager.LoadScene("Game1");

    }
}
