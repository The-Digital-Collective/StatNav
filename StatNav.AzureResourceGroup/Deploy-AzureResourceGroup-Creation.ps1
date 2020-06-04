# Added resource group automation and passing param
param(
	[string] [Parameter(Mandatory = $true)] $sharedRGName,
	[string] [Parameter(Mandatory = $true)] $blueRGName,
	[string] [Parameter(Mandatory = $true)] $greenRGName,
	[string] [Parameter(Mandatory = $true)] $location
)

$ErrorActionPreference = 'Stop'

# Store all the resource group in the array list
$rgNameList = @($sharedRGName, $blueRGName, $greenRGName)

# If resource group is already exist, then it won't create new resource group
foreach ($rgName in $rgNameList) {
	Get-AzResourceGroup -Name $rgName -ErrorVariable notPresent -ErrorAction SilentlyContinue
	if ($notPresent){
	   New-AzResourceGroup -Location $location -Name $rgName
	}
 }
