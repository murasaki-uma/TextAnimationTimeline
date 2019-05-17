using UnityEngine;
using UnityEditor;
using TMPro;
namespace TextAnimationTimeline
{
   
    [CreateAssetMenu(menuName = "TextAnimationTimeline/Create AnimationCurveAssets Instance")]
    public class AnimationCurveAsset:ScriptableObject
    {
        public AnimationCurve BasicIn;
        public AnimationCurve BasicOut;
        public AnimationCurve BasicInOut;
        public AnimationCurve SteepIn;
        public AnimationCurve Flow;
        public AnimationCurve FlowInOut;
        public AnimationCurve SlowMo;

    }
}