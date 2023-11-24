using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Singleton instance para controlar el acceso a las funcionalidades de GameManager.
    public static GameManager Instance;

    // Referencias a los Canvas utilizados para la UI del juego.
    [SerializeField] private Canvas gameOverCanvas;
    [SerializeField] private Canvas restartButtonCanvas;
    [SerializeField] private Canvas winCanvas;

    // Referencia al bot�n de reinicio.
    [SerializeField] private Button restartButton;

    // Gestor de sonido del juego.
    public SoundManager soundManager;

    // Awake se llama al instanciar el objeto y se asegura que solo haya una instancia de GameManager.
    private void Awake()
    {
        // Si ya existe una instancia de GameManager, se destruye la actual para evitar duplicados.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        // Asigna esta instancia como la instancia Singleton.
        Instance = this;
        // Obtiene la referencia al SoundManager que es un hijo de este GameObject.
        soundManager = GetComponentInChildren<SoundManager>();
    }

    // Start se llama antes de la primera actualizaci�n del frame.
    void Start()
    {
        // Inicializa los Canvas de la UI desactivados.
        gameOverCanvas.enabled = false;
        // Inicia la m�sica inicial y luego reproduce en bucle otra pista.
        soundManager.StartMusic(Audios.initialMusic, false);
        StartCoroutine(WaitAndPlay());

        // A�ade una acci�n al bot�n de reinicio para recargar la escena actual.
        restartButton.onClick.AddListener(delegate
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            SceneManager.SetActiveScene(SceneManager.GetActiveScene());
        });
    }

    // Corrutina que espera a que termine la m�sica inicial y luego inicia el bucle de la siguiente.
    IEnumerator WaitAndPlay()
    {
        // Espera mientras la m�sica est� sonando.
        yield return new WaitWhile(soundManager.IsMusicPlaying);

        // Inicia la m�sica de bucle.
        soundManager.StartMusic(Audios.musicLoop, true);
    }

    // Se llama para manejar los eventos de fin de juego, ya sea por derrota o victoria.
    public void OnGameOver(bool die)
    {
        // Activa el Canvas para reiniciar el juego.
        restartButtonCanvas.enabled = true;
        // Detiene el temporizador de la UI.
        UIData.Instance.StopTimer();

        // Activa el Canvas correspondiente seg�n si el jugador perdi� o gan�.
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
