using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace SCS {
    public class Cam : SCBehaviour {
        public Camera scCamera;
        protected void Awake() {
            Game.cam = this;
        }
    }
}