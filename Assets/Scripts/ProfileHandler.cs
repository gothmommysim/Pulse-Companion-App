//Code by Sim Sealy

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ProfileHandler : MonoBehaviour
{
    [SerializeField] public static string profileName = "";
    [SerializeField] public static int profileAge = 0;

    private float targetHrMax;
    [SerializeField] private float targetZoneLower;
    [SerializeField] private float targetZoneHigher;
    private float workoutIntensity = 0.8f;

    [SerializeField] TextMeshProUGUI targetZoneLowerUI;
    [SerializeField] TextMeshProUGUI targetZoneHigherUI;
    [SerializeField] Slider sliderWorkoutIntensity;

    bool overwriteProfile = false;
    public static bool overwriteRequested = false;
    string path;
    [SerializeField] List<string> loadedProfileNames;


    // Start is called before the first frame update
    void Start()
    {
        path = Application.persistentDataPath;

        if(!Directory.Exists(Path.Combine(path, "Profiles")))
            Directory.CreateDirectory(Path.Combine(path, "Profiles"));

        MenuManager.callToLoadProfiles = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (MenuManager.callToLoadProfiles)
        {
            Debug.Log("Loading all profiles");
            LoadAllProfiles();
        }
    }

    public void ReadNameInput(string input)
    {
        profileName = input;
    }

    public void ReadAgeInput(string input)
    {
        int.TryParse(input, out profileAge);
        CalculateTargetZone();
    }

    public void CalculateTargetZone()
    {
        targetHrMax = 220 - profileAge;
        targetZoneHigher = targetHrMax*workoutIntensity;
        targetZoneHigherUI.text = ((int)targetZoneHigher).ToString();
        targetZoneLower = targetHrMax*(workoutIntensity-0.1f);
        targetZoneLowerUI.text = ((int)targetZoneLower).ToString();
    }

    public void SliderWorkoutIntensity(float input)
    {
        workoutIntensity = input;
        CalculateTargetZone();
    }

    public void SetNewProfile()
    {
        try
        {
            Debug.Log("Asking to create new user profile...");
            Debug.Log(profileName);

            string profilePath = path + "/Profiles/" + profileName + "Profile.cfg";

            Debug.Log(File.Exists(profilePath));
            Debug.Log(profilePath);

            if (!File.Exists(profilePath) || overwriteProfile==true)
            {
                Debug.Log("Profile request approved.");

                FileStream file = File.Create(profilePath);

                file.Close();

                WriteProfileConfigFile(profilePath);

                LoadAllProfiles();

                overwriteProfile = false;
            }
            else
            {
                OverwriteRequest();
            }
        } 
        catch(Exception e)
        {
            Debug.Log("Can't create a new user profile.");
        }
    }

    public void SetTargetHrZone()
    {
        try
        {
            if(MenuManager.prevMenu[MenuManager.prevMenu.Count-1] == GameObject.Find("Main Camera/Canvas/Create New User"))
            {
                SetNewProfile();
            }
            else
            {
                string profilePath = path + "/Profiles/" + profileName + "Profile.cfg";
                WriteProfileConfigFile(profilePath);
            }
        } catch(Exception e)
        {

        }
    }

    public static void ResetProfileVals()
    {
        profileName = "";
        profileAge = 0;
    }

    public void OverwriteRequest()
    {
        overwriteRequested = true;
        MenuManager.RequestDialogBox();
    }

    public void OverwriteProfile()
    {
        overwriteProfile = true;
    }

    public void LoadAllProfiles()
    {
        MenuManager.callToLoadProfiles = false;
        DirectoryInfo dirInfo = new DirectoryInfo(Path.Combine(path, "Profiles"));
        FileInfo[] info = dirInfo.GetFiles("*.cfg*");
        foreach(FileInfo f in info)
        {
            StreamReader reader = new StreamReader(f.FullName);
            string name = reader.ReadLine();
            if (!loadedProfileNames.Contains(name))
            {
                MenuManager.CreateProfileUIButton(name);
                loadedProfileNames.Add(name);
            }
            reader.Close();
        }
    }

    public void LoadProfile()
    {
        try
        {
            GameObject profileGameObj = EventSystem.current.currentSelectedGameObject;

            //Get name from button text
            TextMeshProUGUI profileTextMesh = profileGameObj.GetComponentInChildren(typeof(TextMeshProUGUI), true) as TextMeshProUGUI;
            profileName = profileTextMesh.text;

            //Loading profile values
            StreamReader reader = new StreamReader(path + "/Profiles/" + profileName + "Profile.cfg");

            profileName = reader.ReadLine();
            int.TryParse(reader.ReadLine(), out profileAge);
            float.TryParse(reader.ReadLine(), out targetHrMax);
            float.TryParse(reader.ReadLine(), out targetZoneHigher);
            float.TryParse(reader.ReadLine(), out targetZoneLower);
            float.TryParse(reader.ReadLine(), out workoutIntensity);

            reader.Close();

            //Update UI (should really be in menu manager but whatev)
            targetZoneHigherUI.text = ((int)targetZoneHigher).ToString();
            targetZoneLowerUI.text = ((int)targetZoneLower).ToString();
            sliderWorkoutIntensity.value = workoutIntensity;
            //
        } catch(Exception e)
        {

        }
    }

    public void WriteProfileConfigFile(string profilePath)
    {
        StreamWriter writer = new StreamWriter(profilePath);

        string writeData = profileName;
        writer.WriteLine(writeData);

        writeData = profileAge.ToString();
        writer.WriteLine(writeData);

        writeData = targetHrMax.ToString();
        writer.WriteLine(writeData);

        writeData = targetZoneHigher.ToString();
        writer.WriteLine(writeData);

        writeData = targetZoneLower.ToString();
        writer.WriteLine(writeData);

        writeData = workoutIntensity.ToString();
        writer.WriteLine(writeData);

        writer.Close();
    }
}
