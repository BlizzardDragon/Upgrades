using System;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class WorkDurationUpgradeTable
{
    [Space]
    [InfoBox("Duration: Linear Function")]
    [SerializeField]
    private float _startDuration;
    [SerializeField]
    private float _endDuration;
    [ReadOnly]
    [SerializeField]
    private float _stepDuration;

    [Space]
    [ListDrawerSettings(OnBeginListElementGUI = "DrawLevels")]
    // [ReadOnlyArray]
    [SerializeField]
    private float[] _levels;


    public float GetDuration(int level)
    {
        var index = level - 1;
        index = Mathf.Clamp(index, 0, _levels.Length - 1);
        return _levels[index];
    }

    private void DrawLevels(int index)
    {
        GUILayout.Space(8);
        GUILayout.Label($"Level #{index + 1}");
    }

    public void OnValidate(int maxLevel)
    {
        EvaluatebaseDurationTable(maxLevel);
    }

    private void EvaluatebaseDurationTable(int maxLevel)
    {
        var table = new float[maxLevel];
        table[0] = _startDuration;
        table[maxLevel - 1] = _endDuration;

        _stepDuration = (_startDuration - _endDuration) / (maxLevel - 1);
        _stepDuration = (float)Math.Round(_stepDuration, 2);

        for (var i = 1; i < maxLevel - 1; i++)
        {
            var duration = _startDuration - _stepDuration * i;
            table[i] = (float)Math.Round(duration, 2);
        }
        _levels = table;
    }
}
