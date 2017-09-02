# Get the root project directory.
$root = Resolve-Path (Join-Path $PSScriptRoot '..')

# Set up the tools directory.
$toolsDir = "$root\build\tools"
if ((Test-Path -path $toolsDir) -eq $false) {
  New-Item $toolsDir -Type Directory | Out-Null
}

# Set up the output directory.
$outputDir = "$root\artifacts"
if ((Test-Path -path $outputDir) -eq $false) {
  New-Item $outputDir -Type Directory | Out-Null
}

# Find or download NuGet.
$nuget = "$toolsDir\nuget.exe"
if ((Test-Path $nuget) -eq $false) {
  Invoke-WebRequest -Uri https://dist.nuget.org/win-x86-commandline/latest/nuget.exe -OutFile $nuget
}

# Find or download VSWhere.
$vswhere = "$toolsDir\vswhere\tools\vswhere.exe"
if ((Test-Path $vswhere) -eq $false) {
  & $nuget install vswhere -ExcludeVersion -OutputDirectory $toolsDir
}

# Find VS using VSWhere
$vs = & $vswhere -latest -products * -requires Microsoft.Component.MSBuild -property installationPath
if ((Test-Path $vs) -eq $false) {
  throw 'Could not find VS installation'
}

# Locate MSBuild using resolved VS path.
$msbuild = Resolve-Path "$vs\MSBuild\*\Bin\MSBuild.exe"
if ((Test-Path $msbuild) -eq $false) {
  throw 'Could not find MSBuild'
}

# Set MSBuild alias.
Set-Alias MSBuild $msbuild

# Build and pack.
MSBuild "/t:Restore,Build,Pack" "/p:Configuration=Release,OutputPath=$outputDir" "$root\src\JsonFormatterPlus\JsonFormatterPlus.csproj"
