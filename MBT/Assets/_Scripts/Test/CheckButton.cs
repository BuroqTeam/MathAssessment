using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CheckButton : MonoBehaviour
{
	
	public GameEvent DeactiveCheckEvent;

    void Awake()
	{
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		GameManager.Instance.CurrentCircleObj.IsDone = true;
		if (TestManager.Instance.CheckIsLast())
		{
			FinishTask();
		}
		else
		{
			FindNextQuestion();
		}	
	}

	void FindNextQuestion()
	{
		int k = 0, m = 0;
		foreach (GameObject obj in TestManager.Instance.ActivePatterns)
		{
			if (obj.activeSelf)
			{
				m = k;
				obj.SetActive(false);
				obj.GetComponent<Pattern>().IsStatus = true;
				break;
			}
			k++;
		}
		if (m < TestManager.Instance.ActivePatterns.Count-1)
		{
			Debug.Log(m);
			FindDesiredPattern(m);
		}
		else
		{
			Debug.Log("Else: " + m);
			FindDesiredPattern(0);
		}		
	}

	void FindDesiredPattern(int index)
	{
		Debug.Log(index);
		int k = 0, n = 0;
		for (int i = index; i < TestManager.Instance.ActivePatterns.Count; i++)
		{
			if (!TestManager.Instance.ActivePatterns[i].GetComponent<Pattern>().IsStatus)
			{
				k = i;
				break;
			}
			else
			{
				n++;
			}
		}
		if (n.Equals(TestManager.Instance.ActivePatterns.Count - index))
		{
			FindDesiredPattern(0);
		}
		else
		{
			GameManager.Instance.UpdateTestView(k, false);
		}
		Debug.Log(k);
		
		DeactiveCheckEvent.Raise();
	}


	public void AnimateIt()
	{		
		StartCoroutine(AnimCheckButton());
	}

	IEnumerator AnimCheckButton()
	{
		transform.DOScale(0.9f, 0.2f);
		yield return new WaitForSeconds(0.2f);
		transform.DOScale(1, 0.2f);
		yield return new WaitForSeconds(0.2f);
		StartCoroutine(AnimCheckButton());
	}

	void FinishTask()
	{
		foreach (GameObject obj in TestManager.Instance.ActivePatterns)
		{
			if (obj.activeSelf)
			{				
				obj.SetActive(false);
				obj.GetComponent<Pattern>().IsStatus = true;
				break;
			}			
		}
		GameManager.Instance.CalculateResult();
		GameManager.Instance.FinishEvent.Invoke();
	}

}
