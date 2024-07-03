using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TurnManager : MonoBehaviour
{
    public Character player;
    public Character enemy;
    public Text statusText;
    public Button attackButton;
    public Slider playerHealthBar;
    public Slider enemyHealthBar;
    private bool playerTurn = true;

    void Start()
    {
        attackButton.onClick.AddListener(OnAttackButtonClicked);
        UpdateStatusText();
        UpdateHealthBars();
    }

    void OnAttackButtonClicked()
    {
        if (!playerTurn)
        {
            enemy.Attack(player);
            playerTurn = true;
            UpdateStatusText();
            UpdateHealthBars();
            CheckGameOver();
        }
    }

    public void PlayerAttackWithCard(int damage)
    {
        enemy.TakeDamage(damage);
        playerTurn = false;
        UpdateStatusText();
        UpdateHealthBars();
        CheckGameOver();
    }

    public void PlayerAttackWithCards(Cards card)
    {
        if (playerTurn)
        {
            enemy.TakeDamage(card.damage);
            playerTurn = false;
            UpdateStatusText();
            UpdateHealthBars();
            CheckGameOver();
        }
    }

    void UpdateStatusText()
    {
        statusText.text = $"Player HP: {player.currentHealth} - Enemy HP: {enemy.currentHealth}\n" +
                          $"{(playerTurn ? "Player's Turn" : "Enemy's Turn")}";
    }

    void UpdateHealthBars()
    {
        playerHealthBar.value = (float)player.currentHealth / player.maxHealth;
        enemyHealthBar.value = (float)enemy.currentHealth / enemy.maxHealth;
    }

    void CheckGameOver()
    {
        if (player.currentHealth <= 0)
        {
            statusText.text = "Game Over! Enemy Wins!";
            attackButton.interactable = false;
        }
        else if (enemy.currentHealth <= 0)
        {
            statusText.text = "Game Over! Player Wins!";
            attackButton.interactable = false;
        }
    }

    public bool IsPlayerTurn()
    {
        return playerTurn;
    }
}
