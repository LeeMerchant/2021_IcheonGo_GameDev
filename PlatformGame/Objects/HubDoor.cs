using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Gamekit2D
{
    public class HubDoor : MonoBehaviour, IDataPersister
    {
        public string[] requiredInventoryItemKeys;
        public Sprite[] unlockStateSprites;

        public DirectorTrigger keyDirectorTrigger;
        public InventoryController characterInventory;
        public UnityEvent onUnlocked;
        public DataSettings dataSettings;

        SpriteRenderer m_SpriteRenderer;
        ItemData data;
        Item require1;
        Item require2;
        [ContextMenu("Update State")]
        void CheckInventory()
        {
            var stateIndex = -1;
            foreach (var i in requiredInventoryItemKeys)
            {
                if (characterInventory.HasItem(i))
                {
                    stateIndex++;
                }
            }
            if (stateIndex >= 0)
            {
                keyDirectorTrigger.OverrideAlreadyTriggered(true);
                m_SpriteRenderer.sprite = unlockStateSprites[stateIndex];
                if (stateIndex == requiredInventoryItemKeys.Length - 1 && require1.hasItem >= 2 && require2.hasItem >= 1)
                {
                    Debug.Log("ddd");
                    onUnlocked.Invoke();

                }
            }
        }
        private void Start()
        {
            data = GameObject.Find("jectObject").GetComponent<ItemData>();
            require1 = data.FindItemByName("산소");
            require2 = data.FindItemByName("수소");
        }
        void OnEnable()
        {
            m_SpriteRenderer = GetComponent<SpriteRenderer>();
            characterInventory.OnInventoryLoaded += CheckInventory;
        }

        void Update()
        {
            CheckInventory();
        }

        public DataSettings GetDataSettings()
        {
            return dataSettings;
        }

        public void LoadData(Data data)
        {
            var d = data as Data<Sprite>;
            m_SpriteRenderer.sprite = d.value;
        }

        public Data SaveData()
        {
            return new Data<Sprite>(m_SpriteRenderer.sprite);
        }

        public void SetDataSettings(string dataTag, DataSettings.PersistenceType persistenceType)
        {
            dataSettings.dataTag = dataTag;
            dataSettings.persistenceType = persistenceType;
        }


    }
}