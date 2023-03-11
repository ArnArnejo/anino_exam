using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PayoutLinesManager : MonoBehaviour
{
    public List<Paylines> paylineItems = new List<Paylines>();
    public List<PayLineInfo> PayoutLineInfo = new List<PayLineInfo>();
    public PayoutLinePoints LeftPoints;
    public PayoutLinePoints RightPoints;


    private void Start()
    {
        InitPayoutLinesInfo();
    }
    public void CheckItems(List<int> _lines) {

        Paylines payoutResult = new Paylines();
        for (int i = 0; i < _lines.Count; i++)
        {
                //if (_lines[i] == GameManager.Instance.spinManager.reelsItem[i].items[i + 1].ID)
                //{

                //}
                //print("LINE ID: " + _lines[i]
                //    + "     reel Number: " + GameManager.Instance.spinManager.reelsItem[i]
                //    + "     reel Number ITEM: " + GameManager.Instance.spinManager.reelsItem[i].items[_lines[i] + 1].ID

                //    );
            payoutResult.Lines.Add(GameManager.Instance.spinManager.reelsItem[i].items[_lines[i] + 1].ID);
        }
        GameManager.Instance.PayoutResult.Add(payoutResult);
    }

    public void GetPayoutResult() {
        for (int i = 0; i < paylineItems.Count; i++)
        {
            CheckItems(paylineItems[i].Lines);
        }
        GetTotalPayouts();
    }

    public void GetTotalPayouts() {

        for (int i = 0; i < GameManager.Instance.symbolManager.symbolData.Count; i++)
        {
            for (int j = 0; j < GameManager.Instance.PayoutResult.Count; j++)
            {
                //if (GameManager.Instance.symbolManager.symbolData[i].name == GameManager.Instance.PayoutResult[j].Lines[i].ToString()) {

                //}
                CheckResults(GameManager.Instance.PayoutResult[j].Lines, GameManager.Instance.symbolManager.symbolData[i]);
            }
        }
        GameManager.Instance.CalculatePrize();
    }

    public void CheckResults(List<int> _lines, SymbolData _symbol) {
        int payoutCount = -1;
        for (int i = 0; i < _lines.Count; i++)
        {
            if (_symbol.id == _lines[i]) {
                payoutCount++;
            }
        }
        int totalPayout = 0;
        if (payoutCount >= 0) {
            totalPayout += payoutCount;
        }
        GameManager.Instance.TOTALPAYOUT += _symbol.payout[totalPayout];
        print(_symbol.payout[totalPayout] + "   "+ _symbol.name);
    }

    public void InitPayoutLinesInfo() {
        
        for (int i = 0; i < 20; i++)
        {
            PayLineInfo info = new PayLineInfo();
            for (int j = 0; j < 3; j++)
            {
                if (j == 0)
                    //PayoutLineInfo[i].points[0] = LeftPoints.Points[i];
                    info.points.Add(LeftPoints.Points[i]);


                else if (j == 2)
                    //PayoutLineInfo[i].points[6] = RightPoints.Points[i];
                    info.points.Add(RightPoints.Points[i]);
                else
                {
                    for (int k = 0; k < 5; k++)
                    {
                        //info.points[k + 1] = GameManager.Instance.spinManager.reelsItem[k].Points[paylineItems[i].Lines[k]];
                        info.points.Add(GameManager.Instance.spinManager.reelsItem[k].Points[paylineItems[i].Lines[k]]);
                    }
                }
            }
            PayoutLineInfo.Add(info);
        }
    }

    public void SetLineRender() {
        
    }

}

[Serializable]
public class Paylines {
    public List<int> Lines = new List<int>(5);
}
[Serializable]
public class PayLineInfo {
    public List<Transform> points = new List<Transform>();
}
