FROM microsoft/dotnet:3.1-sdk as build

ARG BUILDCONFIGI=RELEASE
ARG VERSION=1.0.0

COPY VocabularyBuilder.API.csproj /build/

RUN dotnet restore ./build/VocabularyBuilder.API.csproj

COPY . ./build/
WORKDIR /build/
RUN dotnet publish ./VocabularyBuilder.API.csproj -c $BUILDCONFIG -o out /p:Version=$VERSION

FROM microsoft/dotnet:3.1-aspnetcore-runtime
WORKDIR /app

COPY --from=build /build/out .

ENTRYPOINT ["dotnet", "VocabularyBuilder.API.dll"]


