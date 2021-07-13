using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    List<Item> itemDatabase = new List<Item>();
    private void Start()
    {
        ConstructItem(CSVReader.Read("아이템데이타"));
        for(int i = 0;i<itemDatabase.Count; i++)
        {
            Debug.Log(itemDatabase[i]);
        }
    }
    private void ConstructItem(List<Dictionary<string, object>> data)
    {
        for (int i = 0; i < data.Count; i++)
        {
            int id = (int)data[i]["아이디"];
            string name = (string)data[i]["이름"];
            itemDatabase.Add(new Item(id, name));
        }
    }
    public Item FindItemByID(int id)
    {
        for (int i = 0; i < itemDatabase.Count; i++)
        {
            if (itemDatabase[i].id == id)
            {
                return itemDatabase[i];
            }

        }
        return null;
    }
    public Item FindItemByName(string name)
    {
        for (int i = 0; i < itemDatabase.Count; i++)
        {
            if (itemDatabase[i].name.Equals(name))
            {
                return itemDatabase[i];
            }

        }
        return null;
    }
}
public class Item
{
    public int id { get; }
    public string name { get; }
    public int sub { get; }
    public int makeItem { get; }
    public Sprite sprite { get; }
    public int needToMake { get; }
    public int hasItem { set; get; }
    public Item(int id, string name)
    {
        this.id = id;
        this.name = name;
        needToMake = id;
        sprite = Resources.Load<Sprite>(name);
    }
    public Item()
    {

    }
    public override string ToString()
    {
        return "이름:" + name + " ID:" + id;
    }
}
public class Recipe{
    Dictionary<string, List<string>> recipe = new Dictionary<string, List<string>>();
    public Recipe(string makeItem,string needItem1,string needItem2)
    {
        recipe.Add(makeItem, new List<string>() { needItem1, needItem2 });
    }
/*    public bool canMake(int item1,int item2)
    {
        for(int i = 0; i < recipe.Count; i++)
        {
            if(recipe[])
        }
    }*/
}