FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AssignmentWebAPI/AssignmentWebAPI.csproj", "AssignmentWebAPI/"]
RUN dotnet restore "AssignmentWebAPI/AssignmentWebAPI.csproj"
COPY . .
WORKDIR "/src/AssignmentWebAPI"
RUN dotnet build "AssignmentWebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AssignmentWebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AssignmentWebAPI.dll"]
