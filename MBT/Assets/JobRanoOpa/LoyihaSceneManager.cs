using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}
