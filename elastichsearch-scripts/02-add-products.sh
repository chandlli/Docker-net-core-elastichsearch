# this script send products to API

curl -XPUT "http://localhost/api/product" -H "Content-Type: application/json" -d '[
    {
        "id": "1A",
        "name": "Tênis marca A",
        "description": "Esse tênis pertence à marca A"
    },
    {
        "id": "1X",
        "name": "Mouse",
        "description": "Produto da seção de informática"
    },
    {
        "id": "2X",
        "name": "Teclado",
        "description": "Produto da seção de informática"
    },
    {
        "id": "1B",
        "name": "Chinelo",
        "description": "Produto da seção de calçados"
    },
    {
        "id": "2B",
        "name": "Havaina",
        "description": "Produto da seção de calçados"
    }
]'