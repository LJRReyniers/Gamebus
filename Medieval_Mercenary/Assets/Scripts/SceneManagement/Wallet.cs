using UnityEngine;

public class Wallet : MonoBehaviour
{
    public static Wallet Instance { get; private set; }
    [SerializeField] private float _walletContent = 0;
    [SerializeField] private float _gemAmount = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("Wallet initialized");
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            Debug.LogWarning("Duplicate Wallet destroyed");
        }
    }

    public void AddCoins(float amount)
    {
        _walletContent += amount;
    }

    public void AddGems(float amount)
    {
        _gemAmount += amount;
    }

    public void RemoveCoins(float amount)
    {
        if (_walletContent >= amount)
        {
            _walletContent -= amount;
        }
    }

    public void RemoveGems(float amount) 
    { 
        if (_gemAmount >= amount)
        {
            _gemAmount -= amount;
        }
    }

    public float GetCoinCount()
    {
        return _walletContent;
    }

    public float GetGemCount()
    {
        return _gemAmount;
    }
}
