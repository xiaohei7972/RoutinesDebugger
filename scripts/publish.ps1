param([string]$OutputDirectory = (Join-Path $PSScriptRoot '../artifacts/RoutinesDebugger-win-x64'))
$ErrorActionPreference = 'Stop'
$repositoryRoot = Split-Path $PSScriptRoot -Parent
$destination = [IO.Path]::GetFullPath($OutputDirectory)
if (Test-Path -LiteralPath $destination) { throw "Output directory already exists. Choose a new directory: $destination" }
New-Item -ItemType Directory -Path $destination | Out-Null
foreach ($project in @('RoutineHelper', 'RoutineCompiler', 'ReflectionCodeGenerator')) {
    dotnet publish (Join-Path $repositoryRoot "$project/$project.csproj") -c Release --self-contained false -o $destination --nologo
    if ($LASTEXITCODE -ne 0) { throw "Publish failed: $project" }
}
$unexpectedResources = Get-ChildItem -LiteralPath $destination -Recurse -Filter '*.resources.dll' |
    Where-Object { [Reflection.AssemblyName]::GetAssemblyName($_.FullName).CultureName -ne 'zh-Hans' }
if ($unexpectedResources) {
    throw "Unexpected satellite resource languages: $($unexpectedResources.FullName -join ', ')"
}
Copy-Item -LiteralPath (Join-Path $repositoryRoot 'README.md') -Destination $destination
Copy-Item -LiteralPath (Join-Path $repositoryRoot 'LICENSE') -Destination $destination
Compress-Archive -Path (Join-Path $destination '*') -DestinationPath ($destination + '.zip') -Force
Write-Output ($destination + '.zip')
