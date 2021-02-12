#!/bin/bash

dotnet publish ./PAYNLSDK/PAYNLSDK.csproj -c Release -f netcoreapp3.1 -o publish/netcoreapp3.1
dotnet publish ./PAYNLSDK/PAYNLSDK.csproj -c Release -f net5 -o publish/net5
