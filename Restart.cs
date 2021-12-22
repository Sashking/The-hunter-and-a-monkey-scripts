using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    // Funkce, která je přivázaná k tlačítku "Restartovat"
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Spustí znovu aktuální scénu
    }

    // Funkce, která je přivázaná k tlačítku "Opustit hru"
    public void ExitButton()
    {
        Application.Quit(); // Vypne aplikaci ¯\_(ツ)_/¯
    }
}
