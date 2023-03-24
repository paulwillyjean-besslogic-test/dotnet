ARG DOTNET_VERSION=7.0
FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION} as build
COPY *.csprog /build/
COPY .config /build/.config/
WORKDIR /build
RUN dotnet tool restore
RUN dotnet restore
COPY . /build/
RUN dotnet publish -o /dist

FROM scratch as snapshot
COPY --from=build /dist/ /

FROM mcr.microsoft.com/dotnet/aspnet:${DOTNET_VERSION} as runtime
COPY --from=snapshot / /app/
WORKDIR /app
CMD []