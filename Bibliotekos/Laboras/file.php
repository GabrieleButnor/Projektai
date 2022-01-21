<?php

$servername = "localhost";
$username = "labor@carpartshop.net";
$password = "123asd56";
$dbname = "laboras";

$yra = 1;
$idgen;
while($yra == 1)
{

$idgen = md5(uniqid($your_user_login, true)) . md5(uniqid($your_user_login, true));


// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
} 
$sql = "SELECT
  COUNT(logins.guid) AS expr1
FROM logins
WHERE logins.GUID = '$idgen'"; 

$result = $conn->query($sql);
$row = $result->fetch_assoc();
$yra = $row["expr1"];
$conn->close();
}

?>