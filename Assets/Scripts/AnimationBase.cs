using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace AnimationsHD
{
   public enum AnimeTypes
    {
        None,
        idle,
        run,
        attack,
        death

    }
    
    
    public class AnimationBase : MonoBehaviour
    {
        public Animator animator;
        public List<AnimatorSetup> animatorSetups;

        public void AnimeByTrigger(AnimeTypes at) // at ==> enum AnimeTypes
        {
            var setup = animatorSetups.Find(i => i.animeTypes == at);
            if (setup != null)
            {
                animator.SetTrigger(setup.trigger);
            }
        }
        
    }

    [System.Serializable]
    public class AnimatorSetup
    {
        public AnimeTypes animeTypes;
        public string trigger;
    }

}

