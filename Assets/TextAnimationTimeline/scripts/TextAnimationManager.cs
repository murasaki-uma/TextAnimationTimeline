using System;
using System.Collections;
using System.Collections.Generic;
using TextAnimationTimeline.Motions;
//using NUnit.Framework;
using TMPro;
using UnityEngine;


namespace TextAnimationTimeline
{

    
    public class TextAnimationManager : MonoBehaviour
    {
        public AnimationCurveAsset AnimationCurves;
        public TMP_FontAsset BaseFont;
        public float BaseFontSize = 10;
        public GameObject ParentGameObject;
        public bool DebugMode = true;
        void Start()
        {
            Init();
        
            
        }

        void Init()
        {
            var go = new GameObject("init");
           
        }

        void Update()
        {
        }

        public void UpdateText(float curveValue)
        {
        }
        
        public MotionTextElement CreateMotionTextElement(string word, AnimationType animationType)
        {    
            var go = new GameObject(word);
            go.gameObject.name = "text: " + word;
            var parent = ParentGameObject != null ? ParentGameObject.transform : transform;
            go.transform.SetParent(parent);
            go.transform.localPosition = Vector3.zero;
            go.transform.localEulerAngles = Vector3.zero;
   
            var motion = SelectMotionType(animationType, go);
            return motion;   
        }


       


        private MotionTextElement SelectMotionType(AnimationType animationType, GameObject go)
        {
            MotionTextElement motion;
            switch (animationType)
            {
                    
                case AnimationType.BasicFadeInOut:
                    motion = go.AddComponent<BasicFadeInOut>();
                    break;
                
                case AnimationType.BasicGameTextBoxAnimation:
                    motion = go.AddComponent<BasicGameTextBoxAnimation>();
                    break;
                
                case AnimationType.FlowUp:
                    motion = go.AddComponent<FlowUp>();
                    break;
                
                default:
                    motion =go.AddComponent<BasicFadeInOut>();
                    break;
                    
            }

            
            motion.AnimationCurveAsset = AnimationCurves;
            
            
            
            return motion;
        }
    }
}