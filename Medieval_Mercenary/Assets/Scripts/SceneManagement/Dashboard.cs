using System.Collections.Generic;
using UnityEngine;

public class Dashboard : MonoBehaviour
{
    [SerializeField] private List<GameObject> levels = new List<GameObject>();

    private void Start()
    {
        SetRewardText();
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

    //public void Level2() { }
}
