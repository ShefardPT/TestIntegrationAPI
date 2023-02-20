# TestIntegrationAPI

## Описание

.NET API для получения данных о пользователях со стороннего ресурса

## Требования
* .NET 6 Runtime
* PostgreSQL Server 

## Методы API

### Получение данных о пользователях

Формат запроса: 
```
curl --location '{host}/api/users' 
--header 'login: login' 
--header 'password: password'
```


Формат ответа для неавторизованного пользователя:
```
{
    "data": [
        {
            "name": "Simple user",
            "email": "simpleuser@email.com"
        }
    ],
    "isSuccess": true,
    "errors": []
}
```

Формат ответа для авторизованного пользователя:
```
{
    "data": [
        {
            "id": 0,
            "username": "username",
            "phone": "phone",
            "website": "website",
            "address": {
                "street": "street",
                "suite": "suite",
                "city": "city",
                "zipcode": "zipcode",
                "geo": {
                    "lat": "-0.0",
                    "lng": "0.0"
                }
            },
            "company": {
                "name": "company name",
                "catchPhrase": "catch phrase",
                "bs": "business strategy"
            },
            "name": "Simple user",
            "email": "simpleuser@email.com"
        }
    ],
    "isSuccess": true,
    "errors": []
}
```

Формат ответа в случае ошибки:
```
{
    "data": null,
    "isSuccess": false,
    "errors": [ "Описание ошибки", "Другое описание ошибки" ]
}
```

### Получение журнала запросов данных о пользователях

Формат запроса: 
```
curl --location '{host}/api/users/logs?userLogin=&requestedFrom=&requestedTo='
```

Формат ответа:
```
[
    {
        "login": "Shanna@melissa.tv",
        "requestedOn": "2023-02-20T18:10:09.477579Z"
    },
    {
        "login": "Shanna@melissa.tv",
        "requestedOn": "2023-02-20T18:10:22.284911Z"
    }
]
```

## TBD

* кэширование записей о пользователях, запрашиваемых со стороннего API
* юнит-тесты
* docker-compose для легкого развертывания