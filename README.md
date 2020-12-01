# keytest3akcf
(archived from https://archive.codeplex.com/?p=keytest3akcf

+ How to capture F1 and F2 in WEH Cpmapct Framework app
+ Keyboard capture of F1 and F2 (and others) in Compact Framework
+ How to capture F1 and F2 in Compact Framework on Windows Embedded Handheld 6.5.3

A compact framework KeyboardHook lib to capture F1 and F2 keystrokes on Windows Embedded Handheld 6.5 (WEH)

Also has examples on how to use SmartDeviceFramework Application2/Ex with IMessagefilter to capture F1 and F2

Normally, Function keys are catched by WEH itself to perform OS functions like opening menu items, do Volume up/down, open the phone app or close it and others (see winuserm.h of WEH SDK).

Industrial devices running WEH offer hardware keyboards with function keys. As a programmer you might want to make use of function keystrokes but the OS and Compact Framework normally keep Function Key messages from your compact framework application.

The provided examples and library offers you to capture these function keys and use them in your CF application.

