using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TurnManager : MonoBehaviour
{
    public Character player;
    public Character enemy;
    public Text statusText;
    public Slider playerHealthBar;
    public Slider enemyHealthBar;
    private bool playerTurn = true;

    void Start()
    {
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

            // Appeler l'attaque de l'ennemi après un court délai
            Invoke("EnemyAttack", 1.0f); // 1 seconde de délai pour simuler un temps de réflexion
        }
    }

    void EnemyAttack()
    {
        if (!playerTurn) // Assurez-vous que c'est le tour de l'ennemi
        {
            enemy.Attack(player);
            playerTurn = true;
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
            DisableCards();
        }
        else if (enemy.currentHealth <= 0)
        {
            statusText.text = "Game Over! Player Wins!";
            DisableCards();
        }
    }

    void DisableCards()
    {
        // Désactiver toutes les cartes pour empêcher de nouvelles actions
        var cards = FindObjectsOfType<Button>();
        foreach (var card in cards)
        {
            card.interactable = false;
        }
    }

    public bool IsPlayerTurn()
    {
        return playerTurn;
    }
}
