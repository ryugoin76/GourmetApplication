if (!([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole("Administrators")) { Start-Process powershell.exe "-File `"$PSCommandPath`"" -Verb RunAs; exit }

net start "SQL Server Browser"

net stop "SQL Server Launchpad (SQLEXPRESS)"
net stop "SQL Server (SQLEXPRESS)"
net start "SQL Server (SQLEXPRESS)"
net start "SQL Server Launchpad (SQLEXPRESS)"

pause