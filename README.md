![wkill](icon.png) wkill
========================

> *It's like xkill for Windows!*


This simple C# application allows you to kill (SIGKILL) any process easily by
clicking on one of its windows.  
For killing some system processes, UAC elevation ("Run as administrator") may be
needed, but other elevated processes should close just fine.


Thanks to [andoar](http://gnome-look.org/usermanager/search.php?username=andoar)
for the [icon](http://gnome-look.org/content/show.php?content=74536) (it's under
GNU GPL 3).


Usage
-----

- Run wkill.exe (Pro-Tip: Add a link in your taskbar and assign a hotkey).
- To **kill** a process, click one of its windows with the **left mouse key**.
- To **soft-close** (WM_CLOSE main window), use the **middle mouse key** instead.
- To **exit**, press the **right mouse key** or **ESC**.
