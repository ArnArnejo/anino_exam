using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Button SpintBtn;
    public TextMeshProUGUI SpinBtnText;
    public TextMeshProUGUI playerBalance;
    public TextMeshProUGUI totalBet;
    public TextMeshProUGUI BetAmount;
    public TextMeshProUGUI Winnings;
    public GameObject WinningPanel;
    public TextMeshProUGUI winningPanelTextAmount;
    public Button closeBtn;

    public Button PlusBtn;
    public Button MinusButton;

    public float TotalBet;
    public float Bet;
    public float BetCost;
    public float Multiplyer;
    public float playerBal;

    private void Start()
    {
        SpintBtn.onClick.AddListener(StartSpin);
        PlusBtn.onClick.AddListener(AddBet);
        MinusButton.onClick.AddListener(MinuBet);
        closeBtn.onClick.AddListener(CloseWinningPanel);
        WinningPanel.SetActive(false);
        playerBalance.text = Constants.INITIALBALANCE.ToString("n2");
        playerBal = (float)Constants.INITIALBALANCE;
        Winnings.text = Constants.ZERO.ToString("n2");
        totalBet.text = Constants.ZERO.ToString("n2");
        BetAmount.text = Constants.ZERO.ToString("n2");
    }

    private void Update()
    {
        playerBalance.text = playerBal.ToString("n2");
    }

    private void StartSpin()
    {
        GameManager.Instance.PayoutResult.Clear();
        GameManager.Instance.TOTALPAYOUT = 0;
        GameManager.Instance.spinManager.StartSpin();
        Winnings.text = Constants.ZERO.ToString("n2");
        playerBal -= TotalBet;
        SpinBtnText.text = Constants.STOP;
        SpintBtn.onClick.RemoveAllListeners();
        SpintBtn.onClick.AddListener(StopSpin);

    }

    private void StopSpin() {
        SpintBtn.onClick.RemoveAllListeners();
        SpintBtn.onClick.AddListener(StartSpin);
        SpintBtn.interactable = false;
        GameManager.Instance.StopSpinning();
    }

    public void EnableSpinButton() {
        SpintBtn.interactable = true;
        SpinBtnText.text = Constants.SPIN;
    }

    public void AddBet() {
        float tempTotal = (Bet + BetCost) * Multiplyer;

        if (tempTotal < playerBal) {
            Bet += BetCost;
            TotalBet = Bet * Multiplyer;
            totalBet.text = TotalBet.ToString("n2");
            BetAmount.text = Bet.ToString("n2");
        }
    }

    public void MinuBet()
    {
        if (Bet > 0) {
            Bet -= BetCost;
            TotalBet = Bet * Multiplyer;
            totalBet.text = TotalBet.ToString("n2");
            BetAmount.text = Bet.ToString("n2");
        }
    }

    public void CloseWinningPanel() {
        WinningPanel.SetActive(false);
        winningPanelTextAmount.text = Constants.ZERO.ToString("n2");
    }
}
