# Use the official .NET 8 SDK image as a base
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory in the container to /app
WORKDIR /app

# Copy the .csproj file
COPY devsanx/devsanx.csproj ./devsanx/

# Restore its dependencies
RUN dotnet restore

# Copy the entire project
COPY . ./

# Build the project
RUN dotnet publish ./devsanx/devsanx.csproj -c Release -o out

# Use the ASP.NET Core runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Expose the port the website runs on
EXPOSE 80

# Set the entry point for the website
ENTRYPOINT ["dotnet", "devsanx.dll"]

