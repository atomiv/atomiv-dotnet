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
	
    'src\Core\All\Optivem.Atomiv.Core.All.csproj',	
    'src\Core\Application\Optivem.Atomiv.Core.Application.csproj',
    'src\Core\Application.Interface\Optivem.Atomiv.Core.Application.Interface.csproj',
    'src\Core\Common\Optivem.Atomiv.Core.Common.csproj',
    'src\Core\Domain\Optivem.Atomiv.Core.Domain.csproj',
	
	# ### ============================== INFRASTRUCTURE ============================== ###
	
    'src\Infrastructure\AspNetCore\Optivem.Atomiv.Infrastructure.AspNetCore.csproj',
    'src\Infrastructure\AutoMapper\Optivem.Atomiv.Infrastructure.AutoMapper.csproj',
    'src\Infrastructure\CsvHelper\Optivem.Atomiv.Infrastructure.CsvHelper.csproj',
    'src\Infrastructure\EntityFrameworkCore\Optivem.Atomiv.Infrastructure.EntityFrameworkCore.csproj',
    'src\Infrastructure\EPPlus\Optivem.Atomiv.Infrastructure.EPPlus.csproj',
    'src\Infrastructure\FluentValidation\Optivem.Atomiv.Infrastructure.FluentValidation.csproj',
    'src\Infrastructure\MediatR\Optivem.Atomiv.Infrastructure.MediatR.csproj',
    'src\Infrastructure\NewtonsoftJson\Optivem.Atomiv.Infrastructure.NewtonsoftJson.csproj',	
    'src\Infrastructure\Selenium\Optivem.Atomiv.Infrastructure.Selenium.csproj',
    'src\Infrastructure\SequentialGuid\Optivem.Atomiv.Infrastructure.SequentialGuid.csproj',
    'src\Infrastructure\System\Optivem.Atomiv.Infrastructure.System.csproj',
	
	# ### ============================== DEPENDENCY INJECTION ============================== ###
	
	# Base
    'src\DependencyInjection\Base\DependencyInjection\Optivem.Atomiv.DependencyInjection.Common.csproj', # TODO: VC: Rename
	
	# Core
    'src\DependencyInjection\Core\Application\Optivem.Atomiv.DependencyInjection.Core.Application.csproj',
    'src\DependencyInjection\Core\Domain\Optivem.Atomiv.DependencyInjection.Core.Domain.csproj',
	
	# Infrastructure
	'src\DependencyInjection\Infrastructure\AspNetCore\Optivem.Atomiv.DependencyInjection.Infrastructure.AspNetCore.csproj',
    'src\DependencyInjection\Infrastructure\AutoMapper\Optivem.Atomiv.DependencyInjection.Infrastructure.AutoMapper.csproj',
    # 'src\DependencyInjection\Infrastructure\CsvHelper\Optivem.Atomiv.DependencyInjection.Infrastructure.CsvHelper.csproj',
    'src\DependencyInjection\Infrastructure\EntityFrameworkCore\Optivem.Atomiv.DependencyInjection.Infrastructure.EntityFrameworkCore.csproj',
    # 'src\DependencyInjection\Infrastructure\EPPlus\Optivem.Atomiv.DependencyInjection.Infrastructure.EPPlus.csproj',
    'src\DependencyInjection\Infrastructure\FluentValidation\Optivem.Atomiv.DependencyInjection.Infrastructure.FluentValidation.csproj',
    'src\DependencyInjection\Infrastructure\MediatR\Optivem.Atomiv.DependencyInjection.Infrastructure.MediatR.csproj',
    'src\DependencyInjection\Infrastructure\NewtonsoftJson\Optivem.Atomiv.DependencyInjection.Infrastructure.NewtonsoftJson.csproj',
    # 'src\DependencyInjection\Infrastructure\Selenium\Optivem.Atomiv.DependencyInjection.Infrastructure.Selenium.csproj',
    'src\DependencyInjection\Infrastructure\System\Optivem.Atomiv.DependencyInjection.Infrastructure.System.csproj',	


	# ### ============================== WEB ============================== ###

    'src\Web\AspNetCore\Optivem.Atomiv.Web.AspNetCore.csproj',
	
	# ### ============================== TEST ============================== ###

	'test\Base\AspNetCore\Optivem.Atomiv.Test.AspNetCore.csproj',
	'test\Base\EntityFrameworkCore\Optivem.Atomiv.Test.EntityFrameworkCore.csproj',
	'test\Base\FluentAssertions\Optivem.Atomiv.Test.FluentAssertions.csproj',
	'test\Base\MicrosoftExtensions\Optivem.Atomiv.Test.MicrosoftExtensions.csproj',
    'test\Base\Selenium\Optivem.Atomiv.Test.Selenium.csproj'	
    'test\Base\Xunit\Optivem.Atomiv.Test.Xunit.csproj'
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
	
	# D:\Github\optivem\pdn\src\Core\Common\Optivem.Atomiv.Core.Common.Mapping\bin\Release\Optivem.Atomiv.Core.Common.Mapping.1.0.3.nupkg
	
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