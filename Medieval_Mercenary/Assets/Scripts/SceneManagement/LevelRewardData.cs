using UnityEngine;

[System.Serializable]
public class LevelRewardData : MonoBehaviour
{
    public float baseReward;
    public int attempts;
    public float currentMultiplier;

    public LevelRewardData(float initialReward)
    {
        baseReward = initialReward;
        attempts = 0;
        currentMultiplier = 1f;
    }

    public float CalculateCurrentReward()
    {
        return Mathf.RoundToInt(baseReward * currentMultiplier);
    }
}
