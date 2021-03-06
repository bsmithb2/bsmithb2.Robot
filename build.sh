#!/usr/bin/env bash

#exit if any command fails
set -e

artifactsFolder="./artifacts"

if [ -d $artifactsFolder ]; then  
  rm -R $artifactsFolder
fi

dotnet restore

dotnet build **/project.json

# Ideally we would use the 'dotnet test' command to test netcoreapp and net451 so restrict for now 
# but this currently doesn't work due to https://github.com/dotnet/cli/issues/3073 so restrict to netcoreapp

dotnet test ./bsmithb2.Robot.Tests 

# Instead, run directly with mono for the full .net version 
#dotnet build ./bsmithb2.Robot.Tests -c Release -f net451

#mono \  
#./bsmithb2.Robot.Tests/bin/Release/net451/*/dotnet-test-xunit.exe \
#./bsmithb2.Robot.Tests/bin/Release/net451/*/bsmithb2.Robot.Tests.dll

revision=${TRAVIS_JOB_ID:=1}  
revision=$(printf "%04d" $revision) 

#dotnet pack ./bsmithb2.Robot -c Release -o ./artifacts --version-suffix=$revision  