# VMagicMirror WheelAbsolute
A [BepInEx 5](https://bepinex.dev/) plugin for [VMagicMirror](https://malaybaku.github.io/VMagicMirror/en/) for translating car wheel movements to absolute positions instead of relative rotation.

## Installation
This modification requires BepInEx 5 in order to be loaded into VMagicMirror.

### Installing BepInEx
Due to restrictive permissions of the default Windows `Program Files` folder, I recommend installing it to a custom location if you want to modify it and avoid running into permission issues when running applications on a normal user account.
1. Download the latest BepInEx 5 x64 build from the [BepInEx project page](https://github.com/BepInEx/BepInEx/releases).
2. Extract the contents of the ZIP file into your VMagicMirror installation folder.
3. Start and close VMagicMirror once. 
4. Check if BepInEx created a configuration file in the `BepInEx\config` subfolder and an initial log file `BepInEx\LogOutput.log`.

For more information and troubleshooting, please check the [BepInEx documentation](https://docs.bepinex.dev/).

### Installing the plugin
1. Download the plugin from the [release section](https://github.com/Shadnix-was-taken/VMagicMirror-WheelAbsolute/releases)
2. Extract the contents of the ZIP file into your `\BepInEx\plugins\` subfolder of your VMagicMirror installation folder.

## Removal

### Removing the plugin
Delete the DLL file from your `\BepInEx\plugins\` subfolder of your VMagicMirror installation folder.

### Removing BepInEx
Either delete the `\BepInEx\` subfolder and all other files which came with the BepInEx ZIP file, or uninstall VMagicMirror, delete the rest of the VMagicMirror install directory and reinstall VMagicMirror.

## Known issues / caveats
* This plugin currently assumes a fixed max wheel rotation of 900°. Feel free to contact me if you use this plugin and want this to be configurable.
* VMagicMirror won't receive any keyboard input if the BepInEx console for log output is enabled. The log console is disabled by default, so this needs an active configuration change for it to become an issue.

## Building/Contributing to WheelAbsolute
In order to build this project, please add a `WheelAbsolute.csproj.user` file in the project directory and specify where the application is located on your disk:

```xml
<?xml version="1.0" encoding="utf-8"?>
<Project xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <!-- Change this path if necessary. Make sure it ends with a backslash. -->
    <AppDirPath>C:\Program Files\VMagicMirror\</AppDirPath>
  </PropertyGroup>
</Project>
```