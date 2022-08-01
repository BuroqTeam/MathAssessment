using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public List<Button> SinfButtonGroup = new List<Button>();
  


    private void Awake()
    {
        if (ES3.KeyExists("InitialSceneLoad1"))
        {
            if (ES3.Load<bool>("InitialSceneLoad1"))
            {
                foreach (Button btn in SinfButtonGroup)
                {
                    if (ES3.KeyExists(btn.name))
                    {
                        int val = ES3.Load<int>(btn.name);
                        if (val.Equals(1))
                        {
                            btn.interactable = true;
                            btn.gameObject.SetActive(true);
                        }
                        else
                        {
                            btn.interactable = false;
                        }
                        btn.gameObject.SetActive(ES3.Load<bool>(btn.name + "Visibility"));
                    }

                }
            }
        }
        
       

    }


}
