Set SERVERNAME=%2
Set APPPATH=%1
nmap.exe -PE -PA21,23,80,3389 -A -v -T4 %SERVERNAME% -oX %APPPATH%%SERVERNAME%.xml