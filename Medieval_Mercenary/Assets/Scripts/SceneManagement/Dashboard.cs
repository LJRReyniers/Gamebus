using System.Collections.Generic;
using UnityEngine;

public class Dashboard : MonoBehaviour
{
    //[SerializeField] private SceneController _sceneController;
    [SerializeField] private List<GameObject> levels = new List<GameObject>();

    private void Start()
    {
        //GlobalManager.Instance.SetRewardAmount("Level 1", 100);
        SetRewardText();
    }

    public void CharacterBuilder()
    {
        SceneController.Instance.loadScene(1);
        //_sceneController.loadScene(1);
    }

    private void SetRewardText()
    {
        foreach (var level in levels)
        {
            //GlobalManager.Instance.SetRewardAmount(level.name, 100);
            GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "$" + $"{GlobalManager.Instance.GetCurrentReward(level.name)}";
        }
    }

    public void Level1()
    {
        SceneController.Instance.loadScene(2);
        //_sceneController.loadScene(2);
    }

    //public void Level2() { }
}
