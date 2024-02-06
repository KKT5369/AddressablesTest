using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.U2D;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        public SpriteAtlas GameItemAtlas { get; private set; }
        private event Action SceneInit;
        public void Init()
        {
            ResourceLoadManager.Instance.LoadAsset<SpriteAtlas>("GameItem",
                (handle => { GameItemAtlas = handle.Result as SpriteAtlas; }));
        }
        
    }
}
