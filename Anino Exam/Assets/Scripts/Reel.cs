using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reel : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public bool isSpinning;
    public List<Transform> Points = new List<Transform>();
    private void Start()
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i].InitItemIcon(GameManager.Instance.symbolManager.GetSymbols());
        }
    }
    public void StartSpin(float _interval) {
        StartCoroutine(SpinReel(_interval));
    } 

    IEnumerator SpinReel(float _interval) {
        yield return new WaitForSeconds(_interval);
        //for (int i = 0; i < 500; i++)
        //{
        //    GameManager.Instance.spinManager.InitiateSpin(items);
        //    yield return new WaitForSeconds(GameManager.Instance.spinSpeed);
        //}
        while (isSpinning)
        {
            GameManager.Instance.spinManager.InitiateSpin(items);
            yield return new WaitForSeconds(GameManager.Instance.spinSpeed);
        }
    }


}
