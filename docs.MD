# Ülevaade
Käesoleva rakenduse eesmärk on toimida registreerimissüsteemina, mis võimaldab lisada/ muuta ja kustutada tulevikus toimuvaid üritusi. Juba
toimunud üritusi on võimalik vaadata kuid mitte kustutada. Igale üritusele on võimalik lisada osalejaid, rakenduse esmases funktsionaalsuses
on tagatud füüsiliste isikute lisamise võimalus. Kõikide üritsel osalejate nimekirja on võimalik näha avades ürituse detailvaade. Detailvaade
avaneb avalehelt, ürituste loetelus üritse nime all olevalt lingilt.
Ürituse detailvaates isiku nime all olevalt lingilt on võimalik tutvuda üritusele lisatud isiku andmetega, vajadusel neid muuta või isik ürituselt
eemaldada.
Lisaks on võimalik hallata makseviise, selle võimaluse leiab peamenüüs "Halda makseviise" lingilt. Makseviise on võimalik lisada/ muuta/ kustutada.

Rakenduse esialgsel käivitamisel täidetakse andmebaas eelloodud olemitega:
1. Juriidiliste isikute liigid (Eestis eksisteerivad ettevõtlusvormid)
2. Tasumiseviisid (Sularaha, pangaülekanne)
3. Üritusel osalevate isikute rollid (Korraldaja, osaleja)

Eelnimetatu peaks võimaldama rakenduse kasutuselevõtmist ilma lisa andmebaasi seadistamiseta.

# Rakenduse paigaldamine ja käivitamine
Rakendus on kättesaadav autori avalikust GitHubi repositooriumist aadressil https://github.com/tosult/yritus
Kasutamiseks on vajalik versioon .NET SDK 9.0+.
Rakendus kasutab SQLite andmebaasi, andmebaas ei sisaldu projekti failides ning luuakse esmasel käivitamisel ning paigutatakse WebApp kausta.
Rakendus kasutab:

Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Sqlite
Microsoft.EntityFrameworkCore.Design
Automapper
Microsoft.VisualStudio.Web.CodeGeneration.Design
Microsoft.EntityFrameworkCore.Tools
Microsoft.EntityFrameworkCore.SqlServe
AngleSharp

Rakendus käivitub projektist WebApp/program.cs (dotnet run program.cs)

## Rakenduse kasutajaliides
Rakenduse verifitseerimiseks ja testimiseks on kasutatud .NET MVC võimalusi:
- loodud on Controller klassid, mis rakendavad põhilisi funktsionaalsusi
- genereeritud on CRUD-vaated, et hallata entiteete läbi veebiliidese

Rakenduse veebiliidese puhul ei ole eraldi järgitud nõudeid ega standardeid ning see on loodud pidades esmajoones silmas võimalust rakendust
käivitada, testida ja valideerida.

# Rakenduse arhitektuur
Rakendus kasutab kihilist arhitektuuri, kokku koosneb rakendus 17 väiksemast projektist.
Andmebaas on loodud pidades silmas <i>code first</i> lähenemist ehk see on üles ehitatud olemite klassidena, mille alusel hilisemalt
andmebaasi migratsioon on loodud.
Andmebaasi tunnus id jaoks on kasutusel abstraktne DomainEntityId klass, mis annab kõikidele laienevtele alamklassidele ühise omaduse
identifikaatori näol.
Eraldatud on äriloogika kiht kuid rakenduse toimivas versioonis puuduvad erinevused äriloogika ja domeenimudeli vahelisel kihil. Kihtide vahel
kasutatakse <i>mapper</i>eid, mille abil tõlgendatakse andmeid kihtide vahel.

## Projektide jagunemine

### Domain layer (Domain)
- Domain.App - domeenimudel
- Domain.Contracts.Base - domeenikihi lepingud
- Domain.Base - baasklassid/ abstraktsioonid

### Data Access Layer (DAL)
- DAL.EF.App - entity framework implementatsioon
- DAL.Contracts.App - andmekihi lepingud
- DAL.Contracts.Base - baaskihi lepingud
- DAL.Base - baasklassid/ abstraktsioonid
- DAL.EF.Base - entity framework baasklassid/ abstraktsioonid

### Business Logic Layer (BLL)
- Bll.Contracts.App - äriloogika lepingud
- BLL.App - äriloogika
- BLL.DTO - andmeedastusobjektid
- BLL.Contracts.Base - baaslepingud
- BLL.Base - baaskomponendid

### Public DTO
- Public.DTO - kasutamiseks väljaspool rakendust (APIde loomine)

### Tests
- Tests - automaattestid

### Application Web Layer
- WebApp - veebirakendus