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
		FindNextQuestion();
		
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
		if (m < TestManager.Instance.ActivePatterns.Count)
		{
			FindDesiredPattern(m);
		}
		else
		{
			
			FindDesiredPattern(0);
		}		
	}

	void FindDesiredPattern(int index)
	{		
		int k = 0;
		for (int i = index; i < TestManager.Instance.ActivePatterns.Count; i++)
		{
			if (!TestManager.Instance.ActivePatterns[i].GetComponent<Pattern>().IsStatus)
			{
				k = i;
				break;
			}
		}
		Debug.Log(k);
		GameManager.Instance.UpdateTestView(k, false);
		DeactiveCheckEvent.Raise();
	}


	



}
