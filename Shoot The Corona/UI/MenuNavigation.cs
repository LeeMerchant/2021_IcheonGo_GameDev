﻿using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Unity.FPS.UI
{
    public class MenuNavigation : MonoBehaviour
    {
        public Selectable DefaultSelection;

        public GameObject EndGameFadeCanvas;
        public GameObject HUD;

        void Start()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            EventSystem.current.SetSelectedGameObject(null);

            EndGameFadeCanvas = GameObject.Find("EndGameFadeCanvas");
            HUD = GameObject.Find("HUD");

            EndGameFadeCanvas.GetComponent<Canvas>().enabled = false;
            HUD.GetComponent<Canvas>().enabled = false;
        }

        void Update()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        void LateUpdate()
        {
            if (EventSystem.current.currentSelectedGameObject == null)
            {
                if (Input.GetButtonDown(GameConstants.k_ButtonNameSubmit)
                    || Input.GetAxisRaw(GameConstants.k_AxisNameHorizontal) != 0
                    || Input.GetAxisRaw(GameConstants.k_AxisNameVertical) != 0)
                {
                    EventSystem.current.SetSelectedGameObject(DefaultSelection.gameObject);
                }
            }
        }
    }
}