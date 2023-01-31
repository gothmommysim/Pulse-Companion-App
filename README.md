# Pulse - Heart Rate Monitor Companion App

## Overview
This repository is dedicated to the app component of the Pulse project, a heart rate monitor that notifies users when they are above or below their targeted training heart rate zone. The overall project was a collaboration between 6 people: Alex B., Lizzie G., Brian L., Ababakar O., Wilson R., and Sim Sealy. 

**The app was designed and developed by Sim Sealy.**

## App Development
The app was developed in C# for Unity, providing a platform to easily build a cross-platform mobile app with libraries to utilize Android file management.

## App Interface
![Picture1](https://user-images.githubusercontent.com/14210389/215823857-04584073-b2e4-4eef-988e-5bb950a48072.png)
![Picture2](https://user-images.githubusercontent.com/14210389/215823881-ae11597e-8557-45a4-937d-eb09c782bdbf.png)
- Profile Select and Main Menu


![Picture3](https://user-images.githubusercontent.com/14210389/215823952-05a1d01f-4689-42ba-8d90-033efcb2427c.png)
![Picture4](https://user-images.githubusercontent.com/14210389/215823964-6486bc1d-120d-4825-a52f-e33e128baa13.png)
- Create Profile: Allows users to input their name and age to create a profile and finetune their heart rate zones using a workout intensity slider.

On the software interface, the user inputs data for a profile: name and age. Using the age of the user, the app calculates a safe heart rate zone range. The user then enters a workout intensity to finalize their desired target heart rate zone.

![Picture7](https://user-images.githubusercontent.com/14210389/215823984-34f9a0bf-fd68-49f7-8550-ea491804708d.png)
![Picture6](https://user-images.githubusercontent.com/14210389/215824002-572bc582-129b-4113-8998-06f9149fbb67.png)
- Workout Select: Provides a calendar UI to load previous workouts saved locally on the device.
Allows users to view their saved workouts.

The user’s profile data is saved locally to a config file designed to be streamed over Bluetooth. In the workouts section of the app, if a workout file is available locally, the algorithm pulls the heart rate data chosen from the calendar list.

## Testing
Due to time constraints, the test cases for the Pulse Heart Rate Monitor App were set up manually to validate its core functionality. The manual testing process was sufficient for a prototype and covered all of the features, including the accuracy of the heart rate readings, Bluetooth connectivity, and data saving and retrieval functionality. The team tested each feature by inputting data and verifying the output, ensuring that the app was functioning as intended. Despite not being as rigorous as desired, covering all edge cases, this manual testing process allowed the team to deliver a functioning prototype that met their requirements.

## Challenges
One of the challenges faced by the team was implementing Bluetooth Low Energy functionality in the Android app. Since C# is a language native to Microsoft, there was no built-in Bluetooth functionality for Android. The team designed a Bluetooth plugin in Android Studio using Java/Kotlin, allowing C# to call functions in the Kotlin class and scan for BLE devices.


![Picture5](https://user-images.githubusercontent.com/14210389/215824439-e28bada1-0149-449c-bda1-4a140196a814.png)
- Breadboard Device Prototype
