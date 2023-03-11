using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Symbols : MonoBehaviour
{
    public List<Sprite> iconSymbol =  new List<Sprite>();
    public List<SymbolData> symbolData = new List<SymbolData>();
    public IconData GetSymbols() {
        IconData data = new IconData();
        int random = Random.Range(0, iconSymbol.Count);
        data.ID = random;
        data.sprite = iconSymbol[random];

        return data;
    }
}

[System.Serializable]
public class SymbolData {
    public int id;
    public string name;
    public List<int> payout = new List<int>();
}
[System.Serializable]
public class IconData {
    public Sprite sprite;
    public int ID;
}
