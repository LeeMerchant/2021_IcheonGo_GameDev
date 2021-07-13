using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Unity.FPS.UI
{
    public class LoadSceneButton : MonoBehaviour
    {
        public string SceneName = "";

        public GameObject GM;

        void Start()
        {
            GM = GameObject.FindWithTag("GM");
        }

        void Update()
        {
            if (EventSystem.current.currentSelectedGameObject == gameObject
                && Input.GetButtonDown(GameConstants.k_ButtonNameSubmit))
            {
                LoadTargetScene();
            }
        }

        public void LoadTargetScene()
        {
            SceneManager.LoadScene(SceneName);
            
            if (SceneManager.GetActiveScene().name == "SecondaryScene")
            {
                DontDestroyOnLoad(GM);
            }
            else 
            {
                Destroy(GM);
            }
        }
    }
}