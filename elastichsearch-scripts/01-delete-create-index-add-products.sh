# this script remove and create index

# remove index
curl -XDELETE "http://localhost:9200/products?pretty=true"

# create index
curl -XPUT "http://localhost:9200/products?pretty=true" -d'
{
  "settings": {
    "analysis": {
      "analyzer": {
        "custom": {
          "tokenizer": "standard",
          "filter": [
            "lowercase",
            "stemmer_plural_portugues",
            "asciifolding"
          ]
        }
      },
      "filter": {
        "stemmer_plural_portugues": {
          "type": "stemmer",
          "name": "minimal_portuguese"
        }
      }
    }
  },
  "mappings": {
    "product": {
      "properties": {
        "description": {
          "type": "string",
          "analyzer": "custom"
        },
        "name": {
          "type": "string",
          "analyzer": "custom"
        },
        "id": {
          "type": "string",
          "index": "not_analyzed"
        }
      }
    }
  }
}'

# add products with API
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