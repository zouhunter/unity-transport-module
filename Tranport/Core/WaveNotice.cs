using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

namespace Transporting
{
    public class WaveNotice : MonoBehaviour
    {
        [SerializeField]
        protected float time;
        protected Coroutine coroutine;
        [SerializeField]
        protected AnimationCurve animCurve;

        [SerializeField]
        protected Transform bodyTrans;
        [SerializeField]
        protected Transform targetTrans;

        [SerializeField, Range(-10, 10)]
        protected float rotateSpeed;

        protected Vector3 startPosition;
        protected Quaternion startRotation;
        protected Vector3 targetPosition;
        protected bool inited;
        protected bool active;
        protected bool reverse;

        protected virtual void OnEnable()
        {
            InitState();
            Play();
        }

        protected virtual void OnDisable()
        {
            StopAnim();
        }

        private void Play()
        {
            active = true;
            coroutine = StartCoroutine(PlayAnim());
        }

        protected virtual void StopAnim()
        {
            active = false;
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
                coroutine = null;
            }
        }

        protected float GetAnimValue(float value)
        {
            return animCurve.Evaluate(value);
        }

        protected void InitState()
        {
            if (!inited)
            {
                inited = true;
                startPosition = bodyTrans.localPosition;
                startRotation = bodyTrans.localRotation;

                targetPosition = bodyTrans.transform.parent.InverseTransformPoint(targetTrans.transform.position);
            }
        }

        protected IEnumerator PlayAnim()
        {
            while (active)
            {
                var startPos = reverse ? targetPosition : startPosition;
                var targetPos = reverse ? startPosition : targetPosition;

                var dir = targetPosition - startPosition;
                bodyTrans.localRotation = startRotation;
                var rot = Quaternion.AngleAxis(rotateSpeed, dir);
                for (float i = 0; i < time; i += Time.deltaTime)
                {
                    bodyTrans.localPosition = Vector3.Lerp(startPos, targetPos, GetAnimValue(i / time));
                    bodyTrans.localRotation = rot * bodyTrans.localRotation;
                    yield return null;
                }

                bodyTrans.localRotation = rot;
                reverse = !reverse;
            }

        }

    }
}