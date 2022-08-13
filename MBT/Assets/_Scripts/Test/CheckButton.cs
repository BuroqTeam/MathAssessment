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
				Debug.Log(k); // Shu yerga keldim Test qil Play qilib keyin shu yerdan ishla
				obj.GetComponent<Pattern>().IsStatus = true;
			}
			k++;
		}
		if (m < TestManager.Instance.ActivePatterns.Count)
		{
			FindDesiredPattern(m);
		}
		else
		{
			Debug.Log("Salam " + m);
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
			}
		}
		GameManager.Instance.UpdateTestView(k, false);
		DeactiveCheckEvent.Raise();
	}


	



}
