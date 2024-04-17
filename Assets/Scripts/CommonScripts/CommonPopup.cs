using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CommonPopup : SingletonMonoBehaviour<CommonPopup>
{
    [Header("Debug")]
    [SerializeField] private GameObject popupObject;
    [SerializeField] private CommonPopUpObject popupObjectController;

    public bool IsShowPopup { get { return this.popupObject != null; } }

    // prefab path
    const string PopupPrefabPath = "Prefabs/CommonPopup";

    public void Open(string title, string description, Action onClose, CommonPopUpButton button)
    {
        popupObject = Instantiate(Resources.Load<GameObject>(PopupPrefabPath));
        popupObjectController = popupObject.GetComponent<CommonPopUpObject>();

        popupObjectController.Open(title, description, onClose);

        // setup buttons
        popupObjectController.SetupOneButton(button);
    }
    public void Open(string title, string description, Action onClose, CommonPopUpButton buttonLeft, CommonPopUpButton buttonRight)
    {
        popupObject = Instantiate(Resources.Load<GameObject>(PopupPrefabPath));
        popupObjectController = popupObject.GetComponent<CommonPopUpObject>();

        popupObjectController.Open(title, description, onClose);

        // setup buttons
        popupObjectController.SetupTwoButton(buttonLeft, buttonRight);
    }

    public void ForceClosePopup()
    {
        if (!IsShowPopup) return;

        popupObjectController.Close();
    }
}
