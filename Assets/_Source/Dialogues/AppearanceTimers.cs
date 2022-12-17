using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS.ScriptableObjects
{
    public class AppearanceTimers : MonoBehaviour
    {
        private static AppearanceTimers instance;
        public static AppearanceTimers Instance
        {
            get
            {
                if (instance == null)
                    instance = FindObjectOfType<AppearanceTimers>();
                return instance;
            }
        }
        public float TimeForCharacters;
        public float TimeForButtons;
    }
}
