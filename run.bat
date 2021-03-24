@ECHO OFF
dotnet build -c Release
cd bin/Release/net5.0
TestProgram.exe 