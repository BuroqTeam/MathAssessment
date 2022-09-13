using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Extension;
using DG.Tweening;



public class UpdateAnim : MonoBehaviour
{
    
    public FlowerSO FlowerSO;
    public float WaitDuration;

    private List<Image> _LeafImages = new List<Image>();
    private bool _isDone = false;

    private void Start()
    {
        List<GameObject> list = transform.GetChild(0).transform.GetChild(0).transform.GetChildren();
        foreach (GameObject item in list)
        {
            _LeafImages.Add(item.GetComponent<Image>());
        }
        StartCoroutine(AnimateLeafs());

    }

   

    
    IEnumerator AnimateLeafs()
    {
        if (_isDone)
        {
            for (int i = 0; i < 10; i++)
            {
                _LeafImages[i].sprite = FlowerSO.LeafOn;
                _LeafImages[i].transform.DOScale(1.2f, 0.1f);                
            }
            yield return new WaitForSeconds(0.1f);
            for (int i = 0; i < 10; i++)
            {                
                _LeafImages[i].transform.DOScale(1, 0.1f);
            }
            yield return new WaitForSeconds(0.1f);
            TuronOff();
        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                _LeafImages[i].sprite = FlowerSO.LeafOn;
                _LeafImages[i].transform.DOScale(1.1f, 0.1f);
                yield return new WaitForSeconds(WaitDuration);
                _LeafImages[i].sprite = FlowerSO.LeafOff;
                _LeafImages[i].transform.DOScale(1, 0.1f);
                yield return new WaitForSeconds(WaitDuration);
            }            
            StartCoroutine(AnimateLeafs());
        }        
    }

    public void IsDoneUpdate(bool val)
    {
        _isDone = val;
    }

    public void TuronOff()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
        Logging.Log("Turn Off Loading.");
    }

}
