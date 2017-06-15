 
echo "Deploying EncounterGen to NuGet"

ApiKey=$1
Source=$2

echo "Nuget Source is $Source"
echo "Nuget API Key is $ApiKey (should be secure)"

echo "Listing bin directory"
for entry in "./EncounterGen/bin"/*
do
  echo "$entry"
done

echo "Packing EncounterGen"
nuget pack ./EncounterGen/EncounterGen.nuspec -Verbosity detailed

echo "Packing EncounterGen.Domain"
nuget pack ./EncounterGen.Domain/EncounterGen.Domain.nuspec -Verbosity detailed

echo "Pushing EncounterGen"
nuget push ./EncounterGen.*.nupkg -Verbosity detailed -ApiKey $ApiKey -Source $Source

echo "Pushing EncounterGen.Domain"
nuget push ./EncounterGen.Domain.*.nupkg -Verbosity detailed -ApiKey $ApiKey -Source $Source