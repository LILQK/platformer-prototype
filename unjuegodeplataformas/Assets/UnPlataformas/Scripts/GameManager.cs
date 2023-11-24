using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Canvas gameOverCanvas;
    [SerializeField] private Canvas restartButtonCanvas;
    [SerializeField] private Canvas winCanvas;

    [SerializeField] private Button restartButton;

    public SoundManager soundManager;

    private void Awake()
    {
        // Si ya existe una instancia de GameManager, se destruye la actual para evitar duplicados.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        soundManager = GetComponentInChildren<SoundManager>();
    }

    void Start()
    {
        gameOverCanvas.enabled = false;

        // Inicia la música inicial y luego reproduce en bucle otra pista.
        soundManager.StartMusic(Audios.initialMusic, false);
        StartCoroutine(WaitAndPlay());

        // Añade una acción al botón de reinicio para recargar la escena actual.
        restartButton.onClick.AddListener(delegate
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            SceneManager.SetActiveScene(SceneManager.GetActiveScene());
        });
    }

    // Corrutina que espera a que termine la música inicial y luego inicia el bucle de la siguiente.
    IEnumerator WaitAndPlay()
    {
        // Espera mientras la música esté sonando.
        yield return new WaitWhile(soundManager.IsMusicPlaying);

        // Inicia la música de bucle.
        soundManager.StartMusic(Audios.musicLoop, true);
    }

    public void OnGameOver(bool die)
    {
        // Activa el Canvas para reiniciar el juego.
        restartButtonCanvas.enabled = true;

        UIData.Instance.StopTimer();

        // Activa el Canvas correspondiente según si el jugador perdió o ganó.
        if (die)
        {
            gameOverCanvas.enabled = true;
        }
        else
        {
            winCanvas.enabled = true;
        }
    }
}
