using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class TurnManager : MonoBehaviour
{
    public SceneChanger sceneChanger;

    public Character player;
    public Character enemy;
    public Text statusText;
    public Slider playerHealthBar;
    public Slider enemyHealthBar;
    private bool playerTurn = true;
    int currentMana;
    int maxMana;
    public TextMeshProUGUI manaText;

    void Start()
    {
        currentMana = 3;
        maxMana = 3;
        UpdateStatusText();
        UpdateHealthBars();
        UpdateManaText();
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

    public void PlayerAttack(int damage)
    {
        enemy.TakeDamage(damage);
        UpdateStatusText();
        UpdateHealthBars();
        CheckGameOver();
    }

    public void PlayerHeal(int amount)
    {
        player.Heal(amount);
        UpdateStatusText();
        UpdateHealthBars();
        CheckGameOver();
    }

    public void PlayerDraw(int amount)
    {
        // Draw cards
        UpdateStatusText();
        UpdateHealthBars();
        CheckGameOver();
    }

    public void PlayerBlock(int amount)
    {
        // Block damage
        UpdateStatusText();
        UpdateHealthBars();
        CheckGameOver();
    }

    public void PlayerEndTurn()
    {
        playerTurn = false;
        currentMana = maxMana;
        UpdateManaText();
        Invoke("EnemyAttack", 1.0f);
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

    void UpdateManaText()
    {
        manaText.text = $"{currentMana}/{maxMana}";
    }

    public int GetCurrentMana()
    {
        return currentMana;
    }

    public void ReduceMana(int amount)
    {
        currentMana -= amount;
        UpdateManaText();
    }

    public void SetManaToMax()
    {
        currentMana = maxMana;
        UpdateManaText();
    }

    void CheckGameOver()
    {
        if (player.currentHealth <= 0)
        {
            statusText.text = "Game Over! Enemy Wins!";
            DisableCards();
            Invoke("ReturnToMapScene", 3.0f);
        }
        else if (enemy.currentHealth <= 0)
        {
            statusText.text = "Game Over! Player Wins!";
            DisableCards();
            Invoke("ReturnToMapScene", 3.0f);
        }
    }

    void ReturnToMapScene()
    {
        sceneChanger.ChangeScene("MapScene");
    }


    void DisableCards()
    {
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
