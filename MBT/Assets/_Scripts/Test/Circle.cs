using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Circle : MonoBehaviour
{
	public Sprite[] Sprites;

	
	public int CircleIdentityNumber;
	[HideInInspector]
	public bool IsDone;

	private Image _childImg;
	private Image _baseImg;
	private Button _btn;
	private bool _isAnimationable;


	private void Awake()
    {
		_baseImg = GetComponent<Image>();
		_childImg = transform.GetChild(0).GetComponent<Image>();
		_btn = GetComponent<Button>();
		_btn.onClick.AddListener(TaskOnClick);
		
	}



	void TaskOnClick()
	{
		GameManager.Instance.UpdateTestView(CircleIdentityNumber, true);
		
	}


	public void InitialCondition(int identityNumber)
	{
		CircleIdentityNumber = identityNumber;
		_childImg.sprite = Sprites[2];
		_baseImg.sprite = null;
	}

	public void MakeActive()
	{
		_baseImg.sprite = Sprites[0];
		_childImg.sprite = Sprites[1];
		ActiveAnimation();
	}

	public void MakeDone()
	{
		StopAnimation();
		if (IsDone)
		{
			_baseImg.sprite = null;
			_childImg.sprite = Sprites[1];
		}
		else
		{
			_childImg.sprite = Sprites[2];
			_baseImg.sprite = null;
		}
		
	}

	public void MakeWrong()
	{
		_baseImg.sprite = null;
		_childImg.sprite = Sprites[3];

	}

	void ActiveAnimation()
	{
		_isAnimationable = true;
		StartCoroutine(AnimCircle());
	}

	IEnumerator AnimCircle()
	{
		if (_isAnimationable)
		{
			transform.DOScale(0.9f, 0.2f);
			yield return new WaitForSeconds(0.2f);
			transform.DOScale(1, 0.2f);
			yield return new WaitForSeconds(0.2f);
			StartCoroutine(AnimCircle());
		}		
	}

	public void StopAnimation()
	{
		_isAnimationable = false;
	}



}
