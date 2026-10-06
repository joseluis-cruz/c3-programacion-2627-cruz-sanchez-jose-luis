@echo off
powershell -Command "dotnet new console -n (Get-Item .).Name --use-program-main"
