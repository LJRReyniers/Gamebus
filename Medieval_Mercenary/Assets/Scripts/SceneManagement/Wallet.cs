using UnityEngine;

public class Wallet : MonoBehaviour
{
    public static Wallet Instance { get; private set; }
    [SerializeField] private float _walletContent = 0;

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

    public void RemoveCoins(float amount)
    {
        if (_walletContent >= amount)
        {
            _walletContent -= amount;
        }
    }

    public float GetCoinCount()
    {
        return _walletContent;
    }
}
