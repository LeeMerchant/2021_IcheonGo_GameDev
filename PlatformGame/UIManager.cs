using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    int score;
    public Text eletronAtom;
    private UIManager()
    {
        
    }
    private void Update()
    {
        eletronAtom.text = "전자:" + item.electronQuantity + "\n" +
                            "원자:" + item.atomQuantity;
    }
}
