using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesMaintenerController : MonoBehaviour
{
    public AudioClip[] audioClips;
    private Dictionary<String, AudioSource> soundsObjects;
    private static ScenesMaintenerController instance;

    public static ScenesMaintenerController Instance
    {
        get => instance;
    }
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            inicializarAudios();
            DontDestroyOnLoad(this.gameObject);
        }
    }

    #region Gerenciador de sons do jogo

        public void playMainSound()
        {
            playSound("music2", true);
        }

        public void stopMainSound()
        {
            stopSound("music2");
        }

        public void playBubbleSound()
        {
            playSound("bubble sound", true);
        }

        public void stopBubbleSound()
        {
            stopSound("bubble sound");
        }

        #region Metodos genericos e auxiliares

            private void stopSound(String key)
            {
                soundsObjects[key].Stop();
            }

            private void playSound(String key, bool loop = false)
            {
                AudioSource sound = soundsObjects[key];
                if (!sound.isPlaying)
                {
                    sound.Play();
                    sound.loop = loop;
                }
            }

        #endregion
        

    #endregion
    

    

    private void inicializarAudios()
    {
        Debug.Log("passou aqui");
        soundsObjects = new Dictionary<string, AudioSource>();
        
        foreach (AudioClip sound in audioClips)
        {
            GameObject newGameObject = new GameObject();
            AudioSource audioSource = newGameObject.AddComponent<AudioSource>();
            audioSource.clip = sound;
            audioSource.name = sound.name;
            audioSource.transform.SetParent(transform);
            soundsObjects.Add(audioSource.name,audioSource);
        }
    }
}
