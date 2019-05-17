using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace TextAnimationTimeline
{
	public class TextAnimationControlClip : PlayableAsset
	{
		public TextAnimationControlBehaviour template;
		public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
		{
			var playable = ScriptPlayable<TextAnimationControlBehaviour>.Create(graph, template);
			return playable;
		}
		
	}
}