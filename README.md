Unity Utils
===========

Just a collection of Unity editor utilities mostly found on random forums.

Can be installed using [VPM](https://vcc.docs.vrchat.com/vpm/) for VRChat from [here](https://vpm.roli.ga/)!

InspectorLockToggle
-------------------

A menu entry and hotkey for toggling the lock on the Inspector window currently under the cursor.

Entry is found in `Tools/Unity Utils/Toggle Inspector Lock`, and the default binding is `Alt + E`.

KeepSceneAlive
--------------

Keeps the Scene view focused when entering play mode instead of switching to the Game view.

Enabled from `Tools/Unity Utils/Enable Keep Scene Alive`. A GameObject is created in the scene with a toggle to enable/disable the script.

**Note for Unity 2021.2 and newer:** This is no longer necessary, you can now go to the *Game* tab and change `Play Focused` to `Play Unfocused`.

ShaderOccuranceWindow
---------------------

Find materials based on a specific shader. Found in `Tools/Unity Utils/Shader Occurance`.

ComponentPropertyCopy
---------------------

Copy properties from one component to another in bulk.

`Script Properties` and `Script Fields` are all fields and properties on the component.

`Properties` are manually added properties that require special steps to modify, like for example Mesh Renderer blend shapes. More of these can be added in `Quirks.cs`. Please send a PR if you add any useful ones!

Dragging one or more gameobjects to the header of the `Destinations` list will add all componets matching the type of `Source` to the list.

Note that **not all properties this script modifies are undoable**, so be careful.

Found in `Tools/Unity Utils/Component Property Copy`, or in the context menu on components.

SaveTexture
-----------

Save the selected texture to a PNG file. Useful for exporting temporary in-memory textures in play mode.

Note that texture assets must have the `Read/Write Enabled` option set for scripts like this one to access them.

Found in `Tools/Unity Utils/Save Selected Texture`.

AnimatorControllerMerger
------------------------

Merges a list of animator controllers into one. Animator layer contents is **referenced**, not copied, so changes on the master controller will propagate to the child controllers.

To enable, select an animator controller and press "Enable Controller Merger". Note that this will wipe any layers already on this controller, so use with caution!

GetAnimatorLayer
----------------

Display layer index of currently selected animator layer. Useful for VRChat's "VRC Animator Layer Control", since it uses layer indexes instead of names.

Found in `Tools/Unity Utils/Show Animator Layer Index`.

Capture Game View
-----------------

Takes a screenshot of the game view.

Found in `Tools/Unity Utils/Capture Game View`.