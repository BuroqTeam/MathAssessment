using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LoyihaIshi
{
    public class LoyihaSceneManager : MonoBehaviour
    {
        
        void Start()
        {

        }

        public void LoadSceneByName(string sceneName)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneName"></param>
        public void LoadSceneByScene(Scene sceneName)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName.ToString());
        }

    }
}
