using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace SCS {
    [DefaultExecutionOrder(-1)]
    public class Map : SCBehaviour {
        protected void Awake() {
            Game.map = this;
        }
    }
}