using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]private Canvas gameOverCanvas;

    public SoundManager soundManager;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        soundManager = GetComponentInChildren<SoundManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOverCanvas.enabled = false;
        soundManager.StartMusic(Audios.initialMusic,false);
        StartCoroutine(WaitAndPlay());
    }

    IEnumerator WaitAndPlay() {

        yield return new WaitWhile(soundManager.IsMusicPlaying);

        soundManager.StartMusic(Audios.musicLoop, true);
    }

    public void OnGameOver(bool die) {
        gameOverCanvas.enabled = true;
    }
}
