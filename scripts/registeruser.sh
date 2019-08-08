email=$1
password=$2

curl -v -d '{"email":"'$email'", "password":"'$password'"}' -H "Content-Type: application/json" -X POST http://localhost:5000/api/user/register