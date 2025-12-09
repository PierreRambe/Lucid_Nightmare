using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    [Header("Win Settings")]
    public int winScore = 250;              // Skor untuk menang
    public GameObject winPanel;             // Panel UI muncul saat menang
    public float restartDelay = 5f;         // Delay sebelum restart scene

    private bool hasWon = false;
    private float restartTimer = 0f;

    void Start()
    {
        if (winPanel != null)
            winPanel.SetActive(false);       // Sembunyikan panel awalnya
    }

    void Update()
    {
        // Cek tepat skor = winScore dan belum menang
        if (!hasWon && ScoreManager.score == winScore)
        {
            WinGame();
        }

        if (hasWon)
        {
            restartTimer += Time.unscaledDeltaTime; // freeze game tapi tetap hitung waktu
            if (restartTimer >= restartDelay)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    void WinGame()
    {
        hasWon = true;  // penting! hanya sekali
        if (winPanel != null)
            winPanel.SetActive(true);
        Time.timeScale = 0f; // freeze game
        Debug.Log("Player Wins!");
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}
