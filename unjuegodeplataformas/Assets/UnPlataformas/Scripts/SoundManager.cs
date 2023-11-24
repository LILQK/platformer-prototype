using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Serializable]
    public class SoundClip
    {
        public Audios audioType;
        public AudioClip clip;
    }

    [SerializeField]private AudioSource sfxSource;
    [SerializeField] private AudioSource musicSource;

    [SerializeField]
    private List<SoundClip> soundClips = new List<SoundClip>();

    public void PlaySound(Audios sound)
    {
        SoundClip clipToPlay = soundClips.Find(s => s.audioType == sound);
        if (clipToPlay != null)
        {
            sfxSource.PlayOneShot(clipToPlay.clip);
        }
        else
        {
            Debug.LogWarning("Sound not found: " + sound);
        }
    }

    public void StartMusic(Audios clip, bool loop) {
        
        if(musicSource.isPlaying)musicSource.Stop();

        SoundClip clipToPlay = soundClips.Find(s => s.audioType == clip);

        musicSource.clip = clipToPlay.clip;
        musicSource.loop = loop;
        musicSource.Play();

    }

    public void StopMusic() {
        musicSource.Stop();
    }

    public bool IsMusicPlaying() {
        return musicSource.isPlaying;
    }
}

public enum Audios
{
    playerHit,
    enemyHit,
    playerDie,
    enemyDie,
    initialMusic,
    musicLoop,
}
