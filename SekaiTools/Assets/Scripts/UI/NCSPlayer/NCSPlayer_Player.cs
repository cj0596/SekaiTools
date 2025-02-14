﻿using SekaiTools.UI.NCSEditor;
using SekaiTools.UI.NicknameCountShowcase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SekaiTools.UI.BackGround;
using SekaiTools.Count;
using SekaiTools.Live2D;

namespace SekaiTools.UI.NCSPlayer
{
    public class NCSPlayer_Player : NCSPlayerBase
    {
        public Window window;
        [Header("Components")]
        public RectTransform targetTransformScene;
        public RectTransform targetTransformTransition;
        [Header("Settings")]
        public float waitTimeSafe = .3f;


        public void Initialize(Settings settings)
        {
            countData = settings.countData;
            audioData = settings.audioData;
            live2DModels = settings.live2DModels;
            showcase = settings.showcase;
        }

        public void Play()
        {
            StopAllCoroutines();
            StartCoroutine(IPlay());
        }

        IEnumerator IPlay()
        {
            Transition.Transition currentTransition = null;
            for (int i = 0; i < showcase.scenes.Count; i++)
            {
                Count.Showcase.NicknameCountShowcase.Scene scene = showcase.scenes[i];

                #region playScene
                if (scene.changeBackGround)
                    BackGroundController.backGroundController.Load(scene.backGround);

                scene.InstantiateScene();
                scene.nCSScene.gameObject.SetActive(true);
                scene.nCSScene.Initialize(this);
                scene.nCSScene.Refresh();
                scene.nCSScene.transform.SetParent(targetTransformScene);
                scene.nCSScene.rectTransform.anchoredPosition = Vector2.zero;

                yield return new WaitForSeconds(scene.nCSScene.holdTime);
                #endregion
                if(i< showcase.scenes.Count-1&&showcase.scenes[i+1].useTransition)
                {
                    if(currentTransition!=null)
                    {
                        currentTransition.Abort();
                        Destroy(currentTransition.gameObject);
                    }
                    Count.Showcase.NicknameCountShowcase.Transition transitionData = showcase.scenes[i + 1].transition;
                    Transition.Transition transitionPrefab = GlobalData.globalData.transitionSet.GetValue(transitionData.type);
                    currentTransition = Instantiate(transitionPrefab, transform);
                    currentTransition.targetTransform = targetTransformTransition;
                    currentTransition.LoadSettings(transitionData.serialisedSettings);
                    yield return currentTransition.StartTransition(WaitCoroutine());
                    Destroy(scene.nCSScene.gameObject);
                }
            }
        }

        IEnumerator WaitCoroutine()
        {
            yield return new WaitForSeconds(waitTimeSafe);
        }

        public class Settings
        {
            public NicknameCountData countData;
            public Count.Showcase.NicknameCountShowcase showcase;
            public SekaiLive2DModel[] live2DModels;
            public AudioData audioData;
        }
    }
}