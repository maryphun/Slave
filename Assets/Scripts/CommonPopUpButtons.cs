using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommonPopUpButtons : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private List<Button> buttons;

    public List<Button> Buttons { get { return buttons; } }
}
