# SearchFight

 Console App SearchFight 

## Starting 🚀

Project Structure:
  - API:
    - Bing: conection with Bing Search Api
    - Google: Authentication and consume Google Search Api
  - Entity: 
    - Bing:
      - Search: Structure to map Bing Search API Response
    - Google:
      - Authentication: Structure to map Google Auth API Response
      - Search: Structure to map Google Search API Response
    - SearchResult: main entity on which the use cases will be built
  - UseCase: 
    - Engines: 
      - Bing: business class with the custom search execution for MSN Search
      - DuckDuckGo: business class with the custom search execution for DuckDuckGo
      - Google: business class with the custom search execution for Google
    - Engine: business class with the common search and set the winner by engine
    - Search: main business class, which contains the orchestration of search engine and result writing
  - Constants: Invariable information 
  - Util: Reusable methods
  - Program: Main method and mapping appSettings.json

### Prerequisites and references 📋

Framework : NetCore 3.1
Microsoft.Extensions.Hosting   : 5.0.0

## Building with 🛠️

* [NetCore 3.0](https://dotnet.microsoft.com/download/dotnet-core/3.0)
* [Microsoft.Extensions.Hosting](https://www.nuget.org/packages/Microsoft.Extensions.Hosting/) 

## Autores ✒️

* **Klinsmann Carhuas**  - [kgcaHub](https://github.com/kgcaHub)

## Licencia 📄

---
⌨️ with ❤️ by [kgcaHub](https://github.com/kgcaHub) 😊
