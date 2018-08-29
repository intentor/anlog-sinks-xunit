# Project settings.
PROJECT_ID=Anlog.Sinks.xUnit
MAIN_PROJECT_FOLDER=src/Anlog.Sinks.XUnit
MAIN_PROJECT_FILE=$(MAIN_PROJECT_FOLDER)/Anlog.Sinks.XUnit.csproj

# Build variables.
PROJECT_VERSION=$(shell cat $(MAIN_PROJECT_FILE) | grep -oP '(?<=<Version>).+(?=<\/Version>)')

build:
	dotnet build

test:
	find tests/**/*.csproj -exec dotnet test '{}' \;
	
local:
	dotnet msbuild "$(MAIN_PROJECT_FOLDER)" -t:PublishLocal
	
publish:
	dotnet msbuild "$(MAIN_PROJECT_FOLDER)" -t:PublishNuget