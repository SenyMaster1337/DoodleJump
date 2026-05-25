using Code.Gameplay.PlayerComponents.StartSpawnPoints;
using Code.StaticData.Game;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Editor
{
    [CustomEditor(typeof(GameStaticData))]
    public class GameStaticDataEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GameStaticData gameData = (GameStaticData)target;

            if (GUILayout.Button("Collect"))
            {
                gameData.StartSpawnPosition =
                    FindAnyObjectByType<StartSpawnPoint>().transform.position;

                gameData.SceneKey = SceneManager.GetActiveScene().name;
            }

            EditorUtility.SetDirty(target);
        }
    }
}