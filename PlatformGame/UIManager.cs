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
        eletronAtom.text = "����:" + item.electronQuantity + "\n" +
                            "����:" + item.atomQuantity;
    }
}
