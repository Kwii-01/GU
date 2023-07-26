using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace SCS {
    public class SCBehaviour : MonoBehaviour {

        public virtual void Display() {
            this.gameObject.SetActive(true);
        }

        public virtual void Hide() {
            this.gameObject.SetActive(false);
        }

        public Coroutine InvokeRepeating(float time, float repeatRate, Action onComplete, bool realTime = false) {
            return this.StartCoroutine(this._InvokeRepeating(time, repeatRate, onComplete, realTime));
        }

        public Coroutine InvokeCallback(float time, Action onComplete, bool realTime = false) {
            return this.StartCoroutine(this._InvokeCallback(time, onComplete, realTime));
        }

        private IEnumerator _InvokeCallback(float time, Action onComplete, bool realTime) {
            if (realTime) {
                yield return new WaitForSecondsRealtime(time);
            } else {
                yield return new WaitForSeconds(time);
            }
            onComplete.Invoke();
        }

        private IEnumerator _InvokeRepeating(float time, float repeatRate, Action onComplete, bool realTime) {
            yield return this._InvokeCallback(time, onComplete, realTime);
            while (true) {
                yield return this._InvokeCallback(repeatRate, onComplete, realTime);
            }
        }
    }
}