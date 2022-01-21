<?php

$type = $_POST["type"];
$data = $_POST["data"];
$vieta = $_POST["vieta"];
$pav = $_POST["pav"];
$time = $_POST["time"];
$info = $_POST["info"];
$id = $_POST["id"];

$servername = "localhost";
$username = "labor@carpartshop.net";
$password = "123asd56";
$dbname = "laboras";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
mysqli_set_charset($conn,"utf8");
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
} 
else echo "cbbgaidy";
$sql="UPDATE `Renginiai` SET `Tipas`='$type',`RenginioData`='$data',`Vieta`='$vieta',`Pavadinimas`='$pav',`Laikas`='$time',`Aprasas`='$info' WHERE `ID` =  $id";
#$sql="INSERT INTO `logins` (`ID`,`username`, `password`, `type`, `GUID`, `Vardas`, `Pavardė`, `Gimimo Data`, `El. Paštas`, `Telefonas`, `Adresas`) VALUES ('NULL','$usr','$pwd','$type','$idgen','$Vardas','$Pav','$data','$ELP','$Tel','$Add');";

#$sql = "SELECT `guid` FROM user WHERE `username`='".$usernamePassed ."' AND `password`='".$passwordPassed."'"; 

$result = $conn->query($sql);
echo $result;
echo $sql;

$conn->close();
?>