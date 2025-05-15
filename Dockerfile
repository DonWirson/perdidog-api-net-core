FROM  mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build

WORKDIR /usr
#mkdir is nedded for it to work >:D
RUN mkdir perdidog

#Restore
COPY /perdidog/perdidog.csproj perdidog
RUN  dotnet restore 'perdidog/perdidog.csproj'

#Build
COPY /perdidog perdidog
WORKDIR /usr/perdidog

FROM build AS publish
RUN dotnet publish perdidog.csproj -c Release -o /app/publish

FROM  mcr.microsoft.com/dotnet/aspnet:8.0-alpine

RUN apk add icu-libs
EXPOSE 8080
WORKDIR /app
RUN mkdir publish

COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet","perdidog.dll" ]
