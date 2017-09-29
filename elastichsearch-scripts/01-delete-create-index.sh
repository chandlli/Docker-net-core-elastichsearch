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