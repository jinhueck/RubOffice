using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public enum eButtonType
{
    ChangeWeapon,
    AddWeapon
}

public class ButtonController : MonoBehaviour
{
    public static ButtonController instance;

    public WeaponController weaponController;

    public List<Button> itemButtonList = new List<Button>();
    [SerializeField]
    public List<ButtonFuncClass> buttonFuncClasseList = new List<ButtonFuncClass>();
    public Dictionary<eButtonType, Action<int>> buttonActionDic = new Dictionary<eButtonType, Action<int>>();

    public void Init()
    {
        if (instance == null)
            instance = this;

        buttonActionDic.Add(eButtonType.AddWeapon, weaponController.AddWeapon);
        buttonActionDic.Add(eButtonType.ChangeWeapon, weaponController.SetWeapon);

        int i = 0;
        foreach (var itemButton in itemButtonList)
        {
            int buttonPos = i;
            ButtonFuncClass nButtonFunc = new ButtonFuncClass();
            nButtonFunc.Init(itemButton, buttonPos);
            i += 1;
            buttonFuncClasseList.Add(nButtonFunc);
        }
    }

    public void AddButtonAction(eButtonType buttonType, Action<int> action)
    {
        if (buttonActionDic.ContainsKey(buttonType))
        {
            Debug.Log("This Type is Allready Exist");
            return;
        }
        buttonActionDic.Add(buttonType, action);
    }

    public void ActionPlay(eButtonType buttonType, int pos)
    {
        Action<int> playedAction = buttonActionDic[buttonType];
        playedAction(pos);
    }
}
[Serializable]
public class ButtonFuncClass
{
    public Button button;
    public eButtonType buttonType = eButtonType.ChangeWeapon;
    public int pos;
    //public 

    public void SetButtonType(eButtonType _eButtonType)
    {
        buttonType = _eButtonType;
    }

    public void Init(Button _button, int _pos)
    {
        button = _button;
        pos = _pos;
        button.onClick.AddListener(() =>
        {
            ButtonController.instance.ActionPlay(buttonType, pos);
        });
    }
}