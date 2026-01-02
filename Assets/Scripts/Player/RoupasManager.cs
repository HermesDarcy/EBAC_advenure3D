using UnityEngine;
using Play.HD.Singleton;
using System.Collections.Generic;
using System.Collections;


namespace Cloths
{
    
    public enum RoupasType
    {
        Normal,
        Speed,
        indestrut,
        Strong

    }
    
    
    
    
    public class RoupasManager : Singleton<RoupasManager>
    {
        public List<RoupasSetup> setupRoupas;

        public RoupasType type; 
        public roupasChange roupasChange;
        public RoupasSetup GetSetupRoupas( RoupasType roupasGet )
        {
            return setupRoupas.Find(i  => i.typeRoupas == roupasGet);
        }

        
        public void TrocaRoupa(RoupasType roupasType)
        {

            Texture2D text2d = setupRoupas.Find(i => i.typeRoupas == roupasType).texture;
            roupasChange.ChangeTexture(text2d);
        }
        [NaughtyAttributes.Button]
        public void novaRoupa()
        {
            TrocaRoupa(type);
        }


        public void TrocaRoupa(RoupasType roupasType, float duration)
        {
            Texture2D text2d = setupRoupas.Find(i => i.typeRoupas == roupasType).texture;
            roupasChange.ChangeTexture(text2d);
            StartCoroutine("NormalCloth", duration);
            
        }


        IEnumerator NormalCloth(float duration)
        {
            yield return new WaitForSeconds(duration);
            TrocaRoupa(RoupasType.Normal);
        }



    }

    [System.Serializable]
    public class RoupasSetup
    {
        public RoupasType typeRoupas;
        public Texture2D texture;
    }


}

