net start "SQL Server Browser"

net stop "SQL Server Launchpad (SQLEXPRESS)"
net stop "SQL Server (SQLEXPRESS)"
net start "SQL Server (SQLEXPRESS)"
net start "SQL Server Launchpad (SQLEXPRESS)"

pause