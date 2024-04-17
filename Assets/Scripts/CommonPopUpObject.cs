using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using DG.Tweening;
using Paku.Extensions;

public class CommonPopUpObject : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text description;
    [SerializeField] private RectTransform panel;
    [SerializeField] private CanvasGroup canvasGrp;
    [SerializeField] private CommonPopUpButtons oneButtonParent;
    [SerializeField] private CommonPopUpButtons twoButtonParent;

    [Header("Debug")]
    [SerializeField] private Action onClose = null;


    private Vector2 DeltaSize = new Vector2(750f, 400f);

    public void Open(string title, string description, Action onClose = null)
    {
        this.title.text = title;
        this.description.text = description;
        this.onClose = onClose;

        PlayOpenAnimation();
    }

    public void Close()
    {
        this.onClose.NullSafeInvoke();
        PlayCloseAnimation();
    }

    private void PlayOpenAnimation()
    {
        const float animTime = 0.2f;

        this.canvasGrp.alpha = 0.0f;
        this.canvasGrp.interactable = false;
        this.canvasGrp.DOFade(1.0f, animTime).OnComplete(() => { canvasGrp.interactable = true; });

        this.panel.sizeDelta = new Vector2(DeltaSize.x, 10.0f);
        this.panel.DOSizeDelta(new Vector2(DeltaSize.x, DeltaSize.y), animTime, false).SetEase(Ease.Linear);
    }
    private void PlayCloseAnimation()
    {
        const float animTime = 0.2f;
        
        this.canvasGrp.interactable = false;
        this.canvasGrp.DOFade(0.0f, animTime * 0.5f);

        this.panel.DOSizeDelta(new Vector2(DeltaSize.x, 10.0f), animTime, false).SetEase(Ease.Linear);

        GameObject.Destroy(gameObject, animTime + Time.deltaTime);
    }

    public void SetupOneButton(CommonPopUpButton buttonInfo)
    {
        oneButtonParent.gameObject.SetActive(true);
        oneButtonParent.Buttons[0].transform.GetChild(0).GetComponent<TMP_Text>().text = buttonInfo.Text;
        oneButtonParent.Buttons[0].onClick.AddListener(() =>
        {
            buttonInfo.CallBack();
            Close();
        });
    }

    public void SetupTwoButton(CommonPopUpButton buttonInfoLeft, CommonPopUpButton buttonInfoRight)
    {
        twoButtonParent.gameObject.SetActive(true);
        twoButtonParent.Buttons[0].transform.GetChild(0).GetComponent<TMP_Text>().text = buttonInfoLeft.Text;
        twoButtonParent.Buttons[0].onClick.AddListener(() =>
        {
            buttonInfoLeft.CallBack();
            Close();
        });
        twoButtonParent.Buttons[1].transform.GetChild(0).GetComponent<TMP_Text>().text = buttonInfoRight.Text;
        twoButtonParent.Buttons[1].onClick.AddListener(() =>
        {
            buttonInfoRight.CallBack();
            Close();
        });
    }
}
