FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY *.sln .

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ResumeApp/ResumeApp.csproj", "ResumeApp/"]
COPY . .
RUN dotnet restore 
#RUN dotnet restore "ResumeApp/ResumeApp.csproj"

WORKDIR "/src/ResumeApp"
RUN dotnet build "ResumeApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ResumeApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "ResumeApp.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet ResumeApp.dll