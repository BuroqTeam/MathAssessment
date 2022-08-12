using System.Collections;
using System.Collections.Generic;
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
		GameManager.Instance.UpdateTestView(GameManager.Instance.CurrentQuestionNumber+1, true);
		DeactiveCheckEvent.Raise();

	}


	



}
