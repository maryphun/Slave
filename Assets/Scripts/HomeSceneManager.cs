using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        void OnClickConfirm()
        {
            Debug.Log("Clicked Confirm");
        }
        void OnClickCancel()
        {
            Debug.Log("Clicked Cancel");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            CommonPopup.Instance.ForceClosePopup();

            CommonPopup.Instance.Open("标题！", "アルファプラス！\n wtf", null,
                new CommonPopUpButton("Confirm", OnClickConfirm, ButtonSoundType.Confirm));
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            CommonPopup.Instance.ForceClosePopup();

            CommonPopup.Instance.Open("标题！", "アルファプラス！\n wtf", null,
                new CommonPopUpButton("Confirm", OnClickConfirm, ButtonSoundType.Confirm),
                new CommonPopUpButton("Cancel", OnClickCancel, ButtonSoundType.Cancel));
        }
    }
}
