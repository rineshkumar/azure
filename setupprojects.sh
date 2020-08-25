#!/bin/bash
dotnet new classlib -o storage
dotnet new mstest -o storage.tests
dotnet sln add storage/storage.csproj
dotnet sln add storage.tests/storage.tests.csproj
dotnet add storage.tests/storage.tests.csproj reference storage/storage.csproj
