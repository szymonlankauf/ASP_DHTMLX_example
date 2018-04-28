# Backend

To start

```
cd WebApplication1;
dotnet run
```

You can observe app exposed on port 5000

```
http localhost:5000
```

gives proper xml document

```
HTTP/1.1 200 OK
Content-Type: application/xml
Date: Sat, 28 Apr 2018 13:14:13 GMT
Server: Kestrel
Transfer-Encoding: chunked

<?xml version="1.0" encoding="UTF-8"?>
<root>
    <row firstName="Jan" id="1" lastName="Kowalski" pesel="12345678901" />
    <row firstName="Katarzyna" id="2" lastName="Kwiatkowska" pesel="32165409876" />
</root>
```

[![backend.png](https://s14.postimg.cc/l9jfnnrc1/Zrzut_ekranu_z_2018-04-28_16-29-39.png)](https://postimg.cc/image/bozt0s1zx/)

# Frontend

To start frontend type in other console

```
cd public
http-server
```

And you can go to address `localhost:8080` in your likest browser.
If you do not have http-server install it by `npm install -g http-server`

You should see table like this

[![frontend.png](https://s14.postimg.cc/u3ac541jl/Zrzut_ekranu_z_2018-04-28_16-25-18.png)](https://postimg.cc/image/pu5m2xya5/)


# Database

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
