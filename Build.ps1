$codeDir = Split-Path -Parent $PSCommandPath
$solutionPath = Join-Path $codeDir 'StringCalculator.sln'

echo "`nRestoring ...`n"
& "$codeDir\.nuget\nuget.exe" restore $solutionPath
if( $LASTEXITCODE -ne 0 ) {
    throw "The nuget restore failed. Exit Code: $LASTEXITCODE"
}

echo "`nBuilding ...`n"

C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe /v:m $solutionPath
if( $LASTEXITCODE -ne 0 ) {
    throw "The build failed. Exit Code: $LASTEXITCODE"
}

echo "`nTesting ...`n"

& "$codeDir\packages\NUnit.Runners.2.6.4\tools\nunit-console.exe" /nologo "$codeDir\StringCalculator\bin\Debug\StringCalculator.dll"
if( $LASTEXITCODE -ne 0 ) {
    throw "The tests failed. Exit Code: $LASTEXITCODE"
}
