<?php
#$GUID = $_POST["usr"];
$usr = $_POST["usr"];
$pwd = $_POST["pwd"];
$type = $_POST["type"];
$Vardas = $_POST["vard"];
$Pav = $_POST["pav"];
$data = $_POST["data"];
$ELP = $_POST["elp"];
$Tel = $_POST["tel"];
$Add = $_POST["add"];


echo $usr;
echo $pwd;
echo $type;
echo $Vardas;
echo $Pav;
echo $data;
echo $ELP;
echo $Tel;
echo $Add;

include("file.php");

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
$sql="INSERT INTO `logins` (`ID`,`username`, `password`, `type`, `GUID`, `Vardas`, `Pavardė`, `Gimimo Data`, `El. Paštas`, `Telefonas`, `Adresas`) VALUES ('NULL','$usr','$pwd','$type','$idgen','$Vardas','$Pav','$data','$ELP','$Tel','$Add');";

#$sql = "SELECT `guid` FROM user WHERE `username`='".$usernamePassed ."' AND `password`='".$passwordPassed."'"; 

$result = $conn->query($sql);
echo $result;
echo $sql;

$conn->close();
?>