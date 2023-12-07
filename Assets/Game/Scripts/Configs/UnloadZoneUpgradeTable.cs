using System;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class UnloadZoneUpgradeTable
{
    [Space]
    [InfoBox("Size: Linear Function")]
    [SerializeField]
    private int _startSize;
    [SerializeField]
    private int _endSize;
    [ReadOnly]
    [SerializeField]
    private float _stepSize;

    [Space]
    [ListDrawerSettings(OnBeginListElementGUI = "DrawLevels")]
    // [ReadOnlyArray]
    [SerializeField]
    private int[] _levels;


    public int GetMaxSize(int level)
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
        EvaluatebaseSizeTable(maxLevel);
    }

    private void EvaluatebaseSizeTable(int maxLevel)
    {
        var table = new int[maxLevel];
        table[0] = _startSize;
        table[maxLevel - 1] = _endSize;

        _stepSize = _endSize / (maxLevel - 1);
        _stepSize = (float)Math.Round(_stepSize, 2);

        for (var i = 1; i < maxLevel - 1; i++)
        {
            var size = _startSize + _stepSize * i;
            table[i] = (int)Math.Round(size, 2);
        }
        _levels = table;
    }
}
