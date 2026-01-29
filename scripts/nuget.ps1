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
	
    'src\Core\All\Atomiv.Core.All.csproj',	
    'src\Core\Application\Atomiv.Core.Application.csproj',
    'src\Core\Common\Atomiv.Core.Common.csproj',
    'src\Core\Domain\Atomiv.Core.Domain.csproj',
	
	# ### ============================== INFRASTRUCTURE ============================== ###
	
    'src\Infrastructure\AspNetCore\Atomiv.Infrastructure.AspNetCore.csproj',
    'src\Infrastructure\AutoMapper\Atomiv.Infrastructure.AutoMapper.csproj',
    'src\Infrastructure\CsvHelper\Atomiv.Infrastructure.CsvHelper.csproj',
    'src\Infrastructure\EntityFrameworkCore\Atomiv.Infrastructure.EntityFrameworkCore.csproj',
    'src\Infrastructure\EPPlus\Atomiv.Infrastructure.EPPlus.csproj',
    'src\Infrastructure\FluentValidation\Atomiv.Infrastructure.FluentValidation.csproj',
    'src\Infrastructure\MongoDB\Atomiv.Infrastructure.MongoDB.csproj',
    'src\Infrastructure\NewtonsoftJson\Atomiv.Infrastructure.NewtonsoftJson.csproj',
    'src\Infrastructure\RabbitMQ\Atomiv.Infrastructure.RabbitMQ.csproj',
    'src\Infrastructure\Selenium\Atomiv.Infrastructure.Selenium.csproj',
    'src\Infrastructure\SequentialGuid\Atomiv.Infrastructure.SequentialGuid.csproj',
    'src\Infrastructure\System\Atomiv.Infrastructure.System.csproj',
	
	# ### ============================== DEPENDENCY INJECTION ============================== ###
	
	# Base
    'src\DependencyInjection\Base\DependencyInjection\Atomiv.DependencyInjection.Common.csproj', # TODO: VC: Rename
	
	# Core
    'src\DependencyInjection\Core\Application\Atomiv.DependencyInjection.Core.Application.csproj',
    'src\DependencyInjection\Core\Domain\Atomiv.DependencyInjection.Core.Domain.csproj',
	
	# Infrastructure
	'src\DependencyInjection\Infrastructure\AspNetCore\Atomiv.DependencyInjection.Infrastructure.AspNetCore.csproj',
    'src\DependencyInjection\Infrastructure\AutoMapper\Atomiv.DependencyInjection.Infrastructure.AutoMapper.csproj',
    # 'src\DependencyInjection\Infrastructure\CsvHelper\Atomiv.DependencyInjection.Infrastructure.CsvHelper.csproj',
    'src\DependencyInjection\Infrastructure\EntityFrameworkCore\Atomiv.DependencyInjection.Infrastructure.EntityFrameworkCore.csproj',
    # 'src\DependencyInjection\Infrastructure\EPPlus\Atomiv.DependencyInjection.Infrastructure.EPPlus.csproj',
    'src\DependencyInjection\Infrastructure\FluentValidation\Atomiv.DependencyInjection.Infrastructure.FluentValidation.csproj',
    'src\DependencyInjection\Infrastructure\MongoDB\Atomiv.DependencyInjection.Infrastructure.MongoDB.csproj',
    'src\DependencyInjection\Infrastructure\NewtonsoftJson\Atomiv.DependencyInjection.Infrastructure.NewtonsoftJson.csproj',
    # 'src\DependencyInjection\Infrastructure\Selenium\Atomiv.DependencyInjection.Infrastructure.Selenium.csproj',
    'src\DependencyInjection\Infrastructure\System\Atomiv.DependencyInjection.Infrastructure.System.csproj',	

	# Web
	'src\DependencyInjection\Web\AspNetCore\Atomiv.DependencyInjection.Web.AspNetCore.csproj',

	# ### ============================== WEB ============================== ###

    'src\Web\AspNetCore\Atomiv.Web.AspNetCore.csproj',
	
	# ### ============================== TEST ============================== ###

	'test\Base\AspNetCore\Atomiv.Test.AspNetCore.csproj',
	'test\Base\EntityFrameworkCore\Atomiv.Test.EntityFrameworkCore.csproj',
	'test\Base\FluentAssertions\Atomiv.Test.FluentAssertions.csproj',
	'test\Base\MicrosoftExtensions\Atomiv.Test.MicrosoftExtensions.csproj',
    'test\Base\Selenium\Atomiv.Test.Selenium.csproj',	
    'test\Base\Xunit\Atomiv.Test.Xunit.csproj'
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
	
	# D:\Github\atomiv\pdn\src\Core\Common\Atomiv.Core.Common.Mapping\bin\Release\Atomiv.Core.Common.Mapping.1.0.3.nupkg
	
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