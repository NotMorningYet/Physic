using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    private float _timeMax;
    private float _timeToLoose;

    public float TimeToLoose { get => _timeToLoose; private set { } }
    public bool IsOutOfTime { get; private set; }

    public void CountStart(int time)
    {
        _timeMax = time;
        _timeToLoose = _timeMax;
        IsOutOfTime = false;
    }

    private void Update()
    {
        if (IsOutOfTime == false)
        {
            _timeToLoose -= Time.deltaTime;

            if (_timeToLoose <= 0)
                IsOutOfTime = true;
        }
    }
}
