using UnityEngine;

public class Player_Behavior : MonoBehaviour
{
    public Canvas hud;
    public Canvas hud_start;
    public Canvas hud_end;
    public bool isGameStarted = false;
    public bool isGameEnded = false;
    public RectTransform arrowUI;
    public GameObject path;
    public TMPro.TextMeshProUGUI timerText;
    public TMPro.TextMeshProUGUI endTimeText;
    public float timer = 0f;
    public float challengeTime = 0f;
    public InteractManager_Behavior interactManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialisation du jeu dans le menu de démarrage
        path.SetActive(false);
        arrowUI.gameObject.SetActive(false);
        hud.gameObject.SetActive(false);
        hud_end.gameObject.SetActive(false);
        ShowStartMenu();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timerText.text = "Time: " + timer.ToString("F2");

        // Vérifie si le jeu est terminé et que toutes les cibles ont été trouvées
        if ( !isGameEnded && interactManager.target_hit >= 5)
        {
            ShowEndMenu();
        }
    }

    // Démarre le jeu en mode sans aide
    public void StartGame_mode1()
    {
        isGameStarted = true;
        isGameEnded = false;

        Time.timeScale = 1f;

        hud_start.gameObject.SetActive(false);
        hud_end.gameObject.SetActive(false);
        hud.gameObject.SetActive(true);
        arrowUI.gameObject.SetActive(false);
        path.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Démarre le jeu en mode avec boussole
    public void StartGame_mode2()
    {
        isGameStarted = true;
        isGameEnded = false;

        Time.timeScale = 1f;

        hud_start.gameObject.SetActive(false);
        hud_end.gameObject.SetActive(false);
        hud.gameObject.SetActive(true);
        arrowUI.gameObject.SetActive(true);
        path.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Démarre le jeu en mode avec chemin
    public void StartGame_mode3()
    {
        isGameStarted = true;
        isGameEnded = false;

        Time.timeScale = 1f;

        hud_start.gameObject.SetActive(false);
        hud_end.gameObject.SetActive(false);
        hud.gameObject.SetActive(true);
        arrowUI.gameObject.SetActive(false);
        path.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ShowStartMenu()
    {
        isGameStarted = false;
        isGameEnded = false;

        Time.timeScale = 0f;

        hud_start.gameObject.SetActive(true);
        hud_end.gameObject.SetActive(false);
        hud.gameObject.SetActive(false);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ShowEndMenu()
    {
        isGameStarted = false;
        isGameEnded = true;

        Time.timeScale = 0f;

        hud_start.gameObject.SetActive(false);
        hud_end.gameObject.SetActive(true);
        hud.gameObject.SetActive(false);

        endTimeText.text = "Vous avez trouvé toutes les cibles en " + timer.ToString("F2") + " secondes !";
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void RestartGame()
    {
        path.SetActive(false);
        arrowUI.gameObject.SetActive(false);
        hud.gameObject.SetActive(false);
        hud_end.gameObject.SetActive(false);
        ShowStartMenu();
        timer = 0f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
