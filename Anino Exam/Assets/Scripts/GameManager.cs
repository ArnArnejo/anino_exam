using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Symbols symbolManager;
    public SpinManager spinManager;
    public UIManager uiManager;
    public PayoutLinesManager payoutManager;

    public List<Paylines> PayoutResult = new List<Paylines>();

    public bool isSpinning;

    public int TOTALPAYOUT = 0;
    public float CalculatedPayout;

    public float spinSpeed;

    private void Awake()
    {
        Instance = this;
    }

    public void StopSpinning() {
        StartCoroutine(Stop());
    }

    IEnumerator Stop() {
        float rand = Random.Range(1f, 2f);
        yield return new WaitForSeconds(rand);
        for (int i = 0; i < spinManager.reelsItem.Count; i++)
        {
            spinManager.StopSpin();
        }
        uiManager.EnableSpinButton();
        spinManager.TestReelLines();
        
    }

    public void CalculatePrize() {
        CalculatedPayout = TOTALPAYOUT * uiManager.TotalBet;
        uiManager.Winnings.text = CalculatedPayout.ToString("n2");
        uiManager.winningPanelTextAmount.text = CalculatedPayout.ToString("n2");
        uiManager.WinningPanel.SetActive(true);
        uiManager.playerBal += CalculatedPayout;
    }
}
