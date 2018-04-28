To start

```
cd WebApplication1;
dotnet run
```

You can observe app exposed on port 5000

```
http localhost:5000
```

gives

```
HTTP/1.1 200 OK
Date: Sat, 28 Apr 2018 12:49:09 GMT
Server: Kestrel
Transfer-Encoding: chunked

Hello World!
```

To connect with database type

```
sqlcmd -S localhost -U SA -P 'qqqqqqQ1'
```

To show datbases

```
SELECT Name from sys.Databases
GO
```

To switch to our database

```
use PersonalDB
GO
```

To show content of table

```
SELECT * FROM Inventory
GO
```
