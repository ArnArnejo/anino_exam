using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Item : MonoBehaviour
{
    public Image itemIcon;
    public int ID;

    public void InitItemIcon(IconData _data) {
        itemIcon.sprite = _data.sprite;
        ID = _data.ID;
    }

    public Sprite GetSprite() {
        return itemIcon.sprite;
    }
}
