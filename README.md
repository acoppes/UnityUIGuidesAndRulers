# Unity UI Rulers And Guides

Some simple tools to help developing UIs in Unity.

# Install from UPM

Just open Unity Package Manager and select add package from git URL and add this `https://github.com/acoppes/UnityUIGuidesAndRulers.git#package`

Or add it manually to the `manifest.json`, like this:

```
  "dependencies": {
    "com.gemserk.uiguidesandrulers": "https://github.com/acoppes/UnityUIGuidesAndRulers.git#package",
    ...
  }
```

# Install manually

Download the [unitypackage](releases/Gemserk.UIGuidesAndRulers-0.0.1.unitypackage?raw=true) file located inside releases folder and install it manually.

# Usage

Drag and drop any prefab from the folder Runtime/Prefabs to a UI Canvas, or create your own by adding the UIGuide to an object inside a Canvas. You can check any of the Scenes in the project as examples too.

# Random Screenshots

![Alt text](images/ruler-example1.png?raw=true "Simple Guide")
![Alt text](images/ruler-example2.png?raw=true "Guide with ruler")
![Alt text](images/example3.png?raw=true "Using different anchoring")