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

	# ### Core - Common ###

    # 'src\Core\Common\All\Optivem.Platform.Core.Common.All.csproj',	
    # 'src\Core\Common\Clock\Optivem.Platform.Core.Common.Clock.csproj',
	# 'src\Core\Common\Email\Optivem.Platform.Core.Common.Email.csproj',
	# 'src\Core\Common\FileSystem\Optivem.Platform.Core.Common.FileSystem.csproj',
	# 'src\Core\Common\Logging\Optivem.Platform.Core.Common.Logging.csproj',
    'src\Core\Common\Mapping\Optivem.Platform.Core.Common.Mapping.csproj',
    'src\Core\Common\Parsing\Optivem.Platform.Core.Common.Parsing.csproj',
    'src\Core\Common\Repository\Optivem.Platform.Core.Common.Repository.csproj',
    'src\Core\Common\RestClient\Optivem.Platform.Core.Common.RestClient.csproj',
    'src\Core\Common\Serialization\Optivem.Platform.Core.Common.Serialization.csproj',
    'src\Core\Common\WebAutomation\Optivem.Platform.Core.Common.WebAutomation.csproj',

	# ### Core - Domain ###

    # 'src\Core\Domain\All\Optivem.Platform.Core.Domain.All.csproj',
    # 'src\Core\Domain\Entity\Optivem.Platform.Core.Domain.Entity.csproj',
    # 'src\Core\Domain\Entity.Default\Optivem.Platform.Core.Domain.Entity.Default.csproj',
    # 'src\Core\Domain\Repository\Optivem.Platform.Core.Domain.Repository.csproj',
    # 'src\Core\Domain\Service\Optivem.Platform.Core.Domain.Service.csproj',
    # 'src\Core\Domain\Service.Default\Optivem.Platform.Core.Domain.Service.Default.csproj',

	# ### Core - Application ###
	
    'src\Core\Application\Service\Optivem.Platform.Core.Application.Service.csproj',
    'src\Core\Application\Service.Default\Optivem.Platform.Core.Application.Service.Default.csproj',

	# ### ============================== INFRASTRUCTURE ============================== ###

	# ### Infrastructure - Common ###
	
    # 'src\Infrastructure\Common\All\Optivem.Platform.Infrastructure.Common.Clock.All.csproj',
    # 'src\Infrastructure\Common\Clock.Default\Optivem.Platform.Infrastructure.Common.Clock.Default.csproj',
	# 'src\Infrastructure\Common\Email.Gmail\Optivem.Platform.Infrastructure.Common.Email.Gmail.csproj',
	# 'src\Infrastructure\Common\Email.MicrosoftExchange\Optivem.Platform.Infrastructure.Common.Email.MicrosoftExchange.csproj',
	# 'src\Infrastructure\Common\FileSystem.Default\Optivem.Platform.Infrastructure.Common.FileSystem.Default.csproj',
	# 'src\Infrastructure\Common\Logging.Log4net\Optivem.Platform.Infrastructure.Common.Logging.Log4net.csproj',
    'src\Infrastructure\Common\Mapping.AutoMapper\Optivem.Platform.Infrastructure.Common.Mapping.AutoMapper.csproj',
    'src\Infrastructure\Common\Parsing.Default\Optivem.Platform.Infrastructure.Common.Parsing.Default.csproj',
    'src\Infrastructure\Common\Repository.EntityFrameworkCore\Optivem.Platform.Infrastructure.Common.Repository.EntityFrameworkCore.csproj',
    'src\Infrastructure\Common\RestClient.Default\Optivem.Platform.Infrastructure.Common.RestClient.Default.csproj',
    'src\Infrastructure\Common\Serialization.Csv.CsvHelper\Optivem.Platform.Infrastructure.Common.Serialization.Csv.CsvHelper.csproj',
    'src\Infrastructure\Common\Serialization.Default\Optivem.Platform.Infrastructure.Common.Serialization.Default.csproj',
    # 'src\Infrastructure\Common\Serialization.Dsv\Optivem.Platform.Infrastructure.Common.Serialization.Dsv.csproj',
    # 'src\Infrastructure\Common\Serialization.Excel\Optivem.Platform.Infrastructure.Common.Serialization.Excel.csproj',
    # 'src\Infrastructure\Common\Serialization.FixedWidth\Optivem.Platform.Infrastructure.Common.Serialization.FixedWidth.csproj',
    'src\Infrastructure\Common\Serialization.Json.NewtonsoftJson\Optivem.Platform.Infrastructure.Common.Serialization.Json.NewtonsoftJson.csproj',
    # 'src\Infrastructure\Common\Serialization.Xml\Optivem.Platform.Infrastructure.Common.Serialization.Xml.csproj',
    'src\Infrastructure\Common\WebAutomation.Selenium\Optivem.Platform.Infrastructure.Common.WebAutomation.Selenium.csproj',

	# ### Infrastructure - Domain ###
	
    # 'src\Infrastructure\Domain\Repository\Optivem.Platform.Infrastructure.Domain.Repository.csproj',

	# ### Infrastructure - Application ###

	# None yet

	# ### ============================== WEB ============================== ###

	# ### Web - AspNetCore ###
	
    # 'src\Web\AspNetCore\Common\Optivem.Platform.Web.AspNetCore.Common.csproj',
    # 'src\Web\AspNetCore\Mvc\Optivem.Platform.Web.AspNetCore.Mvc.csproj',
    'src\Web\AspNetCore\Rest\Optivem.Platform.Web.AspNetCore.Rest.csproj',
    # 'src\Web\AspNetCore\Soap\Optivem.Platform.Web.AspNetCore.Soap.csproj',
	
	# ### ============================== TEST ============================== ###
	
	# ### Test - Xunit ###
	
    'src\Test\Xunit\Common\Optivem.Platform.Test.Xunit.Common.csproj', # TODO: VC: Packing did not work
    'src\Test\Xunit\Web.AspNetCore\Optivem.Platform.Test.Xunit.Web.AspNetCore.csproj' # TODO: VC: Packing did not work
    # 'src\Test\Xunit\Web.Selenium\Optivem.Platform.Test.Xunit.Web.Selenium.csproj',
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
	
	# D:\Github\optivem\pdn\src\Core\Common\Optivem.Platform.Core.Common.Mapping\bin\Release\Optivem.Platform.Core.Common.Mapping.1.0.3.nupkg
	
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