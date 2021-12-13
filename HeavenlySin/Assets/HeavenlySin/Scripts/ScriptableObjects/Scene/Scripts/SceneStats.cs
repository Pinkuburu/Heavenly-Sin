using UnityEngine;

namespace HeavenlySin.Scene.Scripts
{
    [CreateAssetMenu(fileName = "New SceneStats", menuName = "ScriptableObjects/SceneStats")]
    public class SceneStats : ScriptableObject
    {
        public GameObject playerPos;
        public Scenes sceneIndex;
    }

    public enum Scenes
    {
        MAIN_MENU,
        SETTTINGS,
        OFFICE,
        OVERWORLD,
        TUTORIAL_MINDSCAPE,
        SPEAKEASY,
        LUST_DREAMSCAPE,
        LUST_CUTSCENE,
        OVERWORLD1,
        OVERWORLD2,
        CREDITS
    };
}