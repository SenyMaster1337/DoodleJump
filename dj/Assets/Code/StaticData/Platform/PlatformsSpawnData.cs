using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.StaticData.Platform
{
    [Serializable]
    public class PlatformsSpawnData
    {
        [Header("Сетка")] 
        public int StartCount;
        public float StepY;

        [Header("Сетка колонок")] 
        public int ColumnsCount;
        public float ColumnSpacing;

        [Header("Количество очков для включения шанса пропуска спавна колонки по горизонтали")] 
        public float ScoreCountToComplication;

        [Header("Шансы")] 
        [Range(0f, 1f)] public float EmptyChance;
        public List<PlatformChanceData> PlatformChances;
    }
}