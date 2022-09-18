FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS publish
WORKDIR /src
# COPY ["./api/report-sv/report-sv.csproj", "./"]
# RUN dotnet restore "report-sv.csproj"
RUN apk add --update nodejs npm
COPY ./ ./
WORKDIR "/src/."
RUN npx nx run group-sv:publish

FROM base AS final
WORKDIR /app
COPY --from=publish /src/dist/apps/group-sv/net6.0/publish .
ENTRYPOINT ["dotnet", "NxFullstack.GroupSv.dll"]