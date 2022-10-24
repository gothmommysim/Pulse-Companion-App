//Code by Sim Sealy

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] public static GameObject currentMenu;
    [SerializeField] public static List<GameObject> prevMenu;

    [SerializeField] TMP_InputField inputName;
    [SerializeField] TMP_InputField inputAge;
    [SerializeField] Slider sliderWorkoutIntensity;

    [SerializeField] public static GameObject overwriteDialogBox;

    public static bool callToLoadProfiles = false;

    // Start is called before the first frame update
    void Start()
    {
        //Starting menu
        currentMenu = GameObject.Find("Main Camera/Canvas/User Profiles");

        //Initialize list of previous menus
        prevMenu = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToUserProfiles()
    {
        callToLoadProfiles = true;
        currentMenu.SetActive(false);
        prevMenu.Add(currentMenu);
        currentMenu = GameObject.Find("Main Camera/Canvas/User Profiles");
        currentMenu.SetActive(true);
    }

    public void GoToCreateNewUser()
    {
        currentMenu.SetActive(false);
        prevMenu.Add(currentMenu);
        currentMenu = GameObject.Find("Main Camera/Canvas/Create New User");
        currentMenu.SetActive(true);
    }

    public void GoToSettingsTargetZone()
    {
        if (currentMenu == GameObject.Find("Main Camera/Canvas/Create New User") && (ProfileHandler.profileName=="" || ProfileHandler.profileAge==0))
        {
            return;
        }
        currentMenu.SetActive(false);
        prevMenu.Add(currentMenu);
        currentMenu = GameObject.Find("Main Camera/Canvas/Settings - Target Zone");
        currentMenu.SetActive(true);
    }

    public void GoToHub()
    {
        if (!ProfileHandler.overwriteRequested)
        {
            currentMenu.SetActive(false);
            prevMenu.Add(currentMenu);
            currentMenu = GameObject.Find("Main Camera/Canvas/Hub");
            currentMenu.SetActive(true);
        }
    }

    public void GoBack()
    {
        try{
            currentMenu.SetActive(false);
            prevMenu[prevMenu.Count-1].SetActive(true);
            currentMenu = prevMenu[prevMenu.Count-1];
            prevMenu.RemoveAt(prevMenu.Count-1);
        } catch(Exception e)
        {
            Debug.Log("Error: Can't go back");
        }
    }

    public void ClearProfileFields()
    {
        inputName.ResetInputField();
        inputAge.ResetInputField();
        sliderWorkoutIntensity.value = 0.8f;

        ProfileHandler.ResetProfileVals();
    }

    public static void RequestDialogBox()
    {
        overwriteDialogBox = GameObject.Find("Main Camera/Canvas/Overwrite Dialog Box");
        overwriteDialogBox.SetActive(true);
    }

    public void CloseDialogBox()
    {
        if (overwriteDialogBox = GameObject.Find("Main Camera/Canvas/Overwrite Dialog Box"))
        {
            overwriteDialogBox.SetActive(false);
        }
        else
        {
            overwriteDialogBox = GameObject.Find("Main Camera/Canvas/Overwrite Dialog Box");
            overwriteDialogBox.SetActive(false);
        }
        ProfileHandler.overwriteRequested = false;
    }

    public static void CreateProfileUIButton(string profileName)
    {
        GameObject defaultProfile = GameObject.Find("Main Camera/Canvas/User Profiles/Viewport/Content/Profiles/Select Profile");
        GameObject newProfile = Instantiate(defaultProfile, defaultProfile.transform.parent);

        if (!defaultProfile.transform.parent.gameObject.activeInHierarchy)
        {
            defaultProfile.transform.parent.gameObject.SetActive(true);
            Debug.Log(defaultProfile.transform.parent.gameObject);
        }

        newProfile.SetActive(true);

        TextMeshProUGUI textUI = newProfile.GetComponentInChildren(typeof(TextMeshProUGUI), true) as TextMeshProUGUI;
        textUI.text = profileName;
    }
}
