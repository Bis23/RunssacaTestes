using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public void loadBack() {
        SceneManager.LoadScene("MainMenu");
    }
}
