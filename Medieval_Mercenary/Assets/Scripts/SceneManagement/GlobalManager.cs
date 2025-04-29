using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalManager : MonoBehaviour
{
    public static GlobalManager Instance { get; private set; }
    private float _rewardAmount;
    [SerializeField] private float initialBaseReward = 100f;
    [SerializeField] private float reductionPercentage = 20f;

    private Dictionary<string, LevelRewardData> rewards = new Dictionary<string, LevelRewardData>();
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("GlobalManager initialized");
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            Debug.LogWarning("Duplicate GlobalManager destroyed");
        }
    }

    public float GetRewardAmount(string sceneName)
    {
        return _rewardAmount;
    }

    public void SetRewardAmount(string sceneName)
    {
        if (!rewards.ContainsKey(sceneName))
        {
            rewards.Add(sceneName, new LevelRewardData(initialBaseReward));
        }
    }

    public float GetMaxReward(string sceneName)
    {
        if (rewards.TryGetValue(sceneName, out LevelRewardData data))
        {
            return Mathf.RoundToInt(data.baseReward);
        }
        return 0;
    }

    public float GetCurrentReward(string sceneName)
    {
        if (rewards.TryGetValue(sceneName, out LevelRewardData data))
        {
            return data.CalculateCurrentReward();
        }
        return 0;
    }

    public void LessenReward(string sceneName)
    {
        if (rewards.TryGetValue(sceneName, out LevelRewardData data))
        {
            data.attempts++;
            float reduction = initialBaseReward * (reductionPercentage / 100f);
            data.currentMultiplier = Mathf.Max(0f,
                1f - (reduction / initialBaseReward));
        }
    }

    public bool HasAttemptedLevel(string sceneName)
    {
        return rewards.TryGetValue(sceneName, out LevelRewardData data) &&
               data.attempts > 0;
    }
}
