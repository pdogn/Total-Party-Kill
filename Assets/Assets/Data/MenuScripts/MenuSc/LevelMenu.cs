using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelMenu : MonoBehaviour
{
    //public Button[] buttons;

    public List<Button> buttons;

    //khoi tao lv 1
    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for(int i = 0; i < buttons.Count; i++)
        {
            buttons[i].interactable = false;
        }
        for(int i = 0; i< unlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }
    public void OpenLevel(int levelId)
    {
        SceneManager.LoadScene(levelId);
    }

    private void Reset()
    {
        this.ButtonsToArray();
    }

    //tim kiem cac button level va add vao trong list
    void ButtonsToArray()
    {
        GameObject btnP1 = GameObject.Find("Page 1");
        foreach(var btn in btnP1.GetComponentsInChildren<Button>())
        {
            buttons.Add(btn);
        }

        GameObject btnP2 = GameObject.Find("Page 2");
        foreach (var btn in btnP2.GetComponentsInChildren<Button>())
        {
            buttons.Add(btn);
        }

        GameObject btnP3 = GameObject.Find("Page 3");
        foreach (var btn in btnP3.GetComponentsInChildren<Button>())
        {
            buttons.Add(btn);
        }
    }
}
