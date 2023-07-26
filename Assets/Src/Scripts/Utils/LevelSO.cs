using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace SCS {
    [CreateAssetMenu(menuName = "SCS/LevelOrder")]
    public class LevelSO : ScriptableObject {
        public Map[] maps;
        public Map[] excludeFromRepeat;
    }
}