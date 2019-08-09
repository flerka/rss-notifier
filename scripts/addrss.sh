userId=$1
url=$2

curl -v -d '{"userId":"'$userId'", "url":"'$url'"}' -H "Content-Type: application/json" -X POST http://localhost:5001/api/subscription/addrss