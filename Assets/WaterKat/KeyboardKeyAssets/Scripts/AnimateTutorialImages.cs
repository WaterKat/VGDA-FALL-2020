using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WaterKat.TimeW;
using TMPro;

public class AnimateTutorialImages : MonoBehaviour
{
    public Color FlashColor1 = Color.white;
    public Color FlashColor2 = Color.cyan;

    [TextArea]
    public string DescriptiveText = "Walk...";
    public string SingleKeyText = "W";
    public string LongKeyText = "Shift";

    public GameObject DescriptiveDisplay;
    public GameObject SingleKeyDisplay;
    public GameObject LongKeyDisplay;
    public GameObject MouseDisplay;

    public bool DisplayDescriptiveText = true;

    public bool FlashSingleKey = false;
    public bool FlashLongKey = false;
    public bool FlashLeftClick = false;
    public bool FlashRightClick = false;
    public bool FlashMiddleClick = false;

    public TextMeshProUGUI SingleKeyTMPro;
    public TextMeshProUGUI LongKeyTMPro;

    public Image SingleKey;
    public Image LongKey;
    public Image LeftClick;
    public Image RightClick;
    public Image MiddleClick;

    public TextMeshProUGUI DescriptiveTMPro;

    public bool toggle = false;

    private void Start()
    {
//        newTicker.MaxTick = 1f;

        DescriptiveDisplay.SetActive(DisplayDescriptiveText);
        SingleKeyDisplay.SetActive(FlashSingleKey);
        LongKeyDisplay.SetActive(FlashLongKey);
        MouseDisplay.SetActive(FlashLeftClick|| FlashRightClick || FlashMiddleClick );
        LeftClick.enabled = false;
        RightClick.enabled = false;
        MiddleClick.enabled = false;

        SingleKeyTMPro.text = SingleKeyText;
        LongKeyTMPro.text = LongKeyText;
        DescriptiveTMPro.text = DescriptiveText;
    }

    private float lastSwitch = 0f;
    public float FlashTime = 1f;
    private void Update()
    {
        if (Time.time-lastSwitch>FlashTime)
        {
            lastSwitch = Time.time;

            toggle = !toggle;

            if (FlashSingleKey)
            {
                if (toggle)
                {
                    SingleKey.color = FlashColor1;
                }
                else
                {
                    SingleKey.color = FlashColor2;
                }
            }

            if (FlashLongKey)
            {
                if (toggle)
                {
                    LongKey.color = FlashColor1;
                }
                else
                {
                    LongKey.color = FlashColor2;
                }
            }

            if (FlashLeftClick)
            {
                LeftClick.enabled = toggle;
            }

            if (FlashRightClick)
            {
                RightClick.enabled = toggle;
            }

            if (FlashMiddleClick)
            {
                MiddleClick.enabled = toggle;
            }
        }
    }
}
