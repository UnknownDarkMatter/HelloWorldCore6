echo off
echo il faut faire un publish avant de copier les fichiers
pause
mkdir %~dp0\bin\WebSite
mkdir %~dp0\bin\DbServer
xcopy %~dp0\..\HelloWorldCore6\bin\Release\net6.0\publish\ /Y /S %~dp0\bin\WebSite
echo les fichiers ont ete copies
pause
