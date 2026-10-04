using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour
{
    [SerializeField] private Transition transitionObj;
    [SerializeField] public static Transition transition;

    [SerializeField] public static float letterDelay;

    [SerializeField] public static float textDelay;
    [SerializeField] public static string sceneName;

    public static Dictionary<string, List<string>> storiesFolder;

    public static List<Chapter> chapters;

    public static List<string> languageFolder;

    public static List<string> currentFolder;
    public static string currentLanguage = "en";

    private bool lPressed;
    private bool devPressed;
    public static bool devMode;

    void Start()
    {
        transition = transitionObj;
    }

    void Update()
    {
        Inputs();
        if (!SceneManager.GetActiveScene().name.Equals(sceneName))
        {
            sceneName = SceneManager.GetActiveScene().name;
        }
    }

    public static string ConvertToHex(string p)
    {
        byte[] ba = Encoding.Default.GetBytes(p);
        var hexString = BitConverter.ToString(ba);
        hexString = hexString.Replace("-", "");
        return hexString;
    }

    private void Inputs()
    {
        if (!devPressed && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.Space))
        {
            devPressed = true;
            devMode = !devMode;
            Debug.Log("Developer Mode: " + devMode);
        }
        if (devMode && !lPressed && Input.GetKeyDown(KeyCode.L))
        {
            lPressed = true;
            SceneManager.LoadScene("LevelSelection");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (devPressed)
        {
            devPressed = false;
        }

        if (lPressed)
        {
            lPressed = false;
        }
    }
}
