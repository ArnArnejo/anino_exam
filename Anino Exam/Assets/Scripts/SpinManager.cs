using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpinManager : MonoBehaviour
{
    public List<Reel> reelsItem = new List<Reel>();
    float startingPoint;

    private void Start()
    {
        
    }

    public void StartSpin() {
        for (int i = 0; i < reelsItem.Count; i++)
        {
            reelsItem[i].isSpinning = true;
            reelsItem[i].StartSpin(startingPoint);
            startingPoint += 0.2f;

        }
        startingPoint = 0f;
    }

    public void StopSpin() {
        for (int i = 0; i < reelsItem.Count; i++)
        {
            reelsItem[i].isSpinning = false;
        }
        
    }

    public void InitiateSpin(List<Item> _item) {
        Item temp = _item[_item.Count - 1];
        for (int i = 0; i < _item.Count; i++)
        {
            Item temp2 = _item[i];
            //print(_item[i].gameObject.name + " : " + _item[i].gameObject.transform.position + "  " + temp.gameObject.name + " : " + temp.transform.position);
            //_item[i].gameObject.transform.position = temp.transform.position;
            //temp.transform.position = _item[i].gameObject.transform.position;
            Vector3 endValue = _item[i].gameObject.transform.localPosition;
            temp.transform.DOLocalMove(endValue, GameManager.Instance.spinSpeed);
            _item[i] = temp;
            temp = temp2;

        }
    }
    public void TestReelLines() {
        GameManager.Instance.payoutManager.GetPayoutResult();
    }

}
