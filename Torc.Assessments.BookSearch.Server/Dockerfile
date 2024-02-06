#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["torc.assessments.booksearch.client/nuget.config", "torc.assessments.booksearch.client/"]
COPY ["Torc.Assessments.BookSearch.Server/Torc.Assessments.BookSearch.Server.csproj", "Torc.Assessments.BookSearch.Server/"]
COPY ["torc.assessments.booksearch.client/torc.assessments.booksearch.client.esproj", "torc.assessments.booksearch.client/"]
RUN dotnet restore "./Torc.Assessments.BookSearch.Server/./Torc.Assessments.BookSearch.Server.csproj"
COPY . .
WORKDIR "/src/Torc.Assessments.BookSearch.Server"
RUN dotnet build "./Torc.Assessments.BookSearch.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Torc.Assessments.BookSearch.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Torc.Assessments.BookSearch.Server.dll"]