using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dashboard : MonoBehaviour
{
    [SerializeField] private List<GameObject> levels = new List<GameObject>();
    [SerializeField] private List<GameObject> _questsList = new List<GameObject>();
    [SerializeField] private GameObject _popupScreen;
    
    private void Start()
    {
        SetRewardText();
        SetLevelState();

        SetQuestInformation();
    }

    public void CharacterBuilder()
    {
        SceneController.Instance.loadScene(2);
    }

    public void DailyQuests()
    {
        _popupScreen.SetActive(true);
    }

    private void SetRewardText()
    {
        foreach (GameObject level in levels)
        {
            GlobalManager.Instance.SetRewardAmount(level.name);

            level.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = $"$ {GlobalManager.Instance.GetCurrentReward(level.name)}";
        }
    }

    public void Level1()
    {
        SceneController.Instance.loadScene(3);
    }

    public void Level2() 
    { 
        SceneController.Instance.loadScene(4);
    }

    //Levels

    public bool IsLevelUnlocked(GameObject level)
    {
        int _previousLevel = levels.IndexOf(level) - 1;

        if (GlobalManager.Instance.HasWonLevel(levels[_previousLevel].name))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SetLevelState()
    {
        foreach (GameObject level in levels)
        {
            if (level.name != "Level 1" && !IsLevelUnlocked(level))
            {
                foreach (var image in level.GetComponentsInChildren<Image>())
                {
                    image.color = Color.black;
                }
            }
            else
            {
                foreach (var image in level.GetComponentsInChildren<Image>())
                {
                    image.color = Color.white;
                }
            }
        }
    }

    public void CheckIfLevelIsUnlocked(GameObject level)
    {
        int _correctBuildIndex = levels.IndexOf(level) + 3;

        if (level.GetComponent<Image>().color == Color.white)
        {
            SceneController.Instance.loadScene(_correctBuildIndex);
        }
    }

    //Quests

    private void SetQuestInformation()
    {
        string t = "placeholder";
        string d = "placeholder";
        float r = 0f;

        foreach (GameObject quest in _questsList)
        {
            foreach (var textField in quest.GetComponentsInChildren<TMPro.TextMeshProUGUI>())
            {
                if (textField.name == "Title")
                {
                    t = textField.text;
                }
                if (textField.name == "Details")
                {
                    d = textField.text;
                }
                if (textField.name == "Reward")
                {
                    r = float.Parse(textField.text);
                }
            }
            GlobalManager.Instance.SetQuestInformationInDictionary(quest.name, t, d, r);
        }
    }

    public void QuestCleared(string questName)
    {
        GlobalManager.Instance.ClearQuest(questName);
    }
}
