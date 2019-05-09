# Parameters

param (
	[string]$rootPath = '.',
	[Parameter(Mandatory=$true)][string]$version = '0.0.0',
	[Parameter(Mandatory=$true)][string]$key = '',
	[string]$nugetApi = 'https://api.nuget.org/v3/index.json',
    [bool]$build = $true,
    [bool]$pack = $true
)

# Build & Pack

# TODO: VC: Perhaps make conditional?

if($build)
{
    dotnet build -c Release
}

if($pack)
{
    dotnet pack -c Release
}



# TODO: VC: Transfer this list into txt file (nuget.config), then read list from file
# TODO: VC: The files could also be like json due to the hierarchy, perhaps more readable and verifying then the correct path

$projects = @(

	# ### ============================== COMMON ============================== ###

	# Common
    'src\Common\Http\Optivem.Common.Http.csproj',
    'src\Common\Serialization\Optivem.Common.Serialization.csproj',
    'src\Common\WebAutomation\Optivem.Common.WebAutomation.csproj',

	# ### ============================== CORE ============================== ###

	# Domain
    'src\Core\Domain\Optivem.Core.Domain.csproj',
	
	# Application
    'src\Core\Application.Interface\Optivem.Core.Application.Interface.csproj',
    'src\Core\Application\Optivem.Core.Application.csproj',

	# ### ============================== INFRASTRUCTURE ============================== ###

	# Http
    'src\Infrastructure\Http\System\Optivem.Infrastructure.Http.System.csproj',
	
	# Mapping
    'src\Infrastructure\Mapping\AutoMapper\Optivem.Infrastructure.Mapping.AutoMapper.csproj',
	
	# Messaging
    'src\Infrastructure\Messaging\MediatR\Optivem.Infrastructure.Messaging.MediatR.csproj',
	
	# Persistence
    'src\Infrastructure\Persistence\EntityFrameworkCore\Optivem.Infrastructure.Persistence.EntityFrameworkCore.csproj',
	
	# Serialization
    'src\Infrastructure\Serialization\CsvHelper\Optivem.Infrastructure.Serialization.CsvHelper.csproj',
	'src\Infrastructure\Serialization\NewtonsoftJson\Optivem.Infrastructure.Serialization.NewtonsoftJson.csproj',
	'src\Infrastructure\Serialization\System\Optivem.Infrastructure.Serialization.System.csproj',

	# Validation
    'src\Infrastructure\Validation\FluentValidation\Optivem.Infrastructure.Validation.FluentValidation.csproj',

	# WebAutomation
    'src\Infrastructure\WebAutomation\Selenium\Optivem.Infrastructure.WebAutomation.Selenium.csproj',

	# ### ============================== WEB ============================== ###

	# AspNetCore
    'src\Web\AspNetCore\Optivem.Web.AspNetCore.csproj',
	
	# ### ============================== TEST ============================== ###
	
	# Base
    'test\Base\Xunit\Optivem.Test.Xunit.csproj',
    'test\Base\Xunit.AspNetCore\Optivem.Test.Xunit.AspNetCore.csproj'
)

# TODO: VC: Update all project files to the new version

$nugetPaths = @()

Foreach($project in  $projects)
{
    $projectPath = Join-Path -Path $rootPath -ChildPath $project

    $projectPathExists = Test-Path -Path $projectPath

    if(!$projectPathExists)
    {
        Write-Error -Message "Project path not found: $projectPath"  -ErrorAction Stop
    }
	
	$projectName = [io.path]::GetFileNameWithoutExtension($projectPath)
	
	$projectDir = (Get-Item $projectPath).Directory
	
	# D:\Github\optivem\pdn\src\Core\Common\Optivem.Framework.Core.Common.Mapping\bin\Release\Optivem.Framework.Core.Common.Mapping.1.0.3.nupkg
	
	$nugetPath = Join-Path -Path $projectDir -ChildPath "bin\Release\$projectName.$version.nupkg"

	$nugetPathExists = Test-Path -Path $nugetPath
	
	if(!$nugetPathExists)
	{
        Write-Error -Message "Nuget path not found: $nugetPath" -ErrorAction Stop
	}

    $nugetPaths += $nugetPath
	
	Write-Host $nugetPath
}

# TODO: VC: Get success / failure and log into file so that we know the last published successful version, also useful later for retry

Foreach($nugetPath in $nugetPaths)
{
	dotnet nuget push $nugetPath -k $key -s $nugetApi
}