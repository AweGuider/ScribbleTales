using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioSource timer;
    [SerializeField] private AudioSource timerEnd;
    [SerializeField] private AudioSource menuBackground;
    //[SerializeField] public static AudioSource menuBG;
    [SerializeField] private AudioSource storyBackground;
    //[SerializeField] public static AudioSource storyBG;
    [SerializeField] private AudioSource button;

    [SerializeField] private bool menu;
    [SerializeField] private bool selection;
    [SerializeField] private bool story;
    private void Awake()
    {
    }

    private void Start()
    {
        //if (menu) DontDestroyOnLoad(transform.gameObject);
        if (menu || selection)
        {
            PlayMenuBackground();
            StopStoryBackground();
        }
        if (story)
        {
            PlayStoryBackground();
            StopMenuBackground();
        }
    }

    void Update()
    {

    }

    public void UpdateSounds()
    {
        timer.volume = PlayerPrefs.GetFloat("FX");
        timerEnd.volume = PlayerPrefs.GetFloat("FX");
        menuBackground.volume = PlayerPrefs.GetFloat("Background");
        //menuBG.volume = menuBackground.volume;
        storyBackground.volume = PlayerPrefs.GetFloat("Background");
        //storyBG.volume = storyBackground.volume;
        button.volume = PlayerPrefs.GetFloat("FX");
    }

    public void PlayTimer()
    {
        timer.Play();
        Debug.Log("Timer Played");
    }
    public void PlayTimerEnd()
    {
        timerEnd.Play();
        Debug.Log("Timer End Played");
    }
    public void PlayMenuBackground()
    {
        storyBackground.volume = PlayerPrefs.GetFloat("Background");

        if (menuBackground.isPlaying) return;

        menuBackground.Play();
        Debug.Log("Menu Played");
    }
    public void PlayStoryBackground()
    {
        storyBackground.volume = PlayerPrefs.GetFloat("Background");
        if (storyBackground.isPlaying) return;

        storyBackground.Play();
        Debug.Log("Story Played");
    }

    public void StopMenuBackground()
    {
        menuBackground.volume = 0;
        Debug.Log("Menu is playing: " + menuBackground.isPlaying);
        menuBackground.Stop();
        Debug.Log("Menu Stopped");
    }
    public void StopStoryBackground()
    {
        storyBackground.volume = 0;

        storyBackground.Stop();
        Debug.Log("Story Stopped");
    }
    public void PlayButton()
    {
        button.Play();
        Debug.Log("Button Played");
    }
}
