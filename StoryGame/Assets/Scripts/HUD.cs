using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private Story story;
    [SerializeField] private GameObject storyObj;

    [SerializeField] private ButtonManager backButton;
    [SerializeField] private GameObject backButtonObj;
    [SerializeField] private Timer timer;
    [SerializeField] private Popup popup;
    [SerializeField] private bool showPopups;
    [SerializeField] private TextMeshProUGUI optionsText;
    [SerializeField] private GameObject optionGroup;
    [SerializeField] private List<GameObject> options;
    [SerializeField] private bool singleOption;

    [SerializeField] private BackgroundManager bgManager;

    private void Awake()
    {
        for (int i = 0; i < optionGroup.transform.childCount; i++)
        {
            GameObject g = optionGroup.transform.GetChild(i).gameObject;
            if (g.CompareTag("Option"))
            {
                options.Add(g);

            }
        }

        SetOptionsInactive();

        if (storyObj != null)
        {
            story = storyObj.GetComponent<Story>();
        }
    }

    void Update()
    {
        if (timer.IsTimerDone())
        {
            timer.SetTimerDone(false);
            popup.showTimeIsUp();
        }
    }

    public void ShowOptions()
    {
        optionGroup.SetActive(true);
        optionsText.gameObject.SetActive(true);
        if (singleOption)
        {
            SetSingleActive(true);
        }
        else
        {
            SetMultiActive(true);
        }
    }

    public void SetOptionsInactive()
    {
        for (int i = 0; i < options.Count; i++)
        {
            {
                options[i].SetActive(false);
            }
        }
        optionsText.gameObject.SetActive(false);
    }

    private void SetSingleActive(bool b)
    {
        options[2].SetActive(b);
    }

    private void SetMultiActive(bool b)
    {
        options[0].SetActive(b);
        options[1].SetActive(b);
    }

    public void SetOptionsLink(string s)
    {
        string str = s.Replace("[", "").Replace("]", "");
        if (str.Contains("@"))
        {
            popup.showGameEnd();
            //backButtonObj.SetActive(true);
            return;
        }
        if (str.Contains(','))
        {
            singleOption = false;
            var o = str.Split(",");
            options[int.Parse(o[0]) - 1].GetComponent<Option>().SetLink(o[1]);
            //Debug.Log(string.Format("Option message: {0}, number: {1}", o, options.IndexOf(o)));
        }
        else
        {
            singleOption = true;
            options[2].GetComponent<Option>().SetLink(str);

        }
    }

    public void SetBackground(string s)
    {
        string str = s.Replace("#", "");

        bgManager.ChangeBackground(int.Parse(str) - 1);
    }

    public void SetOptionsText(string s)
    {
        string str = s.Replace("{", "").Replace("}", "");

        if (str.Contains(','))
        {
            singleOption = false;
            var o = str.Split(",");

            options[int.Parse(o[0]) - 1].GetComponent<Option>().SetText(o[1]);
            //Debug.Log(string.Format("Option message: {0}, number: {1}", o, options.IndexOf(o)));
            //Debug.Log(string.Format("Option left: {0}, length: {1}, option right: {2}, length: {3}",
            //    o[0], o[0].Length, o[1], o[1].Length));
        }
        else
        {
            singleOption = true;
            options[2].GetComponent<Option>().SetText(str);
        }
    }

    public void SetStory(Dictionary<string, TextAsset> lang_dict)
    {
        story.SetDict(lang_dict);
    }

    public void ChangeStoryPath(string path)
    {
        SetStoryActive(true);
        Debug.Log(string.Format("Path: {0}, length: {1}", GameData.ConvertToHex(path), path.Length));

        story.LoadText(path);
    }

    public void ResetTimer()
    {
        timer.ResetTimer();
    }

    public void SetStoryActive(bool b)
    {
        story.gameObject.SetActive(b);
    }
}
