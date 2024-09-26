FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY src/NetForeMostTestBlogsProject.Domain/NetForeMostTestBlogsProject.Domain.csproj ./src/NetForeMostTestBlogsProject.Domain/
COPY src/NetForeMostTestBlogsProject.Application/NetForeMostTestBlogsProject.Application.csproj ./src/NetForeMostTestBlogsProject.Application/
COPY src/NetForeMostTestBlogsProject.Infrastructure/NetForeMostTestBlogsProject.Infrastructure.csproj ./src/NetForeMostTestBlogsProject.Infrastructure/
COPY src/NetForeMostTestBlogsProject.Api/NetForeMostTestBlogsProject.Api.csproj ./src/NetForeMostTestBlogsProject.Api/
RUN dotnet restore ./src/NetForeMostTestBlogsProject.Api/NetForeMostTestBlogsProject.Api.csproj

COPY . ./
RUN dotnet publish ./src/NetForeMostTestBlogsProject.Api -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
EXPOSE 5432
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "NetForeMostTestBlogsProject.Api.dll"]
