using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

public class Story : MonoBehaviour
{
    [Header("Text Animation")]
    [SerializeField] private float letterDelay;     //in seconds
    [SerializeField] private bool animatingText;

    [Header("Text/Story related")]
    [SerializeField] private string path;
    [SerializeField] private List<string> storyList;
    [SerializeField] private string storyText;
    [SerializeField] private TextMeshProUGUI outputText;
    private Dictionary<string, TextAsset> languageDict;


    [Header("Options")]
    [SerializeField] private List<GameObject> options;

    [SerializeField] private HUD hud;

    [Header("Unused yet")]
    [SerializeField] private int level;

    private void Awake()
    {
        options = GameObject.FindGameObjectsWithTag("Option").ToList();
        if (options != null && options.Count > 0)
        {
            for (int i = 0; i < options.Count; i++)
            {
                options[i].name = (i + 1).ToString();
            }
        }
    }

    void Start()
    {
        letterDelay = GameData.letterDelay;

        if (hud == null)
        {
            hud = transform.parent.GetComponent<HUD>();
        }

        if (path == null || path.Length == 0)
        {
            path = "room_night";
        }
        gameObject.SetActive(false);
    }

    public void SetDict(Dictionary<string, TextAsset> lang_dict)
    {
        languageDict = lang_dict;
        Debug.Log("Set Dict method:");
        Debug.Log(languageDict.Count);
        Debug.Log(path);
        Debug.Log("\n");

    }

    public void LoadText(string path)
    {
        //storyList = ReadFileToList(path);

        storyList = ReadFileToList2(path);

        storyText = ConvertLinesToText(storyList);

        Continue(path);
    }

    public void Continue(string s)
    {
        if (animatingText) return;

        StopAllCoroutines();

        outputText.text = "";

        if (storyText.Length > 0)
        {
            StartCoroutine(TypeSentence(storyText, outputText));
        }

        //Might be useful, check
        //string tempPath = path;

        //try
        //{
        //    path += "." + s;
        //    LoadText(path);

        //    StopAllCoroutines();
        //    StartCoroutine(TypeSentence(storyText, outputText));
        //}
        //catch (System.Exception ex)
        //{
        //    path = tempPath;
        //    Debug.Log(string.Format("<b>I'll let you continue, check code later!</b>\n<i>{0}</i>", ex.Message));
        //}
    }

    public IEnumerator TypeSentence(string sentence, TextMeshProUGUI output)
    {
        animatingText = true;
        string[] array = sentence.Split(' ');
        Debug.Log("Letter Delay in Story class: " + letterDelay);
        yield return new WaitForSeconds(letterDelay);
        //output.text = array[0];
        output.text = "" + sentence[0];

        //Debug.Log(string.Format("Sentence: {0}, amount of words: {1}", sentence, array.Length));

        for (int i = 1; i < sentence.Length; ++i)
        {
            yield return new WaitForSeconds(letterDelay);
            output.text += sentence[i];
        }
        animatingText = false;

        hud.ResetTimer();
    }

    private List<string> ReadFileToList(string path)
    {
        string file = "Assets/Resources/Stories/Chapter 1/Ro/" + path.ToLowerInvariant() + ".txt";

        if (!File.Exists(file.ToString())) throw new System.Exception(string.Format
            ("Path <b><color=#C20000>{0}</color></b> is missing.", file));

        //Read the text from directly from the test.txt file
        var lines = File.ReadAllLines(file);
        //var lines = File.ReadAllLines(file).Where(s => s != "");

        return new List<string>(lines);
    }

    private List<string> ReadFileToList2(string path)
    {
        path = path.ToLowerInvariant();
        List<string> temp = languageDict[path].text.Split("\n").ToList();
        if (temp != null)
        {
            Debug.Log(temp.Count);
        }
        return new List<string>(temp);
    }

    private string ConvertLinesToText(List<string> list)
    {
        string res = "";
        foreach (string s in list)
        {
            string t = s.Trim();
            if (t.Contains('{'))
            {
                hud.SetOptionsText(t);
            }
            else if (t.Contains('['))
            {
                hud.SetOptionsLink(t);
            }
            else if (t.Contains('#'))
            {
                hud.SetBackground(t);
            }
            else
            {
                res += t + "\n";
            }
        }
        return res;
    }

    //Method to check for special words and booleans to show options or not, etc
    private void CheckLines()
    {
        //showOptions = ;
    }
}
