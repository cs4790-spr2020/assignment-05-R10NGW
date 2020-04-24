cd BlabberApp.ServicesTest
dotnet add package coverlet.msbuild
dotnet test /p:CollectCoverage=true /p:CoverLetOutput=TestResults /p:CoverletOutputFormat=lcov
.\tools\reportgenerator.exe -reports:./TestResults.info -targetdir:./TestResults/
cd ../BlabberApp.DomainTest
dotnet add package coverlet.msbuild
dotnet test /p:CollectCoverage=true /p:CoverLetOutput=TestResults /p:CoverletOutputFormat=lcov
.\tool\reportgenerator.exe -reports:./TestResults.info -targetdir:./TestResults/
cd ../BlabberApp.DataStoreTest
dotnet add package coverlet.msbuild
dotnet test /p:CollectCoverage=true /p:CoverLetOutput=TestResults /p:CoverletOutputFormat=lcov
.\tools\reportgenerator.exe -reports:./TestResults.info -targetdir:./TestResults/
#cd ../BlabberApp.ClientTest
#dotnet add package coverlet.msbuild
#dotnet test /p:CollectCoverage=true /p:CoverLetOutput=TestResults /p:CoverletOutputFormat=lcov
#.\tools\reportgenerator.exe -reports:.\TestResults.info -targetdir:.\TestResults\
cd ..
