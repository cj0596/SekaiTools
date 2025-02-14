﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SekaiTools.Live2D;
using SekaiTools.Spine;

namespace SekaiTools.UI
{
    public class ConfigUIItem
    {
        public string itemName;
        public string itemGroup;

        public ConfigUIItem(string itemName, string itemGroup)
        {
            this.itemName = itemName;
            this.itemGroup = itemGroup;
        }
    }

    public abstract class ConfigUIItem_Void<T> : ConfigUIItem
    {
        public Func<T> getValue;
        public Action<T> setValue;

        public ConfigUIItem_Void(string itemName, string itemGroup, Func<T> getValue, Action<T> setValue) : base(itemName, itemGroup)
        {
            this.setValue = setValue;
            this.getValue = getValue;
        }
    }

    public class ConfigUIItem_Float : ConfigUIItem_Void<float>
    {
        public ConfigUIItem_Float(string itemName, string itemGroup, Func<float> getValue, Action<float> setValue) : base(itemName, itemGroup, getValue, setValue)
        {
        }
    }

    public class ConfigUIItem_String : ConfigUIItem_Void<string>
    {
        public ConfigUIItem_String(string itemName, string itemGroup, Func<string> getValue, Action<string> setValue) : base(itemName, itemGroup, getValue, setValue)
        {
        }
    }

    public class ConfigUIItem_Bool : ConfigUIItem_Void<bool>
    {
        public ConfigUIItem_Bool(string itemName, string itemGroup, Func<bool> getValue, Action<bool> setValue) : base(itemName, itemGroup, getValue, setValue)
        {
        }
    }

    public class ConfigUIItem_Select : ConfigUIItem_Void<int>
    {
        public string[] options;

        public ConfigUIItem_Select(string itemName, string itemGroup, string[] options, Func<int> getValue, Action<int> setValue) : base(itemName, itemGroup, getValue, setValue)
        {
            this.options = options;
        }
    }

    public class ConfigUIItem_AudioFile : ConfigUIItem
    {
        public Func<AudioClip> getValue;
        public Action<AudioData> setValue;

        public ConfigUIItem_AudioFile(string itemName, string itemGroup, Func<AudioClip> getValue, Action<AudioData> setValue) : base(itemName, itemGroup)
        {
            this.getValue = getValue;
            this.setValue = setValue;
        }
    }

    public class ConfigUIItem_Character : ConfigUIItem_Void<int>
    {
        public ConfigUIItem_Character(string itemName, string itemGroup, Func<int> getValue, Action<int> setValue) : base(itemName, itemGroup, getValue, setValue)
        {
        }
    }

    public class ConfigUIItem_Live2dAnimation : ConfigUIItem
    {
        public Func<L2DAnimationSet> getAnimationSet;
        public Func<string> getFacial;
        public Action<string> setFacial;
        public Func<string> getMotion;
        public Action<string> setMotion;

        public ConfigUIItem_Live2dAnimation(string itemName, string itemGroup, Func<L2DAnimationSet> getAnimationSet, Func<string> getFacial, Action<string> setFacial, Func<string> getMotion, Action<string> setMotion) : base(itemName, itemGroup)
        {
            this.getAnimationSet = getAnimationSet;
            this.getFacial = getFacial;
            this.setFacial = setFacial;
            this.getMotion = getMotion;
            this.setMotion = setMotion;
        }
    }

    public class ConfigUIItem_Live2dModel : ConfigUIItem_Void<SekaiLive2DModel>
    {
        public ConfigUIItem_Live2dModel(string itemName, string itemGroup, Func<SekaiLive2DModel> getValue, Action<SekaiLive2DModel> setValue) : base(itemName, itemGroup, getValue, setValue)
        {
        }
    }

    public class ConfigUIItem_HDRColor : ConfigUIItem_Void<Color>
    {
        public ConfigUIItem_HDRColor(string itemName, string itemGroup, Func<Color> getValue, Action<Color> setValue) : base(itemName, itemGroup, getValue, setValue)
        {
        }
    }

    public class ConfigUIItem_SpineScene : ConfigUIItem_Void<SpineScene>
    {
        public ConfigUIItem_SpineScene(string itemName, string itemGroup, Func<SpineScene> getValue, Action<SpineScene> setValue) : base(itemName, itemGroup, getValue, setValue)
        {
        }
    }

    public class ConfigUIItem_ResetSpineScene : ConfigUIItem
    {
        public Action resetScene;

        public ConfigUIItem_ResetSpineScene(string itemName, string itemGroup, Action resetScene) : base(itemName, itemGroup)
        {
            this.resetScene = resetScene;
        }
    }
}