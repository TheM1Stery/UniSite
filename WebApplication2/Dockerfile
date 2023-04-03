FROM node:19 as node
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
COPY --from=node . .
WORKDIR /src
COPY ["WebApplication2.csproj", "."]
RUN dotnet restore "WebApplication2.csproj"
COPY . .
RUN dotnet build "WebApplication2.csproj" -c Release -o /app/build


FROM build as client
COPY ["Client", "Client"]
WORKDIR Client
RUN npm install -g pnpm
RUN pnpm install
RUN pnpm build

FROM client AS publish
WORKDIR /src
RUN dotnet publish "WebApplication2.csproj" -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
EXPOSE 80
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApplication2.dll"]
