using UnityEngine;

public class P22_Button : MonoBehaviour
{
    public TEXDraw Answer;
    public Pattern_22 Pattern22;
    public void InputAnswer()
    {
        if (Answer.text.Length < 17)
        {
            Answer.text = Answer.text.Insert(Answer.text.Length, transform.GetChild(0).GetComponent<TEXDraw>().text);
            Pattern22.Check();
            Pattern22.AnswerDone();
        }
    }
    public void DeleteAnswer()
    {
        if (Answer.text.Length > 1)
        {
            Answer.text = Answer.text.Remove(Answer.text.Length - 1, 1);
            Pattern22.Check();
        }
        else if (Answer.text.Length == 1)
        {
            Answer.text = Answer.text.Remove(Answer.text.Length - 1, 1);
            Pattern22.Check();
            Pattern22.AnswerDone();
        }
        else
        {
            Pattern22.AnswerDone();
        }
    }
}
