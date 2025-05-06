using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalManager : MonoBehaviour
{
    public static GlobalManager Instance { get; private set; }
    private float _rewardAmount;
    [SerializeField] private float _initialBaseReward = 100f;
    [SerializeField] private float _reductionPercentage = 20f;

    [SerializeField] private float _shopItemPrice = 100f;

    private Dictionary<string, LevelRewardData> rewards = new Dictionary<string, LevelRewardData>();
    private Dictionary<GameObject, ShopItem> items = new Dictionary<GameObject, ShopItem>();
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

    //Reward
    public float GetRewardAmount(string sceneName)
    {
        return _rewardAmount;
    }

    public void SetRewardAmount(string sceneName)
    {
        if (!rewards.ContainsKey(sceneName))
        {
            rewards.Add(sceneName, new LevelRewardData(_initialBaseReward));
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
            float reduction = _initialBaseReward * (_reductionPercentage / 100f);
            data.currentMultiplier = Mathf.Max(0f,
                1f - (reduction / _initialBaseReward));
        }
    }

    public bool HasAttemptedLevel(string sceneName)
    {
        return rewards.TryGetValue(sceneName, out LevelRewardData data) &&
               data.attempts > 0;
    }


    //Shop item
    public void SetItemPrice(GameObject item)
    {
        if (!items.ContainsKey(item))
        {
            Debug.Log("Adding item");
            items.Add(item, new ShopItem(_shopItemPrice));
        }
    }

    public bool GetCurrentItemState(GameObject item)
    {
        if (items.TryGetValue(item, out ShopItem data))
        {
            return data.GetItemState();
        }
        return false;
    }

    public void BuyShopItem(GameObject item)
    {
        if (items.TryGetValue(item, out ShopItem data))
        {
            if (Wallet.Instance.GetCoinCount() >= data.price)
            {
                Wallet.Instance.RemoveCoins(data.price);
                data.UnlockItem();
            }
        }
    }

    public float GetItemPrice(GameObject item)
    {
        if (items.TryGetValue(item, out ShopItem data))
        {
            return data.price;
        }
        return 0;
    }
}
