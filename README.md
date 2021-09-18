Unity Utils
===========

Just a collection of Unity editor utilities mostly found on random forums.

InspectorLockToggle
-------------------

A menu entry and hotkey for toggling the lock on the Inspector window currently under the cursor.

Entry is found in `Tools/Unity Utils/Toggle Inspector Lock`, and the default binding is `Alt + E`.

KeepSceneAlive
--------------

Keeps the Scene view focused when entering play mode instead of switching to the Game view.

Enabled from `Tools/Unity Utils/Enable Keep Scene Alive`. A GameObject is created in the scene with a toggle to enable/disable the script.

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

Found in `Tools/Unity Utils/Component Property Copy`.
