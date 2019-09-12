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
	
    'src\Core\All\Optivem.Framework.Core.All.csproj',	
    'src\Core\Application\Optivem.Framework.Core.Application.csproj',
    'src\Core\Application.Interface\Optivem.Framework.Core.Application.Interface.csproj',
    'src\Core\Common\Optivem.Framework.Core.Common.csproj',
    'src\Core\Domain\Optivem.Framework.Core.Domain.csproj',
	
	# ### ============================== INFRASTRUCTURE ============================== ###
	
    'src\Infrastructure\AspNetCore\Optivem.Framework.Infrastructure.AspNetCore.csproj',
    'src\Infrastructure\AutoMapper\Optivem.Framework.Infrastructure.AutoMapper.csproj',
    'src\Infrastructure\CsvHelper\Optivem.Framework.Infrastructure.CsvHelper.csproj',
    'src\Infrastructure\EntityFrameworkCore\Optivem.Framework.Infrastructure.EntityFrameworkCore.csproj',
    'src\Infrastructure\EPPlus\Optivem.Framework.Infrastructure.EPPlus.csproj',
    'src\Infrastructure\FluentValidation\Optivem.Framework.Infrastructure.FluentValidation.csproj',
    'src\Infrastructure\MediatR\Optivem.Framework.Infrastructure.MediatR.csproj',
    'src\Infrastructure\NewtonsoftJson\Optivem.Framework.Infrastructure.NewtonsoftJson.csproj',	
    'src\Infrastructure\Selenium\Optivem.Framework.Infrastructure.Selenium.csproj',
    'src\Infrastructure\System\Optivem.Framework.Infrastructure.System.csproj',
	
	# ### ============================== DEPENDENCY INJECTION ============================== ###
	
	# Base
    'src\DependencyInjection\Base\DependencyInjection\Optivem.Framework.DependencyInjection.Common.csproj', # TODO: VC: Rename
	
	# Core
    'src\DependencyInjection\Core\Application\Optivem.Framework.DependencyInjection.Core.Application.csproj',
    'src\DependencyInjection\Core\Domain\Optivem.Framework.DependencyInjection.Core.Domain.csproj',
	
	# Infrastructure
	# 'src\DependencyInjection\Infrastructure\AspNetCore\Optivem.Framework.DependencyInjection.Infrastructure.AspNetCore.csproj',
    'src\DependencyInjection\Infrastructure\AutoMapper\Optivem.Framework.DependencyInjection.Infrastructure.AutoMapper.csproj',
    # 'src\DependencyInjection\Infrastructure\CsvHelper\Optivem.Framework.DependencyInjection.Infrastructure.CsvHelper.csproj',
    'src\DependencyInjection\Infrastructure\EntityFrameworkCore\Optivem.Framework.DependencyInjection.Infrastructure.EntityFrameworkCore.csproj',
    # 'src\DependencyInjection\Infrastructure\EPPlus\Optivem.Framework.DependencyInjection.Infrastructure.EPPlus.csproj',
    'src\DependencyInjection\Infrastructure\FluentValidation\Optivem.Framework.DependencyInjection.Infrastructure.FluentValidation.csproj',
    'src\DependencyInjection\Infrastructure\MediatR\Optivem.Framework.DependencyInjection.Infrastructure.MediatR.csproj',
    'src\DependencyInjection\Infrastructure\NewtonsoftJson\Optivem.Framework.DependencyInjection.Infrastructure.NewtonsoftJson.csproj',
    # 'src\DependencyInjection\Infrastructure\Selenium\Optivem.Framework.DependencyInjection.Infrastructure.Selenium.csproj',
    # 'src\DependencyInjection\Infrastructure\System\Optivem.Framework.DependencyInjection.Infrastructure.System.csproj',	


	# ### ============================== WEB ============================== ###

    'src\Web\AspNetCore\Optivem.Framework.Web.AspNetCore.csproj',
	
	# ### ============================== TEST ============================== ###

	'test\Base\AspNetCore\Optivem.Framework.Test.AspNetCore.csproj',
	'test\Base\EntityFrameworkCore\Optivem.Framework.Test.EntityFrameworkCore.csproj',
	'test\Base\FluentAssertions\Optivem.Framework.Test.FluentAssertions.csproj',
	'test\Base\MicrosoftExtensions\Optivem.Framework.Test.MicrosoftExtensions.csproj',
    'test\Base\Selenium\Optivem.Framework.Test.Selenium.csproj'	
    'test\Base\Xunit\Optivem.Framework.Test.Xunit.csproj'
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