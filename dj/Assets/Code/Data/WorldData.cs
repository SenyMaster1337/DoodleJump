using System;

namespace Code.Data
{
    [Serializable]
    public class WorldData
    {
        public ScoreData ScoreData;

        public WorldData()
        {
            ScoreData = new ScoreData();
        }
    }
}