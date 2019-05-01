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

    # 'src\Core\Common\All\Optivem.Framework.Core.Common.All.csproj',	
    # 'src\Core\Common\Clock\Optivem.Framework.Core.Common.Clock.csproj',
	# 'src\Core\Common\Email\Optivem.Framework.Core.Common.Email.csproj',
	# 'src\Core\Common\FileSystem\Optivem.Framework.Core.Common.FileSystem.csproj',
	# 'src\Core\Common\Logging\Optivem.Framework.Core.Common.Logging.csproj',
    'src\Core\Common\Mapping\Optivem.Framework.Core.Common.Mapping.csproj',
    'src\Core\Common\Parsing\Optivem.Framework.Core.Common.Parsing.csproj',
    'src\Core\Common\RestClient\Optivem.Framework.Core.Common.RestClient.csproj',
    'src\Core\Common\Serialization\Optivem.Framework.Core.Common.Serialization.csproj',
    'src\Core\Common\WebAutomation\Optivem.Framework.Core.Common.WebAutomation.csproj',

	# ### Core - Domain ###

    # 'src\Core\Domain\All\Optivem.Framework.Core.Domain.All.csproj',
    'src\Core\Domain\Entities\Optivem.Framework.Core.Domain.Entities.csproj',
    'src\Core\Domain\Repositories\Optivem.Framework.Core.Domain.Repositories.csproj',
    # 'src\Core\Domain\Services\Optivem.Framework.Core.Domain.Services.csproj',

	# ### Core - Application ###
	
    'src\Core\Application\Services\Optivem.Framework.Core.Application.Services.csproj',
    'src\Core\Application\Services.Default\Optivem.Framework.Core.Application.Services.Default.csproj',

	# ### ============================== INFRASTRUCTURE ============================== ###

	# ### Infrastructure - Common ###
	
    # 'src\Infrastructure\Common\All\Optivem.Framework.Infrastructure.Common.Clock.All.csproj',
    # 'src\Infrastructure\Common\Clock.Default\Optivem.Framework.Infrastructure.Common.Clock.Default.csproj',
	# 'src\Infrastructure\Common\Email.Gmail\Optivem.Framework.Infrastructure.Common.Email.Gmail.csproj',
	# 'src\Infrastructure\Common\Email.MicrosoftExchange\Optivem.Framework.Infrastructure.Common.Email.MicrosoftExchange.csproj',
	# 'src\Infrastructure\Common\FileSystem.Default\Optivem.Framework.Infrastructure.Common.FileSystem.Default.csproj',
	# 'src\Infrastructure\Common\Logging.Log4net\Optivem.Framework.Infrastructure.Common.Logging.Log4net.csproj',
    'src\Infrastructure\Common\Mapping.AutoMapper\Optivem.Framework.Infrastructure.Common.Mapping.AutoMapper.csproj',
    'src\Infrastructure\Common\Parsing.Default\Optivem.Framework.Infrastructure.Common.Parsing.Default.csproj',
    'src\Infrastructure\Common\RestClient.Default\Optivem.Framework.Infrastructure.Common.RestClient.Default.csproj',
    'src\Infrastructure\Common\Serialization.Csv.CsvHelper\Optivem.Framework.Infrastructure.Common.Serialization.Csv.CsvHelper.csproj',
    'src\Infrastructure\Common\Serialization.Default\Optivem.Framework.Infrastructure.Common.Serialization.Default.csproj',
    # 'src\Infrastructure\Common\Serialization.Dsv\Optivem.Framework.Infrastructure.Common.Serialization.Dsv.csproj',
    # 'src\Infrastructure\Common\Serialization.Excel\Optivem.Framework.Infrastructure.Common.Serialization.Excel.csproj',
    # 'src\Infrastructure\Common\Serialization.FixedWidth\Optivem.Framework.Infrastructure.Common.Serialization.FixedWidth.csproj',
    'src\Infrastructure\Common\Serialization.Json.NewtonsoftJson\Optivem.Framework.Infrastructure.Common.Serialization.Json.NewtonsoftJson.csproj',
    # 'src\Infrastructure\Common\Serialization.Xml\Optivem.Framework.Infrastructure.Common.Serialization.Xml.csproj',
    'src\Infrastructure\Common\WebAutomation.Selenium\Optivem.Framework.Infrastructure.Common.WebAutomation.Selenium.csproj',

	# ### Infrastructure - Domain ###
	
    'src\Infrastructure\Domain\Repositories.EntityFrameworkCore\Optivem.Framework.Infrastructure.Domain.Repositories.EntityFrameworkCore.csproj',

	# ### Infrastructure - Application ###

	# None yet

	# ### ============================== WEB ============================== ###

	# ### Web - AspNetCore ###
	
    # 'src\Web\AspNetCore\Common\Optivem.Framework.Web.AspNetCore.Common.csproj',
    # 'src\Web\AspNetCore\Mvc\Optivem.Framework.Web.AspNetCore.Mvc.csproj',
    'src\Web\AspNetCore\Rest\Optivem.Framework.Web.AspNetCore.Rest.csproj',
    # 'src\Web\AspNetCore\Soap\Optivem.Framework.Web.AspNetCore.Soap.csproj',
	
	# ### ============================== TEST ============================== ###
	
	# ### Test - Xunit ###
	
    'src\Test\Xunit\Common\Optivem.Framework.Test.Xunit.Common.csproj', # TODO: VC: Packing did not work
    'src\Test\Xunit\Web.AspNetCore\Optivem.Framework.Test.Xunit.Web.AspNetCore.csproj' # TODO: VC: Packing did not work
    # 'src\Test\Xunit\Web.Selenium\Optivem.Framework.Test.Xunit.Web.Selenium.csproj',
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