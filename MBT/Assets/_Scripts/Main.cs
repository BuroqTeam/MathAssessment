using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public List<Button> SinfButtonGroup = new List<Button>();
    public GameObject UpdatePanel;


    private void Awake()
    {
        foreach (Button btn in SinfButtonGroup)
        {
            if (PlayerPrefs.HasKey(btn.name))
            {
                int val = PlayerPrefs.GetInt(btn.name);
                if (val.Equals(1))
                {
                    btn.interactable = true;
                    UpdatePanel.SetActive(false);
                }
                else
                {
                    btn.interactable = false;
                }
            }           
        }
        
    }


}
