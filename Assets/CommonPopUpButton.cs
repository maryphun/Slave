using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Paku.Extensions;

public enum ButtonSoundType
{
    None,
    Confirm,
    Cancel,
    Custom,
}

[Serializable]
public class CommonPopUpButton
{
    public string Text { get; private set; }
    public ButtonSoundType SoundType { get; set; }

    Action callBackAction = null;
    Action<object> callBackWithParameter = null;
    object buttonParam = null;
    string customSE = string.Empty;

    public CommonPopUpButton(
            string buttonText,
            Action buttonAction,
            ButtonSoundType type = ButtonSoundType.None)
    {
        this.Text = buttonText;
        this.callBackAction = buttonAction;
        this.SoundType = type;
    }

    public CommonPopUpButton(
            string buttonText,
            Action buttonAction,
            string customSE)
    {
        this.Text = buttonText;
        this.callBackAction = buttonAction;
        this.customSE = customSE;
        this.SoundType = ButtonSoundType.Custom;
    }

    public void CallBack()
    {
        PlaySound();
        if (buttonParam != null)
        {
            callBackWithParameter.NullSafeInvoke(buttonParam);
        }
        else
        {
            callBackAction.NullSafeInvoke();
        }
    }

    public void PlaySound()
    {
        switch (SoundType)
        {
            case ButtonSoundType.Confirm:
                AudioManager.Instance.PlaySFX(GlobalDefine.SEConfirm);
                break;
            case ButtonSoundType.Cancel:
                AudioManager.Instance.PlaySFX(GlobalDefine.SECancel);
                break;
            case ButtonSoundType.Custom:
                AudioManager.Instance.PlaySFX(customSE);
                break;
        }
    }
}
