using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

namespace TextAnimationTimeline
{
	[System.Serializable]
	public class TextAnimationControlBehaviour : PlayableBehaviour
	{
		public int id;
		[HideInInspector]
		public bool isCreate = false;
		[HideInInspector]
		public MotionTextElement motionTextElement;

		public bool DestroyTextOnEnd = false;
		public AnimationType animationType;
		public TextSegmentationOptions textSegmentationOptions;
		public float fontSize = -1;
		public TMP_FontAsset overrideFont;
		public Vector3 offsetLocalPosition;
		public Vector3 offsetEulerAngles;
		public Vector3 offsetLocalScale;
//		public Vector3 StartPosition;
	}
	
	
	
}