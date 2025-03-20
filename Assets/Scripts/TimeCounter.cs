using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    private float _timeMax;
    private float _timeToLoose;
    private bool _isWorking;

    public float TimeToLoose { get => _timeToLoose; }
    public bool IsOutOfTime { get; private set; }

    public void CountStart(int time)
    {
        _timeMax = time;
        _timeToLoose = _timeMax;
        IsOutOfTime = false;
        _isWorking = true;
    }

    public void CountStop()
    {
        _isWorking = false;
    }

    private void Update()
    {
        if (_isWorking & IsOutOfTime == false)
        {
            _timeToLoose -= Time.deltaTime;

            if (_timeToLoose <= 0)
                IsOutOfTime = true;
        }
    }

}
