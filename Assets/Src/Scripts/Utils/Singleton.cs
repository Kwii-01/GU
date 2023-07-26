using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace SCS {
    public class Singleton<T> : SCBehaviour where T : Object {
        public static T Instance { get; private set; } = null;

        protected virtual void Awake() {
            if (Instance == null) {
                Instance = this as T;
            } else {
                Destroy(this.gameObject);
            }
        }
    }
}