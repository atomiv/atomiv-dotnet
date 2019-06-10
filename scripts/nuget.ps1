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

	# ### ============================== CORE ============================== ###
	
	# All
    'src\Core\All\Optivem.Core.All.csproj',	

	# Common
    'src\Core\Common\Optivem.Core.Common.csproj',

	# Domain
    'src\Core\Domain\Optivem.Core.Domain.csproj',
	
	# Application
    'src\Core\Application.Interface\Optivem.Core.Application.Interface.csproj',
    'src\Core\Application\Optivem.Core.Application.csproj',
	
	# ### ============================== DEPENDENCY INJECTION ============================== ###
	
	# Base
    'src\DependencyInjection\Base\DependencyInjection\Optivem.DependencyInjection.csproj',
	
	# Core
    'src\DependencyInjection\Core\Application\Optivem.DependencyInjection.Core.Application.csproj',	
    'src\DependencyInjection\Core\Domain\Optivem.DependencyInjection.Core.Domain.csproj',	
	
	# Infrastructure	
    'src\DependencyInjection\Infrastructure\AutoMapper\Optivem.DependencyInjection.Infrastructure.AutoMapper.csproj',	
	# TODO: VC: Add other infrastructure

	# ### ============================== INFRASTRUCTURE ============================== ###
	
	# All
    'src\Infrastructure\All\Optivem.Infrastructure.All.csproj',

	# AspNetCore
    'src\Infrastructure\AspNetCore\Optivem.Infrastructure.AspNetCore.csproj',
	
	# AutoMapper
    'src\Infrastructure\AutoMapper\Optivem.Infrastructure.AutoMapper.csproj',
	
	# CsvHelper
    'src\Infrastructure\CsvHelper\Optivem.Infrastructure.CsvHelper.csproj',
	
	# EntityFrameworkCore
    'src\Infrastructure\EntityFrameworkCore\Optivem.Infrastructure.EntityFrameworkCore.csproj',
	
	# FluentValidation
    'src\Infrastructure\FluentValidation\Optivem.Infrastructure.FluentValidation.csproj',
	
	# MediatR
    'src\Infrastructure\MediatR\Optivem.Infrastructure.MediatR.csproj',
	
	# NewtonsoftJson
    'src\Infrastructure\NewtonsoftJson\Optivem.Infrastructure.NewtonsoftJson.csproj',	
	
	# Selenium
    'src\Infrastructure\Selenium\Optivem.Infrastructure.Selenium.csproj',
	
	# System
    'src\Infrastructure\System\Optivem.Infrastructure.System.csproj',

	# ### ============================== WEB ============================== ###

	# AspNetCore
    'src\Web\AspNetCore\Optivem.Web.AspNetCore.csproj',
	
	# ### ============================== TEST - BASE ============================== ###
	
	# All
    'test\Test\Base\Optivem.Test.All.csproj',
	
	# Common
	'test\Test\Base\Optivem.Test.Common.csproj',
	
	# AspNetCore
	'test\Test\Base\Optivem.Test.AspNetCore.csproj',
	
	# AspNetCore.EntityFrameworkCore
	'test\Test\Base\Optivem.Test.AspNetCore.EntityFrameworkCore.csproj',

	# EntityFrameworkCore
	'test\Test\Base\Optivem.Test.EntityFrameworkCore.csproj',	
	
	# ### ============================== TEST - XUNIT ============================== ###
	
	# All	
    'test\Test\Xunit\Optivem.Test.Xunit.All.csproj',

	# AspNetCore.EntityFrameworkCore	
    'test\Test\Xunit\Optivem.Test.Xunit.AspNetCore.EntityFrameworkCore.csproj',
	
	# Common
    'test\Test\Xunit\Optivem.Test.Xunit.Common.csproj',
	
	# Selenium
    'test\Test\Xunit\Optivem.Test.Xunit.Selenium.csproj',
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