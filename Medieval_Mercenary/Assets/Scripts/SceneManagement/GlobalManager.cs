using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalManager : MonoBehaviour
{
    public static GlobalManager Instance { get; private set; }
    private float _rewardAmount;
    [SerializeField] private float _initialBaseReward = 100f;
    [SerializeField] private float _reductionPercentage = 20f;

    [SerializeField] private float _shopItemPrice = 100f;
    [SerializeField] private float _shopItemGemPrice = 3f;

    private Dictionary<string, LevelRewardData> rewards = new Dictionary<string, LevelRewardData>();
    private Dictionary<string, ShopItem> items = new Dictionary<string, ShopItem>();
    private Dictionary<string, Quest> quests = new Dictionary<string, Quest>();

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

    public void AddAttempts(string sceneName)
    {
        if (rewards.TryGetValue(sceneName, out LevelRewardData data))
        {
            data.attempts++;
        }
    }

    public void LevelStateChange(string sceneName)
    {
        if (rewards.TryGetValue(sceneName, out LevelRewardData data))
        {
            data.wonLevel = true;
        }
    }

    public bool HasAttemptedLevel(string sceneName)
    {
        return rewards.TryGetValue(sceneName, out LevelRewardData data) &&
               data.attempts > 0;
    }

    public bool HasWonLevel(string sceneName)
    {
        return rewards.TryGetValue(sceneName, out LevelRewardData data) &&
               data.wonLevel;
    }


    //Shop item
    public void SetItemPrice(string itemName)
    {
        if (!items.ContainsKey(itemName))
        {
            //Debug.Log("Adding item");
            items.Add(itemName, new ShopItem(_shopItemPrice, _shopItemGemPrice));
        }
    }

    public bool GetCurrentItemState(string itemName)
    {
        if (items.TryGetValue(itemName, out ShopItem data))
        {
            return data.GetItemState();
        }
        return false;
    }

    public void BuyShopItemWithCoins(string itemName)
    {
        if (items.TryGetValue(itemName, out ShopItem data))
        {
            if (Wallet.Instance.GetCoinCount() >= data.price)
            {
                Wallet.Instance.RemoveCoins(data.price);
                data.UnlockItem();
            }
        }
    }

    public void BuyShopItemWithGems(string itemName)
    {
        if (items.TryGetValue(itemName, out ShopItem data))
        {
            if (Wallet.Instance.GetGemCount() >= data.gemPrice)
            {
                Wallet.Instance.RemoveGems(data.gemPrice);
                data.UnlockItem();
            }
        }
    }

    public float GetItemPrice(string itemName)
    {
        if (items.TryGetValue(itemName, out ShopItem data))
        {
            return data.price;
        }
        return 0;
    }

    public float GetItemGemPrice(string itemName)
    {
        if (items.TryGetValue(itemName, out ShopItem data))
        {
            return data.gemPrice;
        }
        return 0;
    }

    //Quests
    public void SetQuestInformationInDictionary(string questName, string title, string description, float reward)
    {
        if (!quests.ContainsKey(questName))
        {
            quests.Add(questName, new Quest(title, description, reward));
        }
    }

    public void ClearQuest(string questName)
    {
        if (quests.TryGetValue(questName, out Quest data))
        {
            data.completed = true;
            Wallet.Instance.AddGems(GetGemReward(questName));
        }
    }

    public float GetGemReward(string questName)
    {
        if (quests.TryGetValue(questName, out Quest data))
        {
            return data.reward;
        }
        return 0;
    }
}
