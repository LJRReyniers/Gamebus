using UnityEngine;

[System.Serializable]
public class Quest : MonoBehaviour
{
    public string title;
    public string description;
    public float reward;
    public bool completed;

    public Quest(string title, string description, float reward)
    {
        this.title = title;
        this.description = description;
        this.reward = reward;
        completed = false;
    }

    public bool GetState()
    {
        return completed;
    }
}
