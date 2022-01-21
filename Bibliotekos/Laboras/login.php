<?php

$usernamePassed = $_GET["usr"];
$passwordPassed = $_GET["pwd"];

$servername = "localhost";
$username = "labor@carpartshop.net";
$password = "123asd56";
$dbname = "laboras";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
} 

$sql = "SELECT
  Pareigos.pareigos,
  logins.GUID
FROM Pareigos
  INNER JOIN logins
    ON Pareigos.ID = logins.type
    WHERE `username`='".$usernamePassed ."' AND `password`='".$passwordPassed."'";
#$sql = "SELECT `guid` FROM user WHERE `username`='".$usernamePassed ."' AND `password`='".$passwordPassed."'"; 
#echo $sql;
$result = $conn->query($sql);
$row = $result->fetch_assoc();
$toScreen = $row["GUID"];


echo $toScreen; echo ";"; echo $row["pareigos"];
$conn->close();
?>