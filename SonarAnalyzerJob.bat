C:\nuget\nuget.exe restore Bagaround.sln



C:\sonar-runner\MSBuild.SonarQube.Runner.exe begin /key:"th.co.iconext:Bagaround" /name:"Bagaround" /version:"1.0-SNAPSHOT"

"C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe" /t:Build /p:Configuration=Release

if %errorlevel% neq 0 exit /b %errorlevel%

C:\sonar-runner\MSBuild.SonarQube.Runner.exe end