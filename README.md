# ChatSonic API for Unity

A light weight plugin to use ChatSonic API in Unity projects at runtime. Features: 

* No special dependency installation or environment setting is required for both you and your players. 

* No dll files. Full c# source code is included. 

* Deserialized with Unity's built-in Json.Utility, no third-party serialization tool is required.

* Option to include real-time search data.

* Option to enable memory functionality.

* Available to talk in 24 languages.

## Quick Start

1. Download [the latest released .unitypackage](https://github.com/BrieYRen/ChatSonic-API-for-Unity/releases), import it to your Unity project. Or, download this repository, extract the files and copy anything under 'Assets' folder into your project's 'Assets' folder. (Demo scenes and example scripts under 'Assets/Plugins/ChatSonicAPI/Example' folder is for first time users but not required for the core api functionality. You can delete that 'Example' file any time you want. )

2. Copy paste your ChatSonic api key at 'Assets/Resources/SonicConfig/AuthInfo'. If you don't have a key, sign in [WriteSonic's website](https://docs.writesonic.com/reference/finding-your-api-key) and generate one. Please note that if you use an online repository to version control your project, save your key in AuthInfo and push it online is unsafe. Please ensure that you've deleted your key every time before you push.

3. You can start from play with the demo scene ExampleChatBot under 'Assets/Plugins/ChatSonicAPI/Example/DemoScene'. Try out different settings by changing values under 'Assets/Resources/SonicConfig/CompletionSettings', if you have no idea how the values work, hover over each value for tooltips. 

## Limitations

* I only tested it on Windows machine (using Windows 10, Unity 2021.3.18), I don't know if it works on Mac or Linux. If you find it not working on them, please let me know. 

To report bugs or suggestions, please feel free to submit issue.