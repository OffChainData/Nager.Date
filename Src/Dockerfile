FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Nager.Date.WebsiteCore/Nager.Date.WebsiteCore.csproj /Nager.Date.WebsiteCore/
COPY Nager.Date/Nager.Date.csproj /Nager.Date/
RUN dotnet restore /Nager.Date.WebsiteCore/Nager.Date.WebsiteCore.csproj
COPY . .
WORKDIR /src/Nager.Date.WebsiteCore
RUN dotnet build Nager.Date.WebsiteCore.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Nager.Date.WebsiteCore.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Nager.Date.WebsiteCore.dll"]
