# this script return all products on index

curl -XGET "http://localhost:9200/products/_search?pretty=true" -d '
{
    "query" :{
        "match_all" :{

        }
    }
}
'