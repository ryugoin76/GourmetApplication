# Learn about building .NET container images:
# https://github.com/dotnet/dotnet-docker/blob/main/samples/README.md
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG TARGETARCH
WORKDIR /source

# copy csproj and restore as distinct layers
# 依存関係の検索および必要に応じてダウンロードがNuGetを使用して行われる
# また、プロジェクトで必要なすべての依存関係が相互に互換性があり、それらの間に競合がないことを確認
COPY GourmetApplication/*.csproj GourmetApplication/
RUN dotnet restore  -a $TARGETARCH

COPY Database/*.csproj .

# copy and publish app and libraries
COPY GourmetApplication/. .

# RUN dotnet publish -a $TARGETARCH --no-restore -o /app
RUN dotnet publish -a $TARGETARCH --no-restore -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 8080
WORKDIR /app
COPY --from=build /app .
USER $APP_UID
ENTRYPOINT ["./GourmetApplication"]
