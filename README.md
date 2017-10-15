# Running Web Api .Net Core + Elasticsearch with Docker
Simple web api example making request on elasticsearch running on docker.

This example was built using .Net core SDK 2.0 on ubuntu 16.04

## Getting Started
Clone or download project and on project root folder run docker-compose:

    docker-compose up --build

Wait docker download images and run containers.

Once containers running, execute script `elastichsearch-scripts/01-delete-create-index-add-products.sh` on bash:

    sh 01-delete-create-index-add-products.sh

This script remove and create an index named `products` and send to Web API a product collection. Web API send collection to elasticsearch.

## Web API Tests
Web API route is `http://localhost/api/product/search/{query}` where `query` is term to search. 
Call in browser:

    http://localhost/api/product/search/produto

The result must be:

```
[
    {
        "id": "1B",
        "name": "Chinelo",
        "description": "Produto da seção de calçados",
        "value": 0
    },
    {
        "id": "1X",
        "name": "Mouse",
        "description": "Produto da seção de informática",
        "value": 0
    },
    {
        "id": "2B",
        "name": "Havaina",
        "description": "Produto da seção de calçados",
        "value": 0
    },
    {
        "id": "2X",
        "name": "Teclado",
        "description": "Produto da seção de informática",
        "value": 0
    }
]
```

## Elasticsearch Index
This index `products` analyze words in `brazilian portuguese`. Means that accented words will be replaced with it root form. Example:

    à -> a

Calling these routes `http://localhost/api/product/search/informática` and `http://localhost/api/product/search/informatica`, the result should be the same:
```
[
    {
        "id": "1X",
        "name": "Mouse",
        "description": "Produto da seção de informática",
        "value": 0
    },
    {
        "id": "2X",
        "name": "Teclado",
        "description": "Produto da seção de informática",
        "value": 0
    }
]
```

## Dotnet Watch
dotnet watch command restart application when any file change occurs. 

# Built With
- [ASP.NET Core 2.0 SDK](https://github.com/aspnet/Home)
- [NEST](https://www.elastic.co/guide/en/elasticsearch/client/net-api/current/nest.html) - .Net elasticsearch client
- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)
- [Elasticsearch](https://www.elastic.co/)

# License
This project is licensed under the MIT License.
