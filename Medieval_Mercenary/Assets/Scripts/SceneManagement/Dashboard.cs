using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dashboard : MonoBehaviour
{
    [SerializeField] private List<GameObject> levels = new List<GameObject>();

    private void Start()
    {
        SetRewardText();
        //SetLevelState();
    }

    public void CharacterBuilder()
    {
        SceneController.Instance.loadScene(1);
    }

    private void SetRewardText()
    {
        foreach (var level in levels)
        {
            GlobalManager.Instance.SetRewardAmount(level.name);

            GetComponentInChildren<TMPro.TextMeshProUGUI>().text = $"$ {GlobalManager.Instance.GetCurrentReward(level.name)}";
        }
    }

    public void Level1()
    {
        SceneController.Instance.loadScene(2);
    }

    public void Level2() 
    { 
        SceneController.Instance.loadScene(3);
    }

    public bool IsLevelUnlocked(GameObject level)
    {
        int _previousLevel = levels.IndexOf(level) - 1;
        if (GlobalManager.Instance.HasAttemptedLevel(levels[_previousLevel].name))
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
        foreach (var level in levels)
        {
            if (level.name != "Level 1" && !IsLevelUnlocked(level))
            {
                level.GetComponent<Image>().color = Color.black;
                level.GetComponentInChildren<Image>().color = Color.black;
            }
            else
            {
                level.GetComponent<Image>().color = Color.white;
                level.GetComponentInChildren<Image>().color = Color.white;
            }
        }
    }

    public void CheckIfLevelIsUnlocked(GameObject level)
    {
        int _correctBuildIndex = levels.IndexOf(level) + 2;
        if (level.GetComponent<Image>().color == Color.white)
        {
            SceneController.Instance.loadScene(_correctBuildIndex);
        }
    }
}
