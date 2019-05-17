using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TextAnimationTimeline.Motions
{

  
    internal class RandomFadeInOut : MonoBehaviour
    {
        private float duration;
        private float delay;
        private AnimationCurve curve;
        private TextMeshPro mesh;
        public void Init(float duration, float delay, AnimationCurve curve)
        {
            this.duration = duration;
            this.delay = delay;
            this.curve = curve;
            mesh = GetComponent<TextMeshPro>();
//            mesh.alpha = 1f;
        }

        public void ProcessFrame(float time)
        {
            if (time > delay)
            {
                var threshold = Mathf.Clamp((time - delay) / duration, 0f, 1f);
//                Debug.Log(threshold);
                mesh.alpha = curve.Evaluate(threshold);
            }
        }
    }

    internal class RandomFlow : MonoBehaviour
    {
        private float duration;
        private float delay;
        private AnimationCurve curve;
        private TextMeshPro mesh;
        public float _startY = -3f;
        public float _finishY = 3f;

        private Vector3 _startPos;
        private Vector2 _finishPos;
        public void Init(float duration, float delay, AnimationCurve curve)
        {
            this.duration = duration;
            this.delay = delay;
            this.curve = curve;
            mesh = GetComponent<TextMeshPro>();
            _startPos = new Vector3(mesh.transform.localPosition.x, _startY, mesh.transform.localPosition.z);
            _finishPos = new Vector3(mesh.transform.localPosition.x, _finishY, mesh.transform.localPosition.z);
            mesh.transform.localPosition = _startPos;
        }

        public void ProcessFrame(float time)
        {
            if (time > delay)
            {
                var threshold = Mathf.Clamp((time - delay) / duration, 0f, 1f);
//                Debug.Log(threshold);
                if (threshold < 0.5f)
                {
                    mesh.transform.localPosition = Vector3.Lerp(_startPos,new Vector3(_startPos.x,0f,_startPos.z), curve.Evaluate(threshold/0.5f));    
                }
                else
                {
                    mesh.transform.localPosition = Vector3.Lerp(new Vector3(_startPos.x,0f,_startPos.z),_finishPos, curve.Evaluate((threshold-0.5f)/0.5f));  
                }
                
            }
        }
    }
    public class FlowUp : MotionTextElement
    {

        private float _offsetY = -2f;
        private List<RandomFadeInOut> _fadeins = new List<RandomFadeInOut>();
        private List<RandomFlow> _flows = new List<RandomFlow>();
        public override void Init(string word, double duration)
        {
            TextMeshElement = CreateTextMeshElement(word, Font, FontSize);
            TextMeshElement.MotionTextAlignmentOptions = MotionTextAlignmentOptions.MiddleCenter;
            TextMeshElement.Alpha = 0f;
            transform.localPosition = OffsetLocalPosition;

            foreach (var character in TextMeshElement.Children)
            {
                character.fontSize = Random.Range(FontSize * 0.5f, FontSize*0.9f);
                

                var flow = character.gameObject.AddComponent<RandomFlow>();

                var _delay = Random.Range(0f, 0.4f);
                var _duration = (1f - _delay)*Random.Range(1f,0.9f);
                _delay = _delay / 2f;
                
                var value = Random.Range(2f, 4f);
                flow._startY = -value;
                flow._finishY = value;
                flow.Init(_duration,_delay, AnimationCurveAsset.Flow);
                
                
                var fadein = character.gameObject.AddComponent<RandomFadeInOut>();
                fadein.Init(_duration, _delay, AnimationCurveAsset.BasicInOut);
                _fadeins.Add(fadein);
                _flows.Add(flow);
                
                character.transform.localEulerAngles = new Vector3(0f, Random.Range(-40f,40f), 0f);
              
            }
        }
        
        public override void ProcessFrame(double normalizedTime, double seconds)
        {
//            TextMeshElement.Alpha = AnimationCurveAsset.BasicInOut.Evaluate((float) normalizedTime);

            var warpedTime = AnimationCurveAsset.SlowMo.Evaluate((float)normalizedTime); 

            var fadeoutTime = 0.2f;
            var fadeoutDelay = 1f - fadeoutTime;
            var motionNormalizedTime = Mathf.Clamp((float) warpedTime / (float)fadeoutDelay, 0f, 1f);
            
            
            
            if (warpedTime < fadeoutDelay)
            {
                var count = 0;
                foreach (var character in TextMeshElement.Children)
                {
                    _fadeins[count].ProcessFrame(motionNormalizedTime);
                    _flows[count].ProcessFrame(motionNormalizedTime);
                    count++;
                }
            }

        }

    }
}