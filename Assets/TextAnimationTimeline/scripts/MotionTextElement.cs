using System;
using System.Collections.Generic;
using System.Linq;
//using NUnit.Framework;
using TMPro;
using UnityEngine;
namespace TextAnimationTimeline
{
    
    
//    [MenuItem ("Assets/Change FrameRate")]

    public class MotionTextElement : MonoBehaviour
    {

        [ExecuteInEditMode]
        private TextMeshElement _textMeshElement;
        private TMP_FontAsset _font;
        private MotionTextAlignmentOptions _motionTextAlignmentOptions;
        private Vector3 _offsetEulerAngles;
        private Vector3 _offsetLocalScale;
        private Vector3 _offsetLocalPosition;
        private double _duration;
        private TextSegmentationOptions _textSegmentationOptions;
        private AnimationCurveAsset _animationCurvesAsset;
        private Transform _parent;
        private bool _debugMode;
        public int ID;
        

//        private FontAsset fontsAsset;
        public float FontSize;

        public TMP_FontAsset Font
        {
            get => _font;
            set => _font = value;
        }

        public AnimationCurveAsset AnimationCurveAsset
        {
            set => _animationCurvesAsset = value;
            get => _animationCurvesAsset;
        }

        public double Duration
        {
            get => _duration;
            set => _duration = value;
        }

        public Vector3 OffsetLocalPosition
        {
            get => _offsetLocalPosition;
            set => _offsetLocalPosition = value;
        }
        public Vector3 OffsetLocalScale
        {
            get => _offsetLocalScale;
            set => _offsetLocalScale = value;
        }
        
        public Vector3 OffsetEulerAngles
        {
            get => _offsetEulerAngles;
            set => _offsetEulerAngles = value;
        }

        public TextMeshElement TextMeshElement
        {
            get => _textMeshElement;
            set => _textMeshElement = value;
        }

        public MotionTextAlignmentOptions MotionTextAlignmentOptions
        {
            get => _motionTextAlignmentOptions;
            set => _motionTextAlignmentOptions = value;
        }

        public virtual void Init(string word, double duration)
        {
            
        }
       
        public virtual void ProcessFrame(double normalizedTime, double seconds)
        {
            
        }

        public Transform Parent
        {
            get => _parent;
            set => _parent = value;
        }

        public TextSegmentationOptions TextSegmentationOptions
        {
            get => _textSegmentationOptions;
            set => _textSegmentationOptions = value;
        }

        public TextMeshElement CreateTextMeshElement(string word, TMP_FontAsset font, float fontSize)
        {
            var go = new GameObject("textMeshElement");
            go.transform.SetParent(transform);
            go.transform.localPosition = Vector3.zero;
            go.transform.localEulerAngles = Vector3.zero;

            var textMeshElement = go.AddComponent<TextMeshElement>();
            textMeshElement.Init(word, font,fontSize,TextSegmentationOptions);
            return textMeshElement;   
        }

        public bool DebugMode
        {
            get => _debugMode;
            set => _debugMode = value;
        }

        public virtual void Remove()
        {
            if (DebugMode)
            {
                DestroyImmediate(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
           
        }
        
    }

    
   
}