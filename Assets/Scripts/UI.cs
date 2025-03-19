using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] TMP_Text _endGameText;
    [SerializeField] TMP_Text _coinsText;
    [SerializeField] TMP_Text _timeText;
    
    private string _winMessage = "��� ������� �������!\n�� ��������!\n";
    private string _looseMessage = "����� �����!\n�� ���������!\n";
    private string _coinsTextCaption = "������� ��������: ";
    private string _timeTextCaption = "������� ��������: ";
    private float _timeToLoose;
    private float _coinsRemain;  

    public void RefreshData(int coinsRemain, float timeToLoose)
    {
        _coinsRemain = coinsRemain;
        _timeToLoose = timeToLoose;
    }

    public void GameOverShow(string ButtoonToRestart)
    {
        _endGameText.color = Color.red;
        _endGameText.text = _looseMessage + $"������� \n{ButtoonToRestart}\n ��� ����� ����";
        _endGameText.enabled = true;
    }

    internal void GameWinShow(string ButtoonToRestart)
    {
        _endGameText.color = Color.green;
        _endGameText.text = _winMessage + $"������� \n{ButtoonToRestart}\n ��� ����� ����";
        _endGameText.enabled = true;
    }

    private void Update()
    {
        _timeText.text = _timeTextCaption + _timeToLoose.ToString("0.0");
        _coinsText.text = _coinsTextCaption + _coinsRemain.ToString();
    }

    public void ResetGame()
    {
        _endGameText.enabled = false;
    }
}
