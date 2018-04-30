# Backend

To start

```
cd WebApplication1;
dotnet run
```

You can observe app exposed on port 5000. Execution of

```
http localhost:5000
```

gives proper xml document

```
HTTP/1.1 200 OK
Content-Type: application/xml
Date: Mon, 30 Apr 2018 08:30:47 GMT
Server: Kestrel
Transfer-Encoding: chunked

<?xml version="1.0" encoding="UTF-8"?>
<root>
    <rows>
        <row>
            <cell>1</cell>
            <cell>Jan</cell>
            <cell>Kowalski</cell>
            <cell>12345678901</cell>
        </row>
        <row>
            <cell>2</cell>
            <cell>Test</cell>
            <cell>User</cell>
            <cell>22</cell>
        </row>
    </rows>
</root>
```

To update data in backend you need send PUT requst like this:

http -f PUT http://localhost:5000 id=5 firstName="Exemplay" lastName="Data" pesel="15245698536"

Backend should return response

```
HTTP/1.1 200 OK
Content-Type: application/xml
Date: Mon, 30 Apr 2018 08:33:30 GMT
Server: Kestrel
Transfer-Encoding: chunked

<status>Accepted</status>
```

and update element with given id. To investigate request we used [`httpie`](https://httpie.org/).

# Frontend

To start frontend type in other console

```
cd public
http-server
```

And you can go to address `localhost:8080` in your likest browser.
If you do not have http-server install it by `npm install -g http-server`

You should see table like this

[![frontend.png](https://s14.postimg.cc/hqcnpba6p/Zrzut_ekranu_z_2018-04-30_10-28-45.png)](https://postimg.cc/image/wmb6wwll9/)

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
