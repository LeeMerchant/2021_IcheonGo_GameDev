using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Button : MonoBehaviour
{
    GameObject enemy;
    GameObject player;
    UIManager ui;
    ItemData data;
    public GameObject tab;
    public Text tabName;
    public Image tabImage;
    public Text tabdescribe;
    public GameObject tabs;
    public GameObject guide;
    public Item nowItem;
    private void Start()
    {
        enemy = GameObject.Find("Enemy");
        player = GameObject.Find("Player");
        ui = UIManager.Instance;
        data = GameObject.Find("jectObject").GetComponent<ItemData>();
        guide.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            revivePlayer();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            guide.SetActive(!guide.active);
        }
    }
    public void reviveEnemy()
    {
        enemy.SetActive(true);
    }
    public void revivePlayer()
    {
        player.SetActive(true);
        enemy.SetActive(true);
        player.transform.position = new Vector3(-5 - 2, 0);
    }
    public void onTab()
    {
        string ButtonName = EventSystem.current.currentSelectedGameObject.name;
        nowItem = data.FindItemByName(ButtonName);
        tabImage.sprite = nowItem.sprite;
        tabdescribe.text = nowItem.name + "이다\n"+"아이템을 만드는 비용은 전자와 원자 각각 "+ nowItem.needToMake+"개 씩이다"+"\n가지고있는개수:"+nowItem.hasItem;
        tabName.text = nowItem.name;
        tab.SetActive(true);
        tabs.SetActive(true);
    }
    public void closeTab()
    {
        tab.SetActive(false);
        tabs.SetActive(false);
    }
    public void makeItem()
    {
        if(item.electronQuantity >= nowItem.needToMake && item.atomQuantity >= nowItem.needToMake)
        {
            item.electronQuantity -= nowItem.needToMake;
            item.atomQuantity -= nowItem.needToMake;
            nowItem.hasItem++;
            tabdescribe.text = nowItem.name + "이다\n" + "아이템을 만드는 비용은 전자와 원자 각각 " + nowItem.needToMake + "개 씩이다" + "\n가지고있는개수:" + nowItem.hasItem;
        }
    }
    public void addElectron()
    {
        item.electronQuantity++;
    }
    public void addAtom()
    {
        item.atomQuantity++;
    }
}
