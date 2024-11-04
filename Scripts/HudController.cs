using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudController : MonoBehaviour
{
    public TextMeshProUGUI healthText; 
    public TextMeshProUGUI scoreText; 
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI warningText;

    public int health = 100;
    public int score = 0;
    public int ammo = 30;

    void Start()
    {
        UpdateHUD();
        warningText.gameObject.SetActive(false);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        UpdateHUD();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateHUD();
    }

    public void UseAmmo(int amount)
    {
        ammo -= amount;
        UpdateHUD();
    }

    public void ShowWarning()
    {
        warningText.text = "EMPTY GUN (RELOAD)";
        warningText.gameObject.SetActive(true);
    }

    public void HideWarning()
    {
        warningText.gameObject.SetActive(false);
    }

    private void UpdateHUD()
    {
        healthText.text = "Health: " + health;
        scoreText.text = "Score: " + score;
        ammoText.text = "Ammo: " + ammo;
    }
}
