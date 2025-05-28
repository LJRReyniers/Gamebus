using UnityEngine;

[System.Serializable]
public class LevelRewardData : MonoBehaviour
{
    public float baseReward;
    public int attempts;
    public float currentMultiplier;
    public bool wonLevel;

    public LevelRewardData(float initialReward)
    {
        baseReward = initialReward;
        attempts = 0;
        currentMultiplier = 1f;
        wonLevel = false;
    }

    public float CalculateCurrentReward()
    {
        return Mathf.RoundToInt(baseReward * currentMultiplier);
    }
}
