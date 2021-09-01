using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TankController))]
public class Player : MonoBehaviour
{
    [SerializeField] int _maxHealth = 3;
    [SerializeField] Text _currentTreasureAmount; 
    int _currentHealth;
    int _treasureAmount;
    int SetHealth;

    TankController _tankController;

    private void Awake()
    {
        _tankController = GetComponent<TankController>();
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void IncreaseHealth(int amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        Debug.Log("Player's health: " + _currentHealth);
    }

    public void DecreaseHealth(int amount)
    {
        _currentHealth -= amount;
        Debug.Log("Player's health: " + _currentHealth);
        if(_currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        gameObject.SetActive(false);
        //Play particles
        //Play sounds
    }

    public void IncreaseTreasure(int treasureIncrease)
    {
        _treasureAmount += treasureIncrease;
        _currentTreasureAmount.text = "Treasure: " + _treasureAmount.ToString();
        Debug.Log("Player's treasure: " + _treasureAmount);
    }

    
}
