<?php
$pavadinimas = $_POST["pavadinimas"];
$autorius = $_POST["autorius"];
$isleidimo_data = $_POST["isleidimo_data"];
$leidejas = $_POST["leidejas"];
$zanras = $_POST["zanras"];
$busena = $_POST["busena"];
$puslapiu_sk = $_POST["puslapiu_sk"];
$komentaras = $_POST["komentaras"];

$servername = "localhost";
$username = "labor@carpartshop.net";
$password = "123asd56";
$dbname = "laboras";

$conn = new mysqli($servername, $username, $password, $dbname);
mysqli_set_charset($conn,"utf8");

if ($conn->connect_error){die("Connection failed: " . $conn->connect_error);} 

$sql="INSERT INTO book(pavadinimas, autorius, isleidimo_data, leidejas, zanras, busena, puslapiu_sk, komentaras) ".
	"VALUES ('$pavadinimas','$autorius','$isleidimo_data','$leidejas','$zanras','$busena','$puslapiu_sk','$komentaras')";

$conn->query($sql);
$conn->close();
?>